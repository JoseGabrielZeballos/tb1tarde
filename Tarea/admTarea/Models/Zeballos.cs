using System;
using System.ComponentModel.DataAnnotations;

namespace admTarea.Models
{
    public enum CategoryType
    {
        Chocoloate = 1,
        Vahinilla = 2,
        Mermeladada = 3,
        Galletas = 4,
        Frutilla = 5

    }

    public class Zeballos
    {
        [Key]
        public int ZeballosID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(30, ErrorMessage = "El campo {0} debe contener valores entre {2} y {1}", MinimumLength = 2)]
        public string FriendofZeballos { get; set; }
        [Required]
        public CategoryType Place { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }







    }

}