﻿using System;
using System.ComponentModel.DataAnnotations;
namespace ZonePostings.Models
{
    public class Posting
    {
        public enum RiskTiers
        {
            Minimal = 1,
            Low = 2,
            Moderate = 3,
            Dangerous = 4
        }

        public int Id { get; set; }

        public Posting()
        {
            Available = true;
        }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [Range(0, Int32.MaxValue)]
        [Required]
        public int Payout { get; set; }

        [Range(1, 4)]
        [Required]
        public int Risk {get;set;}

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Available { get; set; }

        
        public override string ToString()
        {
            return $"ID = {Id}; Payout = {Payout}; Risk = {Risk}; Title = {Title}; Description = {Description}; Available = {Available}";
        }
    }
}

