using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EHR.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 15, MinimumLength = 3)]
        public string firstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 15, MinimumLength = 3)]
        public string lastName { get; set; }


    }
}
