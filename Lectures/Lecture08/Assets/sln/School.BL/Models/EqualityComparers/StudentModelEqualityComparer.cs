using System.Collections.Generic;

namespace School.BL.Models.EqualityComparers
{
    public class StudentModelEqualityComparer : IEqualityComparer<StudentModel>
    {
        public bool Equals(StudentModel x, StudentModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(StudentModel obj)
        {
            return obj.Name != null ? obj.Name.GetHashCode() : 0;
        }
    }
}