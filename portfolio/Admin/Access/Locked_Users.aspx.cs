using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace portfolio.Admin.Access
{
    public partial class Locked_Users : System.Web.UI.Page
    {
        public void Page_PreRender()
        {
            MembershipUserCollection allUsers = Membership.GetAllUsers();
            MembershipUserCollection filteredUsers = new MembershipUserCollection();
            if (allUsers != null)
            {
                foreach (MembershipUser user in allUsers.Cast<MembershipUser>().Where(user => user.IsLockedOut))
                {
                    filteredUsers.Add(user);
                }
                if (filteredUsers.Count == 0)
                {
                    lblResult.Text = "There are no Locked Users";
                }
                Users.DataSource = filteredUsers;
                Users.DataBind();
            }
            else
            {
                lblResult.Text = "There are no Users";
            }
        }
    }
}