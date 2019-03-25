using System.Collections.Generic;

namespace School.BL.Models.ListModels.EqualityComparers
{
    public class AddressListModelEqualityComparer : IEqualityComparer<AddressListModel>
    {
        public bool Equals(AddressListModel x, AddressListModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Street, y.Street) && string.Equals(x.City, y.City) &&
                   string.Equals(x.State, y.State) && string.Equals(x.Country, y.Country);
        }

        public int GetHashCode(AddressListModel obj)
        {
            unchecked
            {
                var hashCode = obj.Street != null ? obj.Street.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (obj.City != null ? obj.City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.State != null ? obj.State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.Country != null ? obj.Country.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}