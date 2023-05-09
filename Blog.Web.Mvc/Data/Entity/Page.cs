using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Mvc.Data.Entity
{
    public class Page
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        [Column(TypeName = "text")]
        public string? Content { get; set; }
        public bool IsActive { get; set; }
    }
}
