using System.Collections.Generic;

namespace EntityFramework.DAL.Entities.EqualityComparers
{
    public class StudentEqualityComparer : IEqualityComparer<StudentEntity>
    {
        public bool Equals(StudentEntity x, StudentEntity y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id.Equals(y.Id) && string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(StudentEntity obj)
        {
            unchecked
            {
                return (obj.Id.GetHashCode() * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }
    }
}