using Etickets_Platform.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Display(Name="Cinemas Logo")]
        [Required(ErrorMessage ="Logo is Required")]

        public string Logo { get; set; }

        [Display(Name="Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is Required")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="cinema name must be between 3 to 50 chars")]
        public string Name { get; set; }

        [Display(Name="Cinema Desription")]
        public string Description { get; set; }

        //Relationships
        public List<NewMovieVm> Movies { get; set; }
    }
}
