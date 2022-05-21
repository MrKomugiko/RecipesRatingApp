using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyServices;
using MyServices.ModelDTOs;

namespace RecipeRatingWebsite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (((UserRespondDto)Session["User"]) != null)
            {
                Response.Redirect("~/Recipes.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            ConnectionService cs = new ConnectionService();
            UserRespondDto user = cs.Login(new LoginRequestDto()
            {
                UserName = LoginTextBox.Text,
                Password = PasswordTextBox.Text
            });

            if(user != null)
            {
                Session["User"] = user;
                Response.Redirect("~/Recipes.aspx");
            }
            Response.Write("<script>alert('"+ user + "')</script>");
        }
    }
}