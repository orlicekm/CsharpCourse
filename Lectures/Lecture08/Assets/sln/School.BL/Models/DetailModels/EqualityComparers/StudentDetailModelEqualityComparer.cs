using System.Collections.Generic;

namespace School.BL.Models.DetailModels.EqualityComparers
{
    public class StudentDetailModelEqualityComparer : IEqualityComparer<StudentDetailModel>
    {
        public bool Equals(StudentDetailModel x, StudentDetailModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(StudentDetailModel obj)
        {
            return obj.Name != null ? obj.Name.GetHashCode() : 0;
        }
    }
}