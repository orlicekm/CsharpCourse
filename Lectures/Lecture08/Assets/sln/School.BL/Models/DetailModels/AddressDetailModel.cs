using School.BL.Models.Base;

namespace School.BL.Models.DetailModels
{
    public class AddressDetailModel : ModelBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public StudentDetailModel StudentDetail { get; set; }
    }
}