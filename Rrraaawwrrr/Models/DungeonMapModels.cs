using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rrraaawwrrr.Models
{
    [MetadataType(typeof(DungeonMap_MetaData))]
    public partial class DungeonMap
    {
        public const int MAXNORTH = 5;
        public const int MAXSOUTH = -5;
        public const int MAXEAST = 5;
        public const int MAXWEST = -5;
        public const string WALLCONST = "Wall";
        public const string DOORCONST = "Door";
        public const string INTERSECTIONCONST = "Intersection";
        public const string HALLWAYCONST = "Hallway";
    }

    public class DungeonMapJson
    {
        public Int64 GridId { get; set; }
        public bool IsDark { get; set; }
        public bool IsTrapped { get; set; }
        public Int64 NorthGridId { get; set; }
        public Int64 SouthGridId { get; set; }
        public Int64 EastGridId { get; set; }
        public Int64 WestGridId { get; set; }
        public string NorthFeature { get; set; }
        public string SouthFeature { get; set; }
        public string EastFeature { get; set; }
        public string WestFeature { get; set; }

        public DungeonMapJson(DungeonMap location) 
        {
            this.GridId = location.GridId;
            this.IsDark = location.IsDark;
            this.IsTrapped = location.IsTrapped;
            this.NorthGridId = location.NorthGridId;
            this.SouthGridId = location.SouthGridId;
            this.EastGridId = location.EastGridId;
            this.WestGridId = location.WestGridId;
            this.NorthFeature = location.NorthFeature;
            this.SouthFeature = location.SouthFeature;
            this.EastFeature = location.EastFeature;
            this.WestFeature = location.WestFeature;
        }

    }

    public class DungeonMap_MetaData
    {
        public Int64 GridId { get; set; }
        public bool IsDark { get; set; }
        public bool IsTrapped { get; set; }
        public Int64 NorthGridId { get; set; }
        public Int64 SouthGridId { get; set; }
        public Int64 EastGridId { get; set; }
        public Int64 WestGridId { get; set; }
        [ReadOnly(true)]
        [DataType(DataType.Text)]
        [DisplayName("@North")]
        public string NorthFeature { get; set; }
        [ReadOnly(true)]
        [DataType(DataType.Text)]
        [DisplayName("@South")]
        public string SouthFeature { get; set; }
        [ReadOnly(true)]
        [DataType(DataType.Text)]
        [DisplayName("@East")]
        public string EastFeature { get; set; }
        [ReadOnly(true)]
        [DataType(DataType.Text)]
        [DisplayName("@West")]
        public string WestFeature { get; set; }
    }

}