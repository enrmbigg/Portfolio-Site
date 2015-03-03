using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using System.Web.Security;
using System.IO;
using System.Collections;
using RoleList = System.Web.Security.Roles;

namespace portfolio.Admin.Access
{
    public partial class AccessRules : System.Web.UI.Page
    {
        private const string VirtualImageRoot = "~/";
        string _selectedFolderName;

        private void Page_Init()
        {
            UserRoles.DataSource = RoleList.GetAllRoles();
            UserRoles.DataBind();

            UserList.DataSource = Membership.GetAllUsers();
            UserList.DataBind();
            _selectedFolderName = IsPostBack ? "" : Request.QueryString["selectedFolderName"];
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) PopulateTree();
        }

        private void Page_PreRender()
        {
            if (FolderTree.SelectedNode != null)
            {
                DisplayAccessRules(FolderTree.SelectedValue);
                SecurityInfoSection.Visible = true;
            }
        }

        private void PopulateTree()
        {
            // Populate the tree based on the subfolders of the specified VirtualImageRoot
            DirectoryInfo rootFolder = new DirectoryInfo(Server.MapPath(VirtualImageRoot));
            TreeNode root = AddNodeAndDescendents(rootFolder, null);
            FolderTree.Nodes.Add(root);
            FolderTree.SelectedNode.ImageUrl = "~/Images/i/folder.gif";
        }

        private TreeNode AddNodeAndDescendents(DirectoryInfo folder, TreeNode parentNode)
        {
            // Add the TreeNode, displaying the folder's name and storing the full path to the folder as the value...

            var virtualFolderPath = parentNode == null ? VirtualImageRoot : parentNode.Value + folder.Name + "/";

            TreeNode node = new TreeNode(folder.Name, virtualFolderPath);
            node.Selected = (folder.Name == _selectedFolderName);

            // Recurse through this folder's subfolders
            DirectoryInfo[] subFolders = folder.GetDirectories();
            foreach (TreeNode child in from subFolder in subFolders where subFolder.Name != "App_Code" && subFolder.Name != "App_Data" && subFolder.Name != "obj" select AddNodeAndDescendents(subFolder, node))
            {
                node.ChildNodes.Add(child);
            }
            return node; // Return the new TreeNode
        }

        protected void FolderTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            ActionDeny.Checked = true;
            ActionAllow.Checked = false;
            ApplyRole.Checked = true;
            ApplyUser.Checked = false;
            ApplyAllUsers.Checked = false;
            ApplyAnonUser.Checked = false;
            UserRoles.SelectedIndex = 0;
            UserList.SelectedIndex = 0;

            RuleCreationError.Visible = false;

            ResetFolderImageUrls(FolderTree.Nodes[0]); // Restore previously selected folder's ImageUrl.
            FolderTree.SelectedNode.ImageUrl = "~/Images/i/folder.gif"; // Set the newly selected folder's ImageUrl.
        }

        private static void ResetFolderImageUrls(TreeNode parentNode)
        {
            parentNode.ImageUrl = "~/Images/i/folder.gif";

            // Recurse through this node's child nodes.
            TreeNodeCollection nodes = parentNode.ChildNodes;
            foreach (TreeNode childNode in nodes)
            {
                ResetFolderImageUrls(childNode);
            }
        }

        private void DisplayAccessRules(string virtualFolderPath)
        {
            if (!virtualFolderPath.StartsWith(VirtualImageRoot) || virtualFolderPath.IndexOf("..", StringComparison.Ordinal) >= 0)
            {
                throw new ApplicationException("An attempt to access a folder outside of the website directory has been detected and blocked.");
            }
            Configuration config = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath);
            SystemWebSectionGroup systemWeb = (SystemWebSectionGroup)config.GetSectionGroup("system.web");
            AuthorizationRuleCollection authorizationRules = systemWeb.Authorization.Rules;
            RulesGrid.DataSource = authorizationRules;
            RulesGrid.DataBind();
            TitleOne.InnerText = "Rules applied to " + virtualFolderPath;
            TitleTwo.InnerText = "Create new rule for " + virtualFolderPath;
        }

        public void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            AuthorizationRule rule = (AuthorizationRule)e.Row.DataItem;
            if (rule.ElementInformation.IsPresent) return;
            e.Row.Cells[3].Text = "Inherited from higher level";
            e.Row.Cells[4].Text = "Inherited from higher level";
            e.Row.CssClass = "odd";
        }

        public string GetAction(AuthorizationRule rule)
        {
            return rule.Action.ToString();
        }
        public string GetRole(AuthorizationRule rule)
        {
            return rule.Roles.ToString();
        }
        public string GetUser(AuthorizationRule rule)
        {
            return rule.Users.ToString();
        }
        public void DeleteRule(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow item = (GridViewRow)button.Parent.Parent;
            string virtualFolderPath = FolderTree.SelectedValue;
            Configuration config = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath);
            SystemWebSectionGroup systemWeb = (SystemWebSectionGroup)config.GetSectionGroup("system.web");
            AuthorizationSection section = (AuthorizationSection)systemWeb.Sections["authorization"];
            section.Rules.RemoveAt(item.RowIndex);
            config.Save();
        }
        public void MoveUp(object sender, EventArgs e)
        {
            MoveRule(sender, e, "up");
        }
        public void MoveDown(object sender, EventArgs e)
        {
            MoveRule(sender, e, "down");
        }

        public void MoveRule(object sender, EventArgs e, string upOrDown)
        {
            upOrDown = upOrDown.ToLower();

            if (upOrDown != "up" && upOrDown != "down") return;
            Button button = (Button)sender;
            GridViewRow item = (GridViewRow)button.Parent.Parent;
            int selectedIndex = item.RowIndex;
            if ((selectedIndex <= 0 || upOrDown != "up") && (upOrDown != "down")) return;
            string virtualFolderPath = FolderTree.SelectedValue;
            Configuration config = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath);
            SystemWebSectionGroup systemWeb = (SystemWebSectionGroup)config.GetSectionGroup("system.web");
            AuthorizationSection section = (AuthorizationSection)systemWeb.Sections["authorization"];

            // Pull the local rules out of the authorization section, deleting them from same:
            ArrayList rulesArray = PullLocalRulesOutOfAuthorizationSection(section);
            switch (upOrDown)
            {
                case "up":
                    LoadRulesInNewOrder(section, rulesArray, selectedIndex, upOrDown);
                    break;
                case "down":
                    if (selectedIndex < rulesArray.Count - 1)
                    {
                        LoadRulesInNewOrder(section, rulesArray, selectedIndex, upOrDown);
                    }
                    else
                    {
                        // DOWN button in last row was pressed. Load the rules array back in without resorting.
                        foreach (object t in rulesArray)
                        {
                            section.Rules.Add((AuthorizationRule)t);
                        }
                    }
                    break;
            }
            config.Save();
        }
        private void LoadRulesInNewOrder(AuthorizationSection section,
            ArrayList rulesArray, int selectedIndex, string upOrDown)
        {
            AddFirstGroupOfRules(section, rulesArray, selectedIndex, upOrDown);
            AddTheTwoSwappedRules(section, rulesArray, selectedIndex, upOrDown);
            AddFinalGroupOfRules(section, rulesArray, selectedIndex, upOrDown);
        }
        private void AddFirstGroupOfRules(AuthorizationSection section,
            ArrayList rulesArray, int selectedIndex, string upOrDown)
        {
            var adj = upOrDown == "up" ? 1 : 0;
            for (int x = 0; x < selectedIndex - adj; x++) section.Rules.Add((AuthorizationRule) rulesArray[x]);
        }

        private void AddTheTwoSwappedRules(AuthorizationSection section,
            ArrayList rulesArray, int selectedIndex, string upOrDown)
        {
            switch (upOrDown)
            {
                case "up":
                    section.Rules.Add((AuthorizationRule)rulesArray[selectedIndex]);
                    section.Rules.Add((AuthorizationRule)rulesArray[selectedIndex - 1]);
                    break;
                case "down":
                    section.Rules.Add((AuthorizationRule)rulesArray[selectedIndex + 1]);
                    section.Rules.Add((AuthorizationRule)rulesArray[selectedIndex]);
                    break;
            }
        }

        private void AddFinalGroupOfRules(AuthorizationSection section,
            ArrayList rulesArray, int selectedIndex, string upOrDown)
        {
            var adj = upOrDown == "up" ? 1 : 2;
            for (int x = selectedIndex + adj; x < rulesArray.Count; x++) section.Rules.Add((AuthorizationRule)rulesArray[x]);
        }

        private ArrayList PullLocalRulesOutOfAuthorizationSection(AuthorizationSection section)
        {
            // First load the local rules into an ArrayList.
            ArrayList rulesArray = new ArrayList();
            foreach (AuthorizationRule rule in section.Rules.Cast<AuthorizationRule>().Where(rule => rule.ElementInformation.IsPresent))
            {
                rulesArray.Add(rule);
            }

            // Next delete the rules from the section.
            foreach (AuthorizationRule rule in rulesArray)
                section.Rules.Remove(rule);
            return rulesArray;
        }

        public void CreateRule(object sender, EventArgs e)
        {
            AuthorizationRule newRule;
            newRule = ActionAllow.Checked ? new AuthorizationRule(AuthorizationRuleAction.Allow) : new AuthorizationRule(AuthorizationRuleAction.Deny);

            if (ApplyRole.Checked && UserRoles.SelectedIndex > 0)
            {
                newRule.Roles.Add(UserRoles.Text);
                AddRule(newRule);
            }
            else if (ApplyUser.Checked && UserList.SelectedIndex > 0)
            {
                newRule.Users.Add(UserList.Text);
                AddRule(newRule);
            }
            else if (ApplyAllUsers.Checked)
            {
                newRule.Users.Add("*");
                AddRule(newRule);
            }
            else if (ApplyAnonUser.Checked)
            {
                newRule.Users.Add("?");
                AddRule(newRule);
            }
        }

        private void AddRule(AuthorizationRule newRule)
        {
            string virtualFolderPath = FolderTree.SelectedValue;
            Configuration config = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath);
            SystemWebSectionGroup systemWeb = (SystemWebSectionGroup)config.GetSectionGroup("system.web");
            AuthorizationSection section = (AuthorizationSection)systemWeb.Sections["authorization"];
            section.Rules.Add(newRule);
            try
            {
                config.Save();
                RuleCreationError.Visible = false;
            }
            catch (Exception ex)
            {
                RuleCreationError.Visible = true;
                RuleCreationError.Text = "<div class=\"alert\"><br />An error occurred and the rule was not added. I saw this happen during testing when I attempted to create a rule that the ASP.NET infrastructure realized was redundant. Specifically, I had the rule <i>DENY ALL USERS</i> in one folder, then attempted to add the same rule in a subfolder, which caused ASP.NET to throw an exception.<br /><br />Here's the error message that was thrown just now:<br /><br /><i>" + ex.Message + "</i></div>";
            }
        }
    }
}