using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? StockId { get; set; }
        public Stock? Stock { get; set; } //Navigating property allow us to explore stocks
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }




    }
}