<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

    </script>
    <h2>
       <% 
        RouteValueDictionary zero = new RouteValueDictionary();
        zero.Add("x", 0);
        zero.Add("y", 0);
       %>

        <%: ViewData["Message"] %></h2>
    <h3>
        <%: Html.RouteLink("Create the Friggin Map!", "CreateDungeon")%></h3>

        <div style="text-align:center;">
            <h1>
        <%: Html.RouteLink("Enter", "MapViewXY", zero)%></h1>
        </div>
</asp:Content>
