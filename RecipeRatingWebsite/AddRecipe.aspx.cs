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
    public partial class AddRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((UserRespondDto)Session["User"]) == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            TitleLt.Text = "Example meal";
            DescriptionLt.Text = "Example description, couple words about main theme of your meal";
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            RecipesService rs = new RecipesService();
            rs.Add(new RecipeAddRequestDto()
            {
                Title = TitleTextBox.Text,
                Description = DescriptionTextBox.Text,
                UrlImage = ImageUrlTextBox.Text,
                UserId = ((UserRespondDto)Session["User"]).Id
            });
        }
    }
}