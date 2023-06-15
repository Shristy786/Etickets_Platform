using Etickets_Platform.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Models
{
    public class Producer:IEntityBase
    {

        [Key]
        public int id { get; set; }

        [Display(Name ="Profile Picture Url")]
        //[Required(ErrorMessage="Profile Picture URL is Required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        //[Required(ErrorMessage = "full Name is Required")]
        //[StringLength(50,MinimumLength =3,ErrorMessage ="Name must be between 3 to 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        //[Required(ErrorMessage = "Biography is Required")]
        public string Bio { get; set; }

        //Relationships
        public List<NewMovieVm>Movies { get; set; }
    }
}
