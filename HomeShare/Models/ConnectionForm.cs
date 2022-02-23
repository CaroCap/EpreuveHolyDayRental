
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class ConnectionForm
    {
        [Required(ErrorMessage = "Le login est obligatoire.")]
        [DisplayName("Login : ")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        [DataType(DataType.Password)]
        [DisplayName("Password : ")]
        public string Password { get; set; }

    }
}
