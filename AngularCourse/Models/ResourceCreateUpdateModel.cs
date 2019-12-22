using System.ComponentModel.DataAnnotations;

namespace AngularCourseBE.Models
{
    public sealed class ResourceCreateUpdateModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}