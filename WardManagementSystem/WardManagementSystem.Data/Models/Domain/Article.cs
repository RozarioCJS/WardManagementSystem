using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Details { get; set; }
        public string Preview { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
