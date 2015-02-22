using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace portfolio.Admin.Access
{
    public partial class Roles : System.Web.UI.Page
    {
        private bool createRoleSuccess = true;

        private void Page_PreRender()
        {
            // Create a DataTable and define its columns
            DataTable RoleList = new DataTable();
            RoleList.Columns.Add("Role Name");
            RoleList.Columns.Add("User Count");

            string[] allRoles = System.Web.Security.Roles.GetAllRoles();

            // Get the list of roles in the system and how many users belong to each role
            foreach (string roleName in allRoles)
            {
                int numberOfUsersInRole = System.Web.Security.Roles.GetUsersInRole(roleName).Length;
                string[] roleRow = { roleName, numberOfUsersInRole.ToString() };
                RoleList.Rows.Add(roleRow);
            }

            // Bind the DataTable to the GridView
            UserRoles.DataSource = RoleList;
            UserRoles.DataBind();

            if (createRoleSuccess)
            {
                // Clears form field after a role was successfully added. Alternative to redirect technique I often use.
                NewRole.Text = "";
            }
        }

        public void AddRole(object sender, EventArgs e)
        {
            try
            {
                System.Web.Security.Roles.CreateRole(NewRole.Text);
                ConfirmationMessage.InnerText = "The new role was added.";
                createRoleSuccess = true;
            }
            catch (Exception ex)
            {
                ConfirmationMessage.InnerText = ex.Message;
                createRoleSuccess = false;
            }
        }

        public void DeleteRole(object sender, CommandEventArgs e)
        {
            try
            {
                System.Web.Security.Roles.DeleteRole(e.CommandArgument.ToString());
                ConfirmationMessage.InnerText = "Role '" + e.CommandArgument.ToString() + "' was deleted.";
            }
            catch (Exception ex)
            {
                ConfirmationMessage.InnerText = ex.Message;
            }
        }
    }
}