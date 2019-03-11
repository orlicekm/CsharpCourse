using School.BL.Models.Base;

namespace School.BL.Models
{
    public class AddressModel : ModelBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public StudentModel Student { get; set; }
    }
}