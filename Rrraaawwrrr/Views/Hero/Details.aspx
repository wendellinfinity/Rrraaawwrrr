<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Tuple<Rrraaawwrrr.Models.Hero, Rrraaawwrrr.Models.HeroAttributes>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Hero Detail</h2>
    <div>
        <fieldset>
            <legend>Hero Information</legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item1.HeroName) %></div>
            <div class="editor-field">
                <%: Html.Encode(Model.Item1.HeroName)%></div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item1.Class)%></div>
            <div class="editor-field">
                <%: Html.Encode(Model.Item1.Class)%></div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item1.Description)%></div>
            <div class="editor-field">
                <%: Html.Encode(Model.Item1.Description)%></div>
            <div class="display-label">
                <%: Html.LabelFor(m => m.Item2.Life) %></div>
            <div class="display-field">
                <%: Html.Encode(Model.Item2.Life) %></div>
            <div class="display-label">
                <%: Html.LabelFor(m => m.Item2.Strength) %></div>
            <div class="display-field">
                <%: Html.Encode(Model.Item2.Strength) %></div>
            <div class="display-label">
                <%: Html.LabelFor(m => m.Item2.Agility) %></div>
            <div class="display-field">
                <%: Html.Encode(Model.Item2.Agility) %></div>
            <div class="display-label">
                <%: Html.LabelFor(m => m.Item2.Intelligence) %></div>
            <div class="display-field">
                <%: Html.Encode(Model.Item2.Intelligence) %></div>
            <div class="display-label">
                <%: Html.LabelFor(m => m.Item2.Wisdom) %></div>
            <div class="display-field">
                <%: Html.Encode(Model.Item2.Wisdom) %></div>
            <div class="display-label">
                <%: Html.LabelFor(m => m.Item2.Charm) %></div>
            <div class="display-field">
                <%: Html.Encode(Model.Item2.Charm) %></div>
            <p>
                <input type="submit" value="Edit Hero" />
            </p>
        </fieldset>
    </div>
</asp:Content>
