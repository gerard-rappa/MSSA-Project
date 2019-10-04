using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TacoBoutIt.Models
{
    public class Meme
    {
        public int MemeId { get; set; }
        //public HttpPostedFile ImageFile { get; set; }
        public string ImgUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
    }
}
