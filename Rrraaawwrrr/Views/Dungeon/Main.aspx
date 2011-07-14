<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Tuple<Rrraaawwrrr.Models.DungeonMap, Rrraaawwrrr.Models.DungeonMap>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Main</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        You are in the Dungeon</h2>
    <%--<% Html.RenderPartial("View", Model); %>--%>
    <% Html.RenderPartial("FastView", Model); %>
</asp:Content>
