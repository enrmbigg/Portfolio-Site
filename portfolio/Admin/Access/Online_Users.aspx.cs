using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace portfolio.Admin.Access
{
    public partial class Online_Users : System.Web.UI.Page
    {
        private void Page_PreRender()
        {
            MembershipUserCollection allUsers = Membership.GetAllUsers();
            MembershipUserCollection filteredUsers = new MembershipUserCollection();
            foreach (MembershipUser user in allUsers.Cast<MembershipUser>().Where(user => user.IsOnline))
            {
                filteredUsers.Add(user);
            }
            Users.DataSource = filteredUsers;
            Users.DataBind();
        }
    }
}