using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rrraaawwrrr.Models
{

    [MetadataType(typeof(Hero_MetaData))]
    public partial class Hero
    {
    }

    [MetadataType(typeof(Hero_MetaData))]
    public class Hero_MetaData
    {
        [Required]
        [HiddenInput]
        public int HeroId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Hero Name")]
        public string HeroName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Hero Class")]
        public string Class { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Description")]
        public string Description { get; set; }

    }

    [MetadataType(typeof(HeroAttributes_MetaData))]
    public partial class HeroAttributes
    {
    }

    public class HeroAttributes_MetaData
    {
        [Required]
        [HiddenInput]
        public int HeroId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Life Stat")]
        [DefaultValue(0)]
        public int Life { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Strength Stat")]
        [DefaultValue(0)]
        public int Strength { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Agility Stat")]
        [DefaultValue(0)]
        public int Agility { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Intelligence Stat")]
        [DefaultValue(0)]
        public int Intelligence { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Wisdom Stat")]
        [DefaultValue(0)]
        public int Wisdom { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Charm Stat")]
        [DefaultValue(0)]
        public int Charm { get; set; }

    }

}