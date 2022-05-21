using RecipeRatingWebsite.MyServices_ConnectionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipeRatingWebsite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {
            var cs = new ConnectionServiceSoapClient();
            RegisterResultDto respond = new RegisterResultDto();
            respond = cs.Register(new RegisterRequestDto()
            {
                UserName = LoginTextBox.Text,
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Text,
                SecurityQuestion = SecurityQuestionTextBox.Text,
                Answer = AnswerTextBox.Text,
                Name = NameTExtBox.Text,
                Birthday = DateTime.TryParse(BirthdayTextBox.Text, out DateTime bday)==true?bday:DateTime.Parse("1-01-0001"),
                GenderId = Int32.Parse(GenderDropdown.SelectedItem.Value)
            });

            Response.Write("<script>alert('" + respond + "')</script>");

            Response.Redirect("~/Default.aspx");
        }
    }
}