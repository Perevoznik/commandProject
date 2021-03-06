﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Models
{
    public class AddressDTO
    {
        [Key]
        public int AddressId { get; set; }

        public int StreetId { get; set; }
        public string StreetName { get; set; }
        public int SubdivisionId { get; set; }
        public string SubdivisionName { get; set; }

        [Required]
        [StringLength(12)]
        public string House { get; set; }

        [StringLength(24)]
        public string Serial { get; set; }

        public int? СountFloor { get; set; }

        public int? СountEntrance { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
