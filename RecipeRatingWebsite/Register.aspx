<%@ Page Title="REgister" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Register.aspx.cs" Inherits="RecipeRatingWebsite.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="row text-center pb-4">
        <div class="col-md-4"></div>
        <h1 class="col-md-4" style="padding-bottom:4rem;">Register</h1>
        <div class="col-md-4"></div>
   </div>
    <div class="row">
        <div class="col-md-2"> </div>
        <div class="col-md-4">
            <div class="forn-group"> 
                <p><b>Account Details:</b> <small>(required)</small></p>

                 <asp:TextBox runat="server" Id="EmailTextBox" 
                    CssClass="form-control input" 
                    placeholder="Email" ></asp:TextBox>
                
                 <asp:RequiredFieldValidator
                    ControlToValidate="EmailTextBox"
                    Display="Static"
                    ErrorMessage="Email is required."
                    ID="RequiredFieldValidator1"
                    style="color:red;"
                    RunAt="Server" />

                <asp:TextBox runat="server" Id="LoginTextBox" 
                    CssClass="form-control input" 
                    placeholder="UserName" ></asp:TextBox>
                
                 <asp:RequiredFieldValidator
                    ControlToValidate="LoginTextBox"
                    Display="Static"
                    ErrorMessage="UserName is required."
                    ID="rfvUserName"
                    style="color:red;"
                    RunAt="Server" />

                <asp:TextBox runat="server" Id="PasswordTextBox" 
                    type="password" 
                    CssClass="form-control input"  
                    placeholder="**********" ></asp:TextBox>
                 
                <asp:RequiredFieldValidator
                    ControlToValidate="PasswordTextBox"
                    Display="Static"
                    ErrorMessage="Password is required."
                    ID="rfcPassword"
                    style="color:red;"
                    RunAt="Server" />
                
                    <p><b>Password reminder: </b> <small>(required)</small></p>
                 <asp:TextBox runat="server" Id="SecurityQuestionTextBox" 
                        CssClass="form-control input" 
                        placeholder="Security Question"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ControlToValidate="SecurityQuestionTextBox"
                    Display="Static"
                    ErrorMessage="Security Question is required."
                    ID="rfvSecurityQuestion"
                    style="color:red;"
                    RunAt="Server" />
            
                <asp:TextBox runat="server" Id="AnswerTextBox" 
                    CssClass="form-control input" 
                    placeholder="Answer" ></asp:TextBox>
                
                <asp:RequiredFieldValidator
                    ControlToValidate="AnswerTextBox"
                    Display="Static"
                    ErrorMessage="Answer for a Question is required."
                    ID="rfvAnswer"
                    style="color:red;"
                    RunAt="Server" />
            </div>
        </div>


        <div class="col-md-4 mt-2">
            <div class="forn-group"> 
                <p><b>Personal:</b> <small>(optional)</small></p>
                <asp:Label runat="server" Id="NameLabel"> First Name:</asp:Label>
                <asp:TextBox runat="server" Id="NameTExtBox" 
                    CssClass="form-control input" 
                    style="margin-bottom:1em;"
                    placeholder="Name" ></asp:TextBox>

                <asp:Label runat="server" Id="BirthdayLabel">Birthday:</asp:Label>
                <asp:TextBox runat="server" Id="BirthdayTextBox" 
                    type="date"
                    CssClass="form-control input" 
                    style="margin-bottom:1em;"
                    placeholder="Name" ></asp:TextBox>

                <asp:Label runat="server" Id="GenderLabel">What is your gender?:</asp:Label> <br />
                <asp:DropDownList ID="GenderDropdown" runat="server" CssClass="form-control" >  
                    <asp:ListItem Value="0" CssStyle="dropdown-menu" >I prefer not to say</asp:ListItem>  
                    <asp:ListItem Value="1" CssStyle="dropdown-menu" >Male</asp:ListItem>  
                    <asp:ListItem Value="2" CssStyle="dropdown-menu" >Female</asp:ListItem>  
                </asp:DropDownList>  
            </div>
        </div>
        <div class="col-md-3"> </div>
    </div>
    <div class="row text-center">
        <div class="col-md-5"></div>
        <asp:Button runat="server" ID="ConfirmBtn" 
            CssClass="btn btn-success col-md-2" 
            OnClick="ConfirmBtn_Click"
            Text="Confirm"/>
        <div class="col-md-5"></div>
    </div>
</asp:Content>