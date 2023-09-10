using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Post : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Postun Adı"), Required, StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "Postun Məzmunu"), Required, StringLength(50)]
        public string Content { get; set; }

        [Display(Name = "Postun Şəkli"), StringLength(150)]
        public string? Image { get; set; }

        [Display(Name = "Postun Tarixi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
