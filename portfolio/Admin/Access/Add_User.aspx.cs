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
    public partial class Add_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    AddUser();

                    Response.Redirect("users.aspx");
                }
                catch (Exception ex)
                {
                    ConfirmationMessage.InnerText = "Insert Failure: " + ex.Message;
                }
            }
        }

        protected void AddUser()
        {
            // Add User.
            MembershipUser newUser = Membership.CreateUser(username.Text, password.Text, email.Text);
            newUser.Comment = comment.Text;
            Membership.UpdateUser(newUser);

            // Add Roles.
            foreach (ListItem rolebox in UserRoles.Items)
            {
                if (rolebox.Selected)
                {
                    RoleList.AddUserToRole(username.Text, rolebox.Text);
                }
            }
        }

        private void Page_PreRender()
        {
            UserRoles.DataSource = RoleList.GetAllRoles();
            UserRoles.DataBind();
        }
    }
}