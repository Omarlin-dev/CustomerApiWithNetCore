using System.ComponentModel.DataAnnotations;

namespace Dto.Request
{
    public class DtoDirectionResquest
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(80)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        public bool Default { get; set; }
    }
}
