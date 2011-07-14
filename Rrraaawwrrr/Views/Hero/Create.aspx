<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Tuple<Rrraaawwrrr.Models.Hero, Rrraaawwrrr.Models.HeroAttributes>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <h2>
        Create a New Hero</h2>
    <p>
        Welcome to the Dungeon. Go on and create your Hero.
    </p>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "You are making the Dungeon Master mad! Rooar!") %>
    <div>
        <fieldset>
            <legend>Hero Information</legend>
            <%: Html.HiddenFor(m => m.Item1.HeroId) %>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item1.HeroName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item1.HeroName)%>
                <%: Html.ValidationMessageFor(m => m.Item1.HeroName, "Are you a ghost?")%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item1.Class)%>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(m => m.Item1.Class, (IEnumerable<SelectListItem>)ViewData["HeroClasses"], new {width="100px" })%>
                <%: Html.ValidationMessageFor(m => m.Item1.Class, "What are ya?")%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item1.Description)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item1.Description)%>
                <%: Html.ValidationMessageFor(m => m.Item1.Description)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item2.Life) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item2.Life) %>
                <%: Html.ValidationMessageFor(m => m.Item2.Life) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item2.Strength) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item2.Strength) %>
                <%: Html.ValidationMessageFor(m => m.Item2.Strength) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item2.Agility) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item2.Agility) %>
                <%: Html.ValidationMessageFor(m => m.Item2.Agility) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item2.Intelligence) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item2.Intelligence) %>
                <%: Html.ValidationMessageFor(m => m.Item2.Intelligence) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item2.Wisdom) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item2.Wisdom) %>
                <%: Html.ValidationMessageFor(m => m.Item2.Wisdom) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Item2.Charm) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Item2.Charm) %>
                <%: Html.ValidationMessageFor(m => m.Item2.Charm) %>
            </div>
            <p>
                <input type="submit" value="Create Hero" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>
