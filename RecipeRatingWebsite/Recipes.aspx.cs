using RecipeRatingWebsite.MyServices_ConnectionService;
using RecipeRatingWebsite.MyServices_RecipessService;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RecipeRatingWebsite
{
    public partial class Recipes : System.Web.UI.Page
    {
        public RecipeRespondDto[] RecipesList;
        public string StarUrl = "https://zaufane.pl/upload/filemanager/icons/star-filled-yellow.svg";
        public string UnratedStarUrl = "https://icons-for-free.com/download-icon-favorite+favourite+rating+star+icon-1320183290216374827_512.png";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (((UserRespondDto)Session["User"]) == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                var client = new RecipesServiceSoapClient();
                RecipeRespondDto[] respond = client.GetAllRecipes();

                RecipesList = respond;

                Repeater1.DataSource = RecipesList;
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument == null) return;

            var id = int.Parse(e.CommandArgument.ToString());

            // your logic here ...
        }

        public string GetStarImageUrl(object o)
        {
            if (Convert.ToInt32(o) == 0)
            {
                return UnratedStarUrl;
            }
            else
                return StarUrl;
        }

    }
}