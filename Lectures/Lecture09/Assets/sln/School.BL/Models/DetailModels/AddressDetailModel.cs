using System;
using School.BL.Models.Base;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public class AddressDetailModel : ModelBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Guid StudentId { get; set; }
        public StudentListModel StudentDetail { get; set; }
    }
}