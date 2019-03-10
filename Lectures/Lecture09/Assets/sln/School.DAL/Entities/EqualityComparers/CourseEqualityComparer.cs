using System.Collections.Generic;

namespace School.DAL.Entities.EqualityComparers
{
    public class CourseEqualityComparer : IEqualityComparer<CourseEntity>
    {
        public bool Equals(CourseEntity x, CourseEntity y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id.Equals(y.Id) && string.Equals(x.Name, y.Name) && string.Equals(x.Description, y.Description);
        }

        public int GetHashCode(CourseEntity obj)
        {
            unchecked
            {
                var hashCode = obj.Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.Description != null ? obj.Description.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}