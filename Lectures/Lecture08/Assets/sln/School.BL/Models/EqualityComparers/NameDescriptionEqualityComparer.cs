using System.Collections.Generic;

namespace School.BL.Models.EqualityComparers
{
    public class NameDescriptionEqualityComparer : IEqualityComparer<CourseModel>
    {
        public bool Equals(CourseModel x, CourseModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name) && string.Equals(x.Description, y.Description);
        }

        public int GetHashCode(CourseModel obj)
        {
            unchecked
            {
                return ((obj.Name != null ? obj.Name.GetHashCode() : 0) * 397) ^
                       (obj.Description != null ? obj.Description.GetHashCode() : 0);
            }
        }
    }
}