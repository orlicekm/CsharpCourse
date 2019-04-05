using School.BL.Models.Base;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public class StudentDetailModel : ModelBase
    {
        public string Name { get; set; }

        public AddressListModel Address { get; set; }
    }
}