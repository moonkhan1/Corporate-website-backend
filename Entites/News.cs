using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class News : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Xəbərin Adı"), Required, StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "Xəbərin Məzmunu"), Required]
        public string Content { get; set; }

        [Display(Name = "Xəbərin Şəkli")]
        public string? Image { get; set; }
        [Display(Name = "Xəbərin Tarixi"), ScaffoldColumn(false)]
        public System.DateTime CreationDate { get; set; }

    }
}
