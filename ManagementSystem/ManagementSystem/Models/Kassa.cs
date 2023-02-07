using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Models
{
    public class Kassa
    {
        public int Id { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string LastModifiedCause { get; set; }
        public string LastModifiedPerson { get; set; }

        public double LastAmount { get; set; }
        public double Balance { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }


    }
}
