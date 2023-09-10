using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(50), Required]
        public string Name { get; set; }

        [Display(Name = "Soyadı"), StringLength(50), Required]
        public string Surname { get; set; }

        [Display(Name = "İsdifadəçi Adı"), StringLength(50)]
        public string Username { get; set; }

        [EmailAddress, StringLength(30), Required]
        public string Email { get; set; }

        [Display(Name = "Şifrə"), StringLength(150), Required]
        public string Password { get; set; }

        [Display(Name = "Telefon Nömrəsi"), StringLength(15)]
        public string? Phone { get; set; }

        [Display(Name = "Vəziyyət")]
        public bool IsActive{ get; set; }

        [Display(Name = "İsdifadəçinin Qeydiyyat Tarixi"), ScaffoldColumn(false)]
        public System.DateTime CreationDate { get; set; }

    }
}
