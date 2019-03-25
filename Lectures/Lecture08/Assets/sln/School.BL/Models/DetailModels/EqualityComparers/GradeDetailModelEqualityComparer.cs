using System.Collections.Generic;

namespace School.BL.Models.DetailModels.EqualityComparers
{
    public class GradeDetailModelEqualityComparer : IEqualityComparer<GradeDetailModel>
    {
        public bool Equals(GradeDetailModel x, GradeDetailModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name) && string.Equals(x.Section, y.Section);
        }

        public int GetHashCode(GradeDetailModel obj)
        {
            unchecked
            {
                return ((obj.Name != null ? obj.Name.GetHashCode() : 0) * 397) ^
                       (obj.Section != null ? obj.Section.GetHashCode() : 0);
            }
        }
    }
}