using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Email
    {
 
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public List<IFormFile> Files { get; set; }
 
      
    }
}
