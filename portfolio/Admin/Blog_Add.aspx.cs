﻿using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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

            foreach (var imageName in images.Select(image => image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1)))
            {
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
                var filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Images/Blog/") + filename);
                lblResult.Text = "Image " + filename + " Succesfully Uploaded!";
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
                string image = ddlImage.SelectedValue;
                string date = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                string tag = txtTag.Text;

                BlogPosts blog = new BlogPosts(title, body, image, date, tag);
                ConnectionClass.AddBlog(blog);
                BlogPosts post  = ConnectionClass.GetPostByTitle(title,"DESC");
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