using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerRestAPI.Models
{
    public class Dog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the name of the dog")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the color of the dog")]
        public string Color { get; set; }
        [Range(1, 200, ErrorMessage = "Tail Length must be at range from 1 to 200")]
        [Required(ErrorMessage = "Enter the length of dog's tail")]
        public int Tail_Length { get; set; }
        [Range(1, 150, ErrorMessage = "Weight must be at range from 1 to 150")]
        [Required(ErrorMessage = "Enter the weight of the dog")]
        public int Weight { get; set; }
    }
}
