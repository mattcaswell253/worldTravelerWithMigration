using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorldTravelerWithMigration.Models
{
    [Table("Peoples")]
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
