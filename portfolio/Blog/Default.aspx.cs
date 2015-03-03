﻿using System;
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
            FillPage();
        }

        private void FillPage()
        {
            var postList = ConnectionClass.GetAllPosts();
            ArrayList commentList;
            StringBuilder sb = new StringBuilder();

            foreach (BlogPosts post in postList)
            {
                commentList = ConnectionClass.GetAllComments(post.Id);

                sb.Append(
                    string.Format(
                        @"  <section class='post'>
                    <header class='post-header'>
                        <h2 class='post-title'>{0}</h2>
                        <p class='post-meta'>
                            <a class='post-category post-category-js' href='#'>{3}</a>
                        </p>
                    </header>
                    <div class='post-description'>
                        <div class='post-images pure-g'>
                            <div class='pure-u-1 pure-u-md-1-2'>
                                <img alt='{0}' class='pure-img-responsive' src='{2}'>
                                <div class='post-image-meta'>
                                    <h3>{0}</h3>
                                </div>
                            </div>
                        </div>
                        <p>
                            {1}
                        </p>
                    </div>
                </section><h1 class='content-subhead'></h1>",
                        post.Title, post.Body, post.Image, post.Date));
                foreach (Comments comment in commentList)
                {
                    sb.Append(
                        string.Format("{0}",comment.Comment));
                }

                lblOutput.Text = sb.ToString();
            }
        }
    }
}