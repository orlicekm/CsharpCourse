using School.BL.Models.Base;

namespace School.BL.Models.ListModels
{
    public class AddressListModel : ModelBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}