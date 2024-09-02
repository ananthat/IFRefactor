using System.ComponentModel.DataAnnotations;

namespace AcmeStudios.ApiRefactor.Data.DTOs
{
    public class GetStudioItemHeaderDto
    {
        public int StudioItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
