<%@Page Title="Add Recipe" Language="C#" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="RecipeRatingWebsite.AddRecipe" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="col-md-8 ml-auto mr-auto mt-3">
        <div class="row">
            <div class="col-6 mt-auto mb-auto">
                <div class="forn-group"> 
                    <asp:TextBox runat="server" Id="TitleTextBox" 
                        onkeyup="Preview(this,'Title')"
                        CssClass="form-control input" 
                        placeholder="Title" ></asp:TextBox>
                
                    <asp:RequiredFieldValidator
                        ControlToValidate="TitleTextBox"
                        Display="Static"
                        ErrorMessage="Title is required."
                        ID="rtfTitle"
                        style="color:red;"
                        RunAt="Server" />

                    <asp:Textbox runat="server" Id="DescriptionTextBox" 
                        onkeyup="Preview(this,'Description')"
                        TextMode="MultiLine"
                        CssClass="form-control textarea input" 
                        placeholder="Description" ></asp:Textbox>
                
                    <asp:RequiredFieldValidator
                        ControlToValidate="DescriptionTextBox"
                        Display="Static"
                        ErrorMessage="Description is required."
                        ID="rfvDescription"
                        style="color:red;"
                        RunAt="Server" />

                    <asp:TextBox runat="server" Id="ImageUrlTextBox" 
                        onkeyup="Preview(this,'Image')"
                        CssClass="form-control input"  
                        placeholder="Image url" ></asp:TextBox>
                    <br />
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="form-control btn btn-outline-primary col-4" />
                </div>
            </div>
            <div class="col-6 text-center">
               <div> Preview: </div>
                <div class="card col-3">
                    <asp:Image ID="Image" runat="server" CssClass="card-img-top" style="height:12rem;" alt="Card image cap" ImageUrl="https://trimurl.co/JYKFkn"/>
                    <div class="card-body d-flex flex-column p-2">
                        <h5 id="Title" class="card-title"><asp:Literal runat="server" Id="TitleLt"></asp:Literal></h5>
                        <p id="Description" class="card-text"><asp:Literal runat="server" Id="DescriptionLt"></asp:Literal></p>
                        <div class="container row mt-auto">
                            <div class="col-7 mt-auto ml-auto mb-auto">
                                <div class="row">
                                    <img src="https://zaufane.pl/upload/filemanager/icons/star-filled-yellow.svg" class="col-3 p-0">
                                    <div class="col mt-auto mb-auto" style="vertical-align:middle;">
                                        <h5 class="row m-0" style="font-weight:bold;"> 4,50 </h5>
                                        <h6 class="row m-0" style="font-weight:100; font-size:0.85em;"> (40 votes)</h6>
                                    </div>
                                </div>
                            </div>
                            <input type="submit" name="ctl00$MainContent$Repeater1$ctl00$ctl00" value="Details" class="col-4 btn btn-primary w-50">
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script type="text/javascript">

        function Preview(textbox, destination) {
            switch (destination) {
                case 'Title': document.getElementById(destination).textContent = textbox.value; break;
                case 'Description': document.getElementById(destination).textContent = textbox.value; break;
                case 'Image': document.getElementById('MainContent_'+destination).src = textbox.value; break;
            }
        }

    </script>

</asp:Content>  