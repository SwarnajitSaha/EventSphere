using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.Models.Models
{
    public class EventCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }

        [Display (Name = "Minimum Guest")]
        public int? MinGuest { get; set; }

        [Display (Name = "Maximum Guest")]
        public int? MaxGuest { get; set; }
        public string? Offer {  get; set; }

        [Display (Name = "Profile Image")]
        public string? ProfileImage { get; set; }
    }
}
