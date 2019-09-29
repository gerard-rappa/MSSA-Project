using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TacoBoutIt.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Restaurant { get; set; }
        public string Location { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string ImgUrl { get; set; }
        public string Username { get; set; }
    }
}
