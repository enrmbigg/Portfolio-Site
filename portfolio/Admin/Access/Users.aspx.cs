using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace portfolio.Admin.Access
{
    public partial class Users : System.Web.UI.Page
    {
        private void Page_PreRender()
        {
            UsersList.DataSource = Membership.GetAllUsers();
            UsersList.DataBind();
        }
    }
}