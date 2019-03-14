using System.Collections.Generic;

namespace Samples.Mapper.EqualityComparers
{
    public class CustomerDTOEqualityComparer : IEqualityComparer<CustomerDTO>
    {
        public bool Equals(CustomerDTO x, CustomerDTO y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id.Equals(y.Id) && string.Equals(x.FirstName, y.FirstName) &&
                   string.Equals(x.LastName, y.LastName) && x.DateOfBirth.Equals(y.DateOfBirth);
        }

        public int GetHashCode(CustomerDTO obj)
        {
            unchecked
            {
                var hashCode = obj.Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.FirstName != null ? obj.FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.LastName != null ? obj.LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ obj.DateOfBirth.GetHashCode();
                return hashCode;
            }
        }
    }
}