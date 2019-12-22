using System.ComponentModel.DataAnnotations;

namespace AngularCourseBE.Models
{
    public sealed class SignInModel
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}