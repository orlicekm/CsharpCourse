using System.Collections.Generic;

namespace School.BL.Models.DetailModels.EqualityComparers
{
    public class CourseDetailModelEqualityComparer : IEqualityComparer<CourseDetailModel>
    {
        public bool Equals(CourseDetailModel x, CourseDetailModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name) && string.Equals(x.Description, y.Description);
        }

        public int GetHashCode(CourseDetailModel obj)
        {
            unchecked
            {
                return ((obj.Name != null ? obj.Name.GetHashCode() : 0) * 397) ^
                       (obj.Description != null ? obj.Description.GetHashCode() : 0);
            }
        }
    }
}