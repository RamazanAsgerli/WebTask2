using System.ComponentModel.DataAnnotations;

namespace BB207_Mamba.ViewModels
{
    public class AdminLoginVm
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public bool IsPersistent {  get; set; }
    }
}
