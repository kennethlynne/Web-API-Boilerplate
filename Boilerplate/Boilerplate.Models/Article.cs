using Boilerplate.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Boilerplate.Models
{
    public class Article : IContent
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        [JsonIgnore]
        public string Ignored { get; set; }
    }
}