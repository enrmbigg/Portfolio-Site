using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace portfolio.Blog
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void FillPage()
        {
            ArrayList postList = new ArrayList();
            postList = ConnectionClass.GetAll();
            StringBuilder sb = new StringBuilder();

            foreach (BlogPosts post in postList)
            {
                sb.Append(
                    string.Format(
                        @"<table class='coffeeTable'>
            <tr>
                
                <th rowspan='6' width='150px'><div class ='halfSize'><img runat='server' src='{2}' /></div></th>
                <th width='50px'>Title: </td>
                <td>{0}</td>
            </tr>

            <tr>
                <th>Body: </th>
                <td>{1}</td>
            </tr>

            <tr>
                <th>Date: </th>
                <td>{3}</td>
            </tr>          
            
           </table>",
                        post.title, post.body, post.image, post.date));

                lblOutput.Text = sb.ToString();

            }


        }

        protected void BulletedList1_Load(object sender, EventArgs e)
        {
            FillPage();
        }
    }
}