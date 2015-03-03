using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace portfolio.Admin.Access
{
    public partial class Active_Users : System.Web.UI.Page
    {
        private void Page_PreRender()
        {
            MembershipUserCollection allUsers = Membership.GetAllUsers();
            MembershipUserCollection filteredUsers = new MembershipUserCollection();
            var isActive = (active.SelectedValue == "Active");
            foreach (MembershipUser user in allUsers.Cast<MembershipUser>().Where(user => user.IsApproved == isActive))
            {
                filteredUsers.Add(user);
            }
            Users.DataSource = filteredUsers;
            Users.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}