using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ZonePostings.Models
{
    public class Player
    {
        public enum EquipmentTiers
        {
            Worn = 1,
            Alternative = 2,
            Modern = 3,
            Customized = 4
        }

        public enum HealthTiers
        {
            Unconconcious = 0,
            Dire = 1,
            Hurt = 2,
            Healthy = 3,
        }

        public Player()
        {
            Health = (int)HealthTiers.Healthy;
            Equipment = (int)EquipmentTiers.Worn;
            Name = "Strelok";
            AssignedPostings = new List<Posting>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, Int32.MaxValue)]
        [Required]
        //Amount of money the Player has earned so far
        public int Savings { get; set; }

        [Range(0, 3)]
        [Required]
        //How injured, or not injured, the player is
        public int Health { get; set; }

        [Range(1, 4)]
        //Equipment level of player
        public int Equipment { get; set; }

        public List<Posting> AssignedPostings { get; set; }
    }
}
