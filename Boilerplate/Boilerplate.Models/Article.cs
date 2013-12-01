using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Boilerplate.Models.Interfaces;
using System;
using Newtonsoft.Json;

namespace Boilerplate.Models
{
    public class Article : IContent
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        [Required]
        public string Title { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        [JsonIgnore]
        public string Ignored { get; set; }
    }
}