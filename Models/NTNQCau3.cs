using System.ComponentModel.DataAnnotations;

namespace NTNQCau3.Models
{
    public class NTNQCau3
    {
        [Key]
        [Display(Name = "Mã sinh viên")]
        
        public string StudentID {get; set;}
        [Display(Name = "Tên sinh viên")]
         public string StudentName {get; set;}
         [Display(Name = "Địa chỉ")]
          public string Address {get; set;}
    }
}