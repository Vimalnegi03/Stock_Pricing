using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace backend.StockData
{
    public class CommentDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public int? StockId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}