﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldTravelerWithMigration.Models
{
    [Table("Experiences")]
    public class Experience
    {
        public Experience()
        {
            this.Peoples = new HashSet<People>();
        }
        [Key]
        public int ExperienceId { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<People> Peoples { get; set; }
    }
}