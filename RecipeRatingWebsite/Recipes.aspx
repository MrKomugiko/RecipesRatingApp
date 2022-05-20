<%@Page Title="Recipes Homepage" Language="C#" AutoEventWireup="true" CodeBehind="Recipes.aspx.cs" Inherits="RecipeRatingWebsite.Recipes" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-group">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="card m-1">
                    <img class="card-img-top" src="<%# Eval("UrlImage") %>" style="height:12rem;" alt="Card image cap">
                    <div class="card-body d-flex flex-column p-2">
                        <h5 class="card-title"><%# Eval("Title") %></h5>
                        <p class="card-text"><%# Eval("Description") %></p>
                        <div class="container row mt-auto">
                            <div class="col-7 mt-auto ml-auto mb-auto">
                                <div class="row">
                                    <img src="<%# GetStarImageUrl(Eval("TotalVotes")) %>" class="col-3 p-0">
                                    <div class="col mt-auto mb-auto" style="vertical-align:middle;">
                                        <h5 class="row m-0" style="font-weight:bold;"> <%# Eval("AvgRating") %></h5>
                                        <h6 class="row m-0" style="font-weight:100; font-size:0.85em;"> (<%# Eval("TotalVotes") %> votes)</h6>
                                    </div>
                                </div>
                            </div>
                            <asp:Button CssClass="col-4 btn btn-primary w-50" runat="server" CommandArgument='<%# Eval("ID") %>' Text="Details" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
      </div>
</asp:Content>  