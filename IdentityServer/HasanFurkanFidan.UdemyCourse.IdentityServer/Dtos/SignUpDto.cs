using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.IdentityServer.Dtos
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez!")]

        public string UserName { get; set; }
        [Required(ErrorMessage ="Parola alanı boş geçilemez!")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Parolalar uyuşmuyor.")]
        public string PasswordVerify { get; set; }
        public string Email { get; set; }
    }
}
