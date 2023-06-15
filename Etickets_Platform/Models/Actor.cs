using Etickets_Platform.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Models
{
    public class Actor:IEntityBase
    {

        [Key]
        public int id { get; set; }

        [Display(Name ="Profile Picture Url")]
        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full Name must be between 3 and 50 characters ")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        public string  Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        
    }
}
