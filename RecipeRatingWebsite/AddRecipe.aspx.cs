using RecipeRatingWebsite.MyServices_ConnectionService;
using RecipeRatingWebsite.MyServices_RecipessService;
using System;

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
            var rs = new RecipesServiceSoapClient();
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