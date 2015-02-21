using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace portfolio.Admin
{
    public partial class Blog_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedValue = ddlImage.SelectedValue;
            ShowImages();
            ddlImage.SelectedValue = selectedValue;
        }
        private void ShowImages()
        {
            //Get all filepaths
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/Blog/"));

            //Get all filenames and add them to an arraylist
            ArrayList imageList = new ArrayList();

            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
                imageList.Add(imageName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlImage.DataSource = imageList;
            ddlImage.DataBind();
        }
        private void ClearTextFields()
        {
            txtTitle.Text = "";
            txtBody.Text = "";
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Images/Blog/") + filename);
                lblResult.Text = "Image " + filename + " succesfully uploaded!";
                Page_Load(sender, e);
            }
            catch (Exception)
            {
                lblResult.Text = "Upload failed!";
            }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                string body = txtBody.Text;
                string image = "../Images/Blog/" + ddlImage.SelectedValue;
                string date = DateTime.Now.ToString();

                BlogPosts blog = new BlogPosts(title, body, image, date);
                ConnectionClass.AddBlog(blog);
                lblResult.Text = "Upload succesful!";
                ClearTextFields();
            }
            catch (Exception)
            {
                lblResult.Text = "Upload failed!";
            }
        }
    }
}