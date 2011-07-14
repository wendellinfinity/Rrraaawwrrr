<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Tuple<Rrraaawwrrr.Models.DungeonMap, Rrraaawwrrr.Models.DungeonMap>>" %>
<script type="text/javascript">

    var doorFeature, wallFeature, intersectionFeature, hallwayFeature;
    $(document).ready(function () {
        $.ajax({
            url: "/MapClient/1/1",
            success: function (data) {
                alert(data);
                /*
                {
                    "Item1":
                    {
                        "GridId":69,
                        "IsDark":false,
                        "IsTrapped":false,
                        "NorthGridId":-1,
                        "SouthGridId":68,
                        "EastGridId":58,
                        "WestGridId":0,
                        "NorthFeature":"Wall",
                        "SouthFeature":"Wall",
                        "EastFeature":"Intersection",
                        "WestFeature":"Door"
                    },
                    "Item2":
                        null
                }
                */
            }
        });
    });

</script>
<div class="firstpersonview">
    <div class="blank">
        #
    </div>
    <div>
        <% if (Model.Item1.Y + 1 < Rrraaawwrrr.Models.DungeonMap.MAXNORTH && Model.Item1.NorthFeature != Rrraaawwrrr.Models.DungeonMap.WALLCONST) { %>
        <a href="GoNext(<%: Model.Item1.X %>, <%: Model.Item1.Y + 1 %>)">Go North?</a> 
        <% } %>
        <br />
        <div class="sprite" id="northSprite">
            SPRITE<br />
        </div>
    </div>
    <div class="blank">
        #
    </div>
    <br />
    <div>
        WEST<br />
        <div class="sprite" id="westSprite">
            SPRITE<br />
        </div>
    </div>
    <div class="location">
        ZERO
    </div>
    <div>
        EAST<br />
        <div class="sprite" id="eastSprite">
            SPRITE<br />
        </div>
    </div>
    <br />
    <div class="blank">
        #
    </div>
    <div>
        SOUTH<br />
        <div class="sprite" id="southSprite">
            SPRITE<br />
        </div>
    </div>
    <div class="blank">
        #
    </div>
</div>
