using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using RoleList = System.Web.Security.Roles;

namespace portfolio.Admin.Access
{
    public partial class Access_Rule_Summary : System.Web.UI.Page
    {
        private const string VirtualImageRoot = "~/";
        private string _selectedRole, _selectedUser;

        private void Page_Init()
        {
            UserRoles.DataSource = RoleList.GetAllRoles();
            UserRoles.DataBind();

            UserList.DataSource = Membership.GetAllUsers();
            UserList.DataBind();

            FolderTree.Nodes.Clear();
        }

        private void Page_Load()
        {
            _selectedRole = UserRoles.SelectedValue;
            _selectedUser = UserList.SelectedValue;
        }

        private void Page_PreRender()
        {
        }

        private void PopulateTree(string byUserOrRole)
        {
            // Populate the tree based on the subfolders of the specified VirtualImageRoot
            DirectoryInfo rootFolder = new DirectoryInfo(Server.MapPath(VirtualImageRoot));
            TreeNode root = AddNodeAndDescendents(byUserOrRole, rootFolder, null);
            FolderTree.Nodes.Add(root);
        }

        private TreeNode AddNodeAndDescendents(string byUserOrRole, DirectoryInfo folder, TreeNode parentNode)
        {
            // Add the TreeNode, displaying the folder's name and storing the full path to the folder as the value...
            TreeNode node;
            string virtualFolderPath;
            if (parentNode == null)
            {
                virtualFolderPath = VirtualImageRoot;
            }
            else
            {
                virtualFolderPath = parentNode.Value + folder.Name + "/";
            }

            // Instantiate the objects that we'll use to check folder security on each tree node.
            Configuration config = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath);
            SystemWebSectionGroup systemWeb = (SystemWebSectionGroup)config.GetSectionGroup("system.web");
                AuthorizationSection section = (AuthorizationSection)systemWeb.Sections["authorization"];

                string action;
                switch (byUserOrRole)
                {
                    case "ByRole":
                        action = GetTheRuleForThisRole(section, virtualFolderPath);
                        break;
                    case "ByUser":
                        action = GetTheRuleForThisUser(section, virtualFolderPath);
                        break;
                    default:
                        action = "";
                        break;
                }

                //  This is where I wanna adjust the folder name.
                node = new TreeNode(folder.Name + " (" + action + ")", virtualFolderPath)
                {
                    ImageUrl = (action.Substring(0, 5) == "ALLOW") ? "~/Images/i/greenlight.gif" : "~/Images/i/redlight.gif",
                    NavigateUrl = "access_rules.aspx?selectedFolderName=" + folder.Name
                };

                // Recurse through this folder's subfolders
                DirectoryInfo[] subFolders = folder.GetDirectories();
                foreach (TreeNode child in from subFolder in subFolders where subFolder.Name != "App_Code" && subFolder.Name != "App_Data" select AddNodeAndDescendents(byUserOrRole, subFolder, node))
                {
                    node.ChildNodes.Add(child);
                }
                
            return node; // Return the new TreeNode
        }

        private string GetTheRuleForThisRole(AuthorizationSection section, string folder)
        {
            foreach (AuthorizationRule rule in section.Rules)
            {
                if (rule.Users.Cast<string>().All(user => user != "*"))
                {
                    foreach (string role in rule.Roles.Cast<string>().Where(role => role == _selectedRole))
                    {
                        return rule.Action.ToString().ToUpper() + ": Role=" + role;
                    }
                }
                else
                    return rule.Action.ToString().ToUpper() + ": All Users";
            }
            return "Allow";
        }

        private string GetTheRuleForThisUser(AuthorizationSection section, string folder)
        {
            foreach (AuthorizationRule rule in section.Rules)
            {
                foreach (string user in rule.Users)
                {
                    if (user == "*")
                        return rule.Action.ToString().ToUpper() + ": All Users";
                    if (user == _selectedUser)
                        return rule.Action.ToString().ToUpper() + ": User=" + user;
                }

                // Don't forget that users might belong to some roles!
                foreach (
                    string role in rule.Roles.Cast<string>().Where(role => RoleList.IsUserInRole(_selectedUser, role)))
                    return rule.Action.ToString().ToUpper() + ": Role=" + role;
            }
            return "ALLOW";
        }

        public void DisplayRoleSummary(object sender, EventArgs e)
        {
            FolderTree.Nodes.Clear();
            UserList.SelectedIndex = 0;
            if (UserRoles.SelectedIndex > 0)
            {
                PopulateTree("ByRole");
                FolderTree.ExpandAll();
            }
        }

        public void DisplayUserSummary(object sender, EventArgs e)
        {
            FolderTree.Nodes.Clear();
            UserRoles.SelectedIndex = 0;
            if (UserList.SelectedIndex > 0)
            {
                PopulateTree("ByUser");
                FolderTree.ExpandAll();
            }
        }

        public void DisplaySecuritySummary(object sender, TreeNodeEventArgs e)
        {
            e.Node.ShowCheckBox = true;
        }

        protected void FolderTree_SelectedNodeChanged(object sender, EventArgs e)
        {
        }
    }
}