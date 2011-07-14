using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Principal;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace Rrraaawwrrr.Controllers {
    public class DungeonController : Controller {
        private Services.IDungeonService _dungeonService;
        private Models.IFormsAuthenticationService FormsService { get; set; }
        private Models.IMembershipService MembershipService { get; set; }

        public static void InitializeRoutes(RouteCollection routes) {
            routes.MapRoute(
                "MapViewXY", // Route name
                "Map/{x}/{y}", // URL with parameters
                new { controller = "Dungeon", action = "Main" } // Parameter defaults
            );

            routes.MapRoute(
                "MapViewXYClient", // Route name
                "MapClient/{x}/{y}", // URL with parameters
                new { controller = "Dungeon", action = "ClientMain" } // Parameter defaults
            );

            routes.MapRoute(
                "CreateDungeon", // Route name
                "Map/Create", // URL with parameters
                new { controller = "Dungeon", action = "Create" } // Parameter defaults
            );

        }

        public static string GetAsciiGraphic(string feature) {
            System.Text.StringBuilder graphic;
            graphic = new System.Text.StringBuilder();
            switch (feature) {
                case Models.DungeonMap.DOORCONST:
                    GetDoorGraphic(graphic);
                    break;
                case Models.DungeonMap.WALLCONST:
                    GetWallGraphic(graphic);
                    break;
                case Models.DungeonMap.INTERSECTIONCONST:
                    GetIntersectionGraphic(graphic);
                    break;
                case Models.DungeonMap.HALLWAYCONST:
                    GetHallwayGraphic(graphic);
                    break;
            }
            return (graphic.ToString());
        }

        #region | Graphic |

        private static void GetHallwayGraphic(System.Text.StringBuilder graphic) {
            graphic.AppendLine(@"||\--------/|");
            graphic.AppendLine(@"|||\------/||");
            graphic.AppendLine(@"||||\----/|||");
            graphic.AppendLine(@"||||/----\|||");
            graphic.AppendLine(@"|||/------\||");
            graphic.AppendLine(@"||/--------\|");
        }

        private static void GetIntersectionGraphic(System.Text.StringBuilder graphic) {
            graphic.AppendLine(@"||\--------/|");
            graphic.AppendLine(@"|||\------/||");
            graphic.AppendLine(@"||||@@@@@@|||");
            graphic.AppendLine(@"||||@@@@@@|||");
            graphic.AppendLine(@"|||/------\||");
            graphic.AppendLine(@"||/--------\|");
        }

        private static void GetWallGraphic(System.Text.StringBuilder graphic) {
            graphic.AppendLine("-------------");
            graphic.AppendLine("-------------");
            graphic.AppendLine("-------------");
            graphic.AppendLine("-------------");
            graphic.AppendLine("-------------");
            graphic.AppendLine("-------------");
        }

        private static void GetDoorGraphic(System.Text.StringBuilder graphic) {
            graphic.AppendLine("-------------");
            graphic.AppendLine("---+######+--");
            graphic.AppendLine("---|#[==]#|--");
            graphic.AppendLine("---|######|--");
            graphic.AppendLine("---|o#####|--");
            graphic.AppendLine("---|######|--");
        }

        #endregion

        protected override void Initialize(RequestContext requestContext) {
            if (FormsService == null) { FormsService = new Models.FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new Models.AccountMembershipService(); }
            if (_dungeonService == null) {
                _dungeonService = new Services.DungeonService();
            }
            base.Initialize(requestContext);
        }

        public ActionResult Main(int x, int y) {
            Tuple<Models.DungeonMap, Models.DungeonMap> currentDungeon;
            Models.DungeonMap currentLocation;
            currentLocation = _dungeonService.GetMapLocation(x, y);
            currentDungeon = new Tuple<Models.DungeonMap, Models.DungeonMap>(currentLocation, null);
            return View(currentDungeon);
        }

        [HttpGet]
        public ActionResult ClientMain(int x, int y)
        {
            Tuple<Models.DungeonMapJson, Models.DungeonMapJson> currentDungeon;
            Models.DungeonMap currentLocation;
            currentLocation = _dungeonService.GetMapLocation(x, y);
            currentDungeon = new Tuple<Models.DungeonMapJson, Models.DungeonMapJson>(new Models.DungeonMapJson(currentLocation), null);
            return Json(currentDungeon,"text/plain",JsonRequestBehavior.AllowGet);
            /*
            return new JsonResult()
            {
                Data = currentDungeon,
                ContentType = "text/plain",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            */
        }

        public ActionResult Create() {
            // creates the entire dungeon
            //if (MembershipService.ValidateUser(model.UserName, model.Password)) {
            Models.DungeonMap zero;
            zero = _dungeonService.CreateMapLocation(0, 0, Services.Direction.ZERO);
            return new ContentResult() { Content = "Map has been created", ContentType = "text/plain" };
            //}
            //return new ContentResult() { Content = "You are not the dungeon master!", ContentType = "text/plain" };

        }

    }
}
