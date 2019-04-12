using School.FrameworkBL.Models.Base;

namespace School.FrameworkBL.Models.ListModels
{
    public class AddressListModel : ModelBase
    {
        private string city;
        private string country;
        private string state;
        private string street;

        public string Street
        {
            get => street;
            set => Set(() => Street, ref street, value);
        }

        public string City
        {
            get => city;
            set => Set(() => City, ref city, value);
        }

        public string State
        {
            get => state;
            set => Set(() => State, ref state, value);
        }

        public string Country
        {
            get => country;
            set => Set(() => Country, ref country, value);
        }
    }
}