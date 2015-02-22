using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using RoleList = System.Web.Security.Roles;

namespace portfolio.Admin.Access
{
    public partial class Edit_User : System.Web.UI.Page
    {

        string username;

        MembershipUser user;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            if (string.IsNullOrEmpty(username))
            {
                Response.Redirect("users.aspx");
            }
            user = Membership.GetUser(username);
            UserUpdateMessage.Text = "";
        }

        protected void UserInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //Need to handle the update manually because MembershipUser does not have a
            //parameterless constructor  

            user.Email = (string)e.NewValues[0];
            user.Comment = (string)e.NewValues[1];
            user.IsApproved = (bool)e.NewValues[2];

            try
            {
                // Update user info:
                Membership.UpdateUser(user);

                // Update user roles:
                UpdateUserRoles();

                UserUpdateMessage.Text = "Update Successful.";

                e.Cancel = true;
                UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
            }
            catch (Exception ex)
            {
                UserUpdateMessage.Text = "Update Failed: " + ex.Message;

                e.Cancel = true;
                UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
            }
        }

        private void Page_PreRender()
        {
            // Load the User Roles into checkboxes.
            UserRoles.DataSource = RoleList.GetAllRoles();
            UserRoles.DataBind();

            // Disable checkboxes if appropriate:
            if (UserInfo.CurrentMode != DetailsViewMode.Edit)
            {
                foreach (ListItem checkbox in UserRoles.Items)
                {
                    checkbox.Enabled = false;
                }
            }

            // Bind these checkboxes to the User's own set of roles.
            string[] userRoles = RoleList.GetRolesForUser(username);
            foreach (ListItem checkbox in userRoles.Select(role => UserRoles.Items.FindByValue(role)))
            {
                checkbox.Selected = true;
            }
        }

        private void UpdateUserRoles()
        {
            foreach (ListItem rolebox in UserRoles.Items)
            {
                if (rolebox.Selected)
                {
                    if (!RoleList.IsUserInRole(username, rolebox.Text))
                    {
                        RoleList.AddUserToRole(username, rolebox.Text);
                    }
                }
                else
                {
                    if (RoleList.IsUserInRole(username, rolebox.Text))
                    {
                        RoleList.RemoveUserFromRole(username, rolebox.Text);
                    }
                }
            }
        }

        public void DeleteUser(object sender, EventArgs e)
        {
            Membership.DeleteUser(username, true); 
            Response.Redirect("users.aspx");
        }

        public void UnlockUser(object sender, EventArgs e)
        {
            // Unlock the user.
            user.UnlockUser();
            // DataBind the GridView to reflect same.
            UserInfo.DataBind();
        }
    }
}