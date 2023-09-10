using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Adı"), StringLength(30), Required]
        public string Name { get; set; }
        [Display(Name = "Açıqlaması"), DataType(DataType.MultilineText), Required]
        public string Description { get; set; }
        
        [StringLength(150)]
        public string? Link { get; set; }

        [Display(Name = "Şəkli")]
        public string? Image { get; set; }
    }
}
