<%@Page Title="Recipes Homepage" Language="C#" AutoEventWireup="true" CodeBehind="Recipes.aspx.cs" Inherits="RecipeRatingWebsite.Recipes" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="col-6 col-sm-4 col-md-3 pb-2">
                    <div class="card m-1 h-100">
                        <img class="card-img-top" src="<%# Eval("UrlImage") %>" style="height:12rem;" alt="Card image cap">
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%# Eval("Title") %></h5>
                            <p class="card-text"><%# Eval("Description") %></p>
                            <div class="row mt-auto">
                                <div class="col-sm-12 col-md-7 mt-auto mb-auto ml-2">
                                    <div class="row">
                                        <img src="<%# GetStarImageUrl(Eval("TotalVotes")) %>" CssClass="col p-0" style="min-width:1rem; max-width:2rem; min-height:1rem; max-height:2rem;"> 
                                        <div class="col mt-auto mb-auto" style="vertical-align:middle;">
                                            <h5 class="row m-0" style="font-weight:bold;"> <%# Eval("AvgRating") %></h5>
                                            <h6 class="row m-0" style="font-weight:100; font-size:0.85em;"> (<%# Eval("TotalVotes") %> votes)</h6>
                                        </div>
                                    </div>
                                </div>
                                <asp:Button CssClass="col-12 col-md-4 btn btn-primary" runat="server" CommandArgument='<%# Eval("ID") %>' Text="Details" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
      </div>
</asp:Content>  
 