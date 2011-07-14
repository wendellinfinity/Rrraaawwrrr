<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Tuple<Rrraaawwrrr.Models.DungeonMap, Rrraaawwrrr.Models.DungeonMap>>" %>
<div class="firstpersonview">
    <div class="blank">
        #
    </div>
    <div>
    <% 
        RouteValueDictionary northMapRoute = new RouteValueDictionary();
        northMapRoute.Add("x", Model.Item1.X);
        northMapRoute.Add("y", Model.Item1.Y + 1);

        RouteValueDictionary southMapRoute = new RouteValueDictionary();
        southMapRoute.Add("x", Model.Item1.X);
        southMapRoute.Add("y", Model.Item1.Y - 1);

        RouteValueDictionary westMapRoute = new RouteValueDictionary();
        westMapRoute.Add("x", Model.Item1.X - 1);
        westMapRoute.Add("y", Model.Item1.Y);

        RouteValueDictionary eastMapRoute = new RouteValueDictionary();
        eastMapRoute.Add("x", Model.Item1.X + 1);
        eastMapRoute.Add("y", Model.Item1.Y);

    %>
    <%--<% if (Model.Item1.NorthGridId > 0) { %>--%>
    <% if (Model.Item1.Y + 1 < Rrraaawwrrr.Models.DungeonMap.MAXNORTH && Model.Item1.NorthFeature != Rrraaawwrrr.Models.DungeonMap.WALLCONST) { %>
    <%: Html.RouteLink("Go North?", "MapViewXY", northMapRoute)%><br />
    <% } %>
    <%: Html.Encode(Model.Item1.NorthFeature) %><br />
    <div class="sprite">
    <%: Rrraaawwrrr.Controllers.DungeonController.GetAsciiGraphic(Model.Item1.NorthFeature)%><br />
    </div>
    </div>
    <div class="blank">
        #
    </div>
    <br />
    <div>
    <%--<% if (Model.Item1.WestGridId > 0) { %>--%>
    <% if (Model.Item1.X - 1 > -1 && Model.Item1.WestFeature != Rrraaawwrrr.Models.DungeonMap.WALLCONST) { %>
    <%: Html.RouteLink("Go West?", "MapViewXY", westMapRoute)%><br />
    <% } %>
    <%: Html.Encode(Model.Item1.WestFeature) %><br />
    <div class="sprite">
    <%: Rrraaawwrrr.Controllers.DungeonController.GetAsciiGraphic(Model.Item1.WestFeature)%><br />
    </div>
    </div>
    <div class="location">
        You are at: <br />
        <%: Model.Item1.X %>, <%: Model.Item1.Y %> <br />
        Room Trapped?: <%: Model.Item1.IsTrapped %> <br />
        Is dark?: <%: Model.Item1.IsDark %> <br />
    </div>
    <div>
    <%--<% if (Model.Item1.EastGridId > 0) { %>--%>
    <% if (Model.Item1.X+1 < Rrraaawwrrr.Models.DungeonMap.MAXEAST && Model.Item1.EastFeature != Rrraaawwrrr.Models.DungeonMap.WALLCONST) { %>
    <%: Html.RouteLink("Go East?", "MapViewXY", eastMapRoute)%><br />
    <% } %>
    <%: Html.Encode(Model.Item1.EastFeature) %><br />
    <div class="sprite">
    <%: Rrraaawwrrr.Controllers.DungeonController.GetAsciiGraphic(Model.Item1.EastFeature)%><br />
    </div>
    </div>
    <br />
    <div class="blank">
        #
    </div>
    <div>
    <%--<% if (Model.Item1.SouthGridId > 0) { %>--%>
    <% if (Model.Item1.Y - 1 > Rrraaawwrrr.Models.DungeonMap.MAXSOUTH && Model.Item1.SouthFeature != Rrraaawwrrr.Models.DungeonMap.WALLCONST) { %>
    <%: Html.RouteLink("Go South?", "MapViewXY", southMapRoute)%><br />
    <% } %>
    <%: Html.Encode(Model.Item1.SouthFeature) %><br />
    <div class="sprite">
    <%: Rrraaawwrrr.Controllers.DungeonController.GetAsciiGraphic(Model.Item1.SouthFeature)%><br />
    </div>
    </div>
    <div class="blank">
        #
    </div>
</div>
