using System.ComponentModel.DataAnnotations;

namespace PracticalDemoWebAPI.Models
{
    public class CarInventoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public bool Condition { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? Years { get; set; }
        public bool HasValidInsurance { get; set; }
        public FormFile Image { get; set; }

    }
}
