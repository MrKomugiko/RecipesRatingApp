<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RecipeRatingWebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>Recipes Rating Website</h1>
        <p class="lead">best website ;d</p>
    </div>

    <div class="row">
        <div class="col-md-4"> </div>
        <div class="col-md-4">
            <div class="forn-group"> 
                <asp:TextBox runat="server" Id="LoginTextBox" 
                    CssClass="form-control input" 
                    placeholder="UserName" ></asp:TextBox>
                
                 <asp:RequiredFieldValidator
                    ControlToValidate="LoginTextBox"
                    Display="Static"
                    ErrorMessage="UserName is required."
                    ID="rfvUserName"
                    style="color:red;"
                    RunAt="Server"/>

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

                 <div class="forn-group-inline" style="margin-bottom:1rem;"> 
                    <asp:Button runat="server" ID="LoginBtn" 
                        CssClass="btn btn-primary" 
                        Text="Login" 
                        OnClick="LoginBtn_Click" />

                    <a runat="server" 
                        type="button"
                        href="~/Register"
                        CssClass="btn btn-outline-primary m-1" >Register</a>

                </div>
            </div>
        </div>
        <div class="col-md-4"> </div>
    </div>

</asp:Content>
