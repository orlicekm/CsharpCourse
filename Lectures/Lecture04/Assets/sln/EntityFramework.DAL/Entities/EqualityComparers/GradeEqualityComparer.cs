using System.Collections.Generic;

namespace EntityFramework.DAL.Entities.EqualityComparers
{
    public class GradeEqualityComparer : IEqualityComparer<GradeEntity>
    {
        public bool Equals(GradeEntity x, GradeEntity y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id.Equals(y.Id) && string.Equals(x.Name, y.Name) && string.Equals(x.Section, y.Section);
        }

        public int GetHashCode(GradeEntity obj)
        {
            unchecked
            {
                var hashCode = obj.Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.Section != null ? obj.Section.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}