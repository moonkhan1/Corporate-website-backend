using System.ComponentModel.DataAnnotations;
namespace Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Üst Kateqoriya")]
        public int ParentId { get; set; }

        [Display(Name = "Kateqoriyanın Adı"), Required, StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Kateqoriyanın Açıqlaması"), DataType(DataType.MultilineText), Required]
        public string Description { get; set; }

        [Display(Name = "Kateqoriyanın Şəkli")]
        public string? Image{ get; set; }
    }
}
