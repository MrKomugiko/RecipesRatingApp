using MyServices;
using MyServices.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeRatingWebsite
{
    public partial class Recipes : System.Web.UI.Page
    {
        public List<RecipeRespondDto> RecipesList = new List<RecipeRespondDto>();
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
                RecipesService rs = new RecipesService();
                List<RecipeRespondDto> respond = rs.GetAllRecipes();

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