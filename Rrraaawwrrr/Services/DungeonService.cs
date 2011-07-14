using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rrraaawwrrr.Services {

    public enum Direction {
        NORTH,
        SOUTH,
        EAST,
        WEST,
        ZERO
    }

    public interface IDungeonService {
        Models.DungeonMap GetMapLocation(int x, int y);
        Models.DungeonMap CreateMapLocation(int targetX, int targetY, Direction traversal);
        IEnumerable<Models.DungeonMap> GetAdjacentsOnly(int x, int y);
    }

    public class DungeonService : IDungeonService {
        private Models.DungeonDataContainer _dungeonContainer;

        public DungeonService() {
            _dungeonContainer = new Models.DungeonDataContainer();
        }

        public Models.DungeonMap GetMapLocation(int x, int y) {
            Models.DungeonMap location;
            var re = _dungeonContainer.DungeonMaps.Single(l => l.X == x && l.Y == y);
            if (re != null) {
                location = (Models.DungeonMap)re;
                return (location);
            }
            return (null);
        }

        public IEnumerable<Models.DungeonMap> GetAdjacentsOnly(int x, int y) {
            IEnumerable<Models.DungeonMap> adjacents;
            var result = from l in _dungeonContainer.DungeonMaps
                         where (l.X == x && l.Y == y + 1) // north
                            || (l.X == x && l.Y == y - 1) // south
                            || (l.X == x + 1 && l.Y == y) // east
                            || (l.X == x - 1 && l.Y == y) // west
                         select l;
            if (result != null && result.Count<Models.DungeonMap>() > 0) {
                adjacents = (IEnumerable<Models.DungeonMap>)result;
                return (adjacents);
            }
            return (new List<Models.DungeonMap>());
        }

        private string GetRandomFeature() {
            int rand = (((int)Guid.NewGuid().ToByteArray()[3]) % 3);
            switch (rand) {
                case 0:
                    return (Models.DungeonMap.HALLWAYCONST);
                case 1:
                    return (Models.DungeonMap.DOORCONST);
                case 2:
                    return (Models.DungeonMap.INTERSECTIONCONST);
                case 3:
                    return (Models.DungeonMap.WALLCONST);
            }
            return (Models.DungeonMap.WALLCONST);
        }

        /// <summary>
        /// Creates a map location and recurses until the max is reached
        /// </summary>
        /// <param name="targetX"></param>
        /// <param name="targetY"></param>
        /// <returns></returns>
        public Models.DungeonMap CreateMapLocation(int targetX, int targetY, Direction traversal) {
            if (!(targetX < Models.DungeonMap.MAXEAST && targetX > Models.DungeonMap.MAXWEST
                && targetY < Models.DungeonMap.MAXNORTH && targetY > Models.DungeonMap.MAXSOUTH
                && !(traversal != Direction.ZERO && targetX == 0 && targetY == 0))) {
                // reached bounds
                return (null);
            }
            Models.DungeonMap newLocation, adjacentNorth = null, adjacentSouth = null, adjacentWest = null, adjacentEast = null;
            //checkExist = GetMapLocation(targetX, targetY);
            //if (checkExist != null) {
            //    return (checkExist);
            //}
            IEnumerable<Models.DungeonMap> targetAdjacents;
            newLocation = new Models.DungeonMap() {
                IsDark = false,
                IsTrapped = false,
                X = targetX,
                Y = targetY,
                NorthFeature = GetRandomFeature(),
                SouthFeature = GetRandomFeature(),
                EastFeature = GetRandomFeature(),
                WestFeature = GetRandomFeature()
            };
            // get north
            targetAdjacents = GetAdjacentsOnly(targetX, targetY);
            if (targetAdjacents.Count<Models.DungeonMap>(m => m.X == targetX && m.Y == targetY + 1) > 0) {
                adjacentNorth = targetAdjacents.Single<Models.DungeonMap>(m => m.X == targetX && m.Y == targetY + 1);
            } else {
                if (traversal != Direction.SOUTH) {
                    adjacentNorth = CreateMapLocation(targetX, targetY + 1, Direction.NORTH);
                    targetAdjacents = GetAdjacentsOnly(targetX, targetY);
                    if (targetY + 1 < Models.DungeonMap.MAXNORTH) {
                        adjacentNorth = GetMapLocation(targetX, targetY + 1);
                    }
                }
            }
            if (adjacentNorth != null) {
                newLocation.NorthFeature = adjacentNorth.SouthFeature;
                newLocation.NorthGridId = adjacentNorth.GridId;
            } else {
                newLocation.NorthFeature = Models.DungeonMap.WALLCONST;
                newLocation.NorthGridId = -1;
            }

            // get south
            if (targetAdjacents.Count<Models.DungeonMap>(m => m.X == targetX && m.Y == targetY - 1) > 0) {
                adjacentSouth = targetAdjacents.Single<Models.DungeonMap>(m => m.X == targetX && m.Y == targetY - 1);
            } else {
                if (traversal != Direction.NORTH) {
                    adjacentSouth = CreateMapLocation(targetX, targetY - 1, Direction.SOUTH);
                    targetAdjacents = GetAdjacentsOnly(targetX, targetY);
                    if (targetY - 1 > Models.DungeonMap.MAXSOUTH) {
                        adjacentSouth = GetMapLocation(targetX, targetY - 1);
                    }
                }
            }
            if (adjacentSouth != null) {
                newLocation.SouthFeature = adjacentSouth.NorthFeature;
                newLocation.SouthGridId = adjacentSouth.GridId;
            } else {
                newLocation.SouthFeature = Models.DungeonMap.WALLCONST;
                newLocation.SouthGridId = -1;
            }

            // get east
            if (targetAdjacents.Count<Models.DungeonMap>(m => m.X == targetX + 1 && m.Y == targetY) > 0) {
                adjacentEast = targetAdjacents.Single<Models.DungeonMap>(m => m.X == targetX + 1 && m.Y == targetY);
            } else {
                if (traversal != Direction.WEST) {
                    adjacentEast = CreateMapLocation(targetX + 1, targetY, Direction.EAST);
                    targetAdjacents = GetAdjacentsOnly(targetX, targetY);
                    if (targetX + 1 < Models.DungeonMap.MAXEAST) {
                        adjacentEast = GetMapLocation(targetX + 1, targetY);
                    }
                }
            }
            if (adjacentEast != null) {
                newLocation.EastFeature = adjacentEast.WestFeature;
                newLocation.EastGridId = adjacentEast.GridId;
            } else {
                newLocation.EastFeature = Models.DungeonMap.WALLCONST;
                newLocation.EastGridId = -1;
            }

            
            // get west
            /*
            if (targetX-1 < 0) {
                if (targetAdjacents.Count<Models.DungeonMap>(m => m.X == targetX - 1 && m.Y == targetY) > 0) {
                    adjacentWest = targetAdjacents.Single<Models.DungeonMap>(m => m.X == targetX - 1 && m.Y == targetY);
                } else {
                    if (traversal != Direction.EAST) {
                        adjacentWest = CreateMapLocation(targetX - 1, targetY, Direction.WEST);
                        targetAdjacents = GetAdjacentsOnly(targetX, targetY);
                        if (targetX - 1 > Models.DungeonMap.MAXWEST) {
                            adjacentWest = GetMapLocation(targetX - 1, targetY);
                        }
                    }
                }
                if (adjacentWest != null) {
                    newLocation.WestFeature = adjacentWest.EastFeature;
                    newLocation.WestGridId = adjacentWest.GridId;
                } else {
                    newLocation.WestFeature = Models.DungeonMap.WALLCONST;
                    newLocation.WestGridId = -1;
                }
            }
             */
            // save the location
            _dungeonContainer.DungeonMaps.AddObject(newLocation);
            _dungeonContainer.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            return (newLocation); // return the location
        }

    }

}