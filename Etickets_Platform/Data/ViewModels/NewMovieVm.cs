using Etickets_Platform.Data.Base;
using Etickets_Platform.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Models
{
    public class NewMovieVm
    {
        public int id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage ="Movie Name is Required")]
        public string Name { get; set; }

        [Display(Name = "Movie Desription")]
        [Required(ErrorMessage = "Movie Desription is Required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie  Poster URL is Required")]
        public string ImageURL { get; set; }

        [Display(Name = "Movie StartDate")]
        [Required(ErrorMessage = "Movie StartDate is Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie EndDate")]
        [Required(ErrorMessage = "Movie  EndDate is Required")]
        public  DateTime EndDate { get; set; }

        [Display(Name = "select Movie Category")]
        [Required(ErrorMessage = "Movie Category is Required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "select Actor(s) Id")]
        [Required(ErrorMessage = "Actors Id is Required")]
       [NotMapped]
        public List<int> ActorIds { get; set; }


        [Display(Name = "select cinema Id")]
        [Required(ErrorMessage = "cinema Id is Required")]
        public int CinemaId { get; set; }


        [Display(Name = "select Producer Id")]
        [Required(ErrorMessage = "Producer Id is Required")]

        public int ProducerId { get; set; }
       




    }

}
