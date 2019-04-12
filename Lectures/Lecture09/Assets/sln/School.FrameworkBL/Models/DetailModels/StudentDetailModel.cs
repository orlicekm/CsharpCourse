using School.FrameworkBL.Models.Base;
using School.FrameworkBL.Models.ListModels;

namespace School.FrameworkBL.Models.DetailModels
{
    public class StudentDetailModel : ModelBase
    {
        private string name;

        public string Name
        {
            get => name;
            set => Set(() => Name, ref name, value);
        }

        public AddressListModel Address { get; set; }
    }
}