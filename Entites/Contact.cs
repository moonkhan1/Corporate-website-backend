using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Ad Soyad"), Required, StringLength(30)]
        public string Name { get; set; }
        [EmailAddress, StringLength(30), Required]
        public string Email{ get; set; }

        [Display(Name = "Telefon nömrəsi"), StringLength(15)]
        public string? Phone{ get; set; }

        [Display(Name = "Mesajınız"), StringLength(400)]
        public string? Message{ get; set; }

        [Display(Name = "Mesajın Tarixi"), ScaffoldColumn(false)] // Do not create this field on page creation 
        public DateTime CreationDate{ get; set; }

    }
}
