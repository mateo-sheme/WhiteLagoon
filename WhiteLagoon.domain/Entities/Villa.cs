using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description {  get; set; }
        public double Price { get; set; }
        [Display(Name = "Price per night")]
        public int Sqft { get; set; }
        public int Occupancy { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl {  get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
