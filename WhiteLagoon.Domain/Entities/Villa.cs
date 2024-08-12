using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [MaxLength(50)] //madhesia e lejuar
        public string? Description {  get; set; }
        public double Price { get; set; }
        [Display(Name = "Price per night")] //display data annotation
        [Range(10, 10000)] //range nga cila vlere deri te cila e lejon, ajo qe duhej te shpikja nje metode me vete ne javen e mutit qe ta validonte numrin
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageUrl {  get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
