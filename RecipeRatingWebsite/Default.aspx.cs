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
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            ConnectionService cs = new ConnectionService();
            bool respond = cs.Login(new LoginRequestDto()
            {
                UserName = LoginTextBox.Text,
                Password = PasswordTextBox.Text
            });

            if(respond)
            {
                Session["User"]=LoginTextBox.Text;
                Response.Redirect("~/Recipes.aspx");
            }
            Response.Write("<script>alert('"+ respond + "')</script>");
        }
    }
}