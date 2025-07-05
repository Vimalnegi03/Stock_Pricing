using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace backend.StockData
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? StockId { get; set; }
        public DateTime CreatedOn { get; set; }=DateTime.Now;

    }
}