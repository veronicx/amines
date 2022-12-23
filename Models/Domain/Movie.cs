﻿

using System.ComponentModel.DataAnnotations;

namespace AminesStream.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required] 
        public string? Title { get; set; }    

        public string ReleaseYear { get; set; }


        [Required]
        public string? MovieImage { get; set; }

        [Required]
        public string? Cast {  get; set; }

        [Required]
        public string? Director { get; set; }

    }
}
