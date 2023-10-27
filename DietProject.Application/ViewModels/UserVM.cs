using DietProject.Application.CustomValidation;
using DietProject.Application.ViewModels.Base;
using DietProject.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.ViewModels;

public class UserVM:BaseVM
{
    [EmailAddress(ErrorMessage = "Mail adresiniz uygun formatta değil")]
    [Required(ErrorMessage ="E maili boş geçmeyiniz.")]
    public string Email { get; set; }


    [Required(ErrorMessage = "Lütfen şifrenizi boş geçmeyiniz")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Şifre uzunluğu Min 5 Max 20 olmalıdır.")]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$",ErrorMessage ="Şifreniz en az 1 tane büyük karakter , en az bir tane küçük karakter ,en az bir tane rakam,en az bir tane özel karakter içermelidir")] 
    public string Password { get; set; }


    [Required(ErrorMessage = "Lütfen adınızı boş geçmeyiniz")]
    [MaxLength(50)]
    public string Name { get; set; }


    [Required(ErrorMessage = "Lütfen soyadınızı boş geçmeyiniz")]
    [MaxLength (50)]
    public string Surname { get; set; }


    [Required(ErrorMessage = "Lütfen boyunuzu boş geçmeyiniz")]
    [Range(50,300,ErrorMessage ="Lütfen boyunuzu uygun aralıkta giriniz.")]
    public byte Height { get; set; }


    [Required(ErrorMessage = "Lütfen kilonuzu boş geçmeyiniz")]
    [Range(50, 300, ErrorMessage = "Lütfen kilonuzu uygun aralıkta giriniz.")]
    public float Weight { get; set; }

    [DateTimeValidation(ErrorMessage ="Girdiğiniz tarih uygun aralıkta değildir.")]
    [Required]
    public DateTime DateofBirth { get; set; }


    public virtual IEnumerable<MealVM> Meals { get; set; }
}
