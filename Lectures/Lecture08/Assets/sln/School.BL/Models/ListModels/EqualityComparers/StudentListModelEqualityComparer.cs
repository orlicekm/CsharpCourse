using System.Collections.Generic;

namespace School.BL.Models.ListModels.EqualityComparers
{
    public class StudentListModelEqualityComparer : IEqualityComparer<StudentListModel>
    {
        public bool Equals(StudentListModel x, StudentListModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(StudentListModel obj)
        {
            return obj.Name != null ? obj.Name.GetHashCode() : 0;
        }
    }
}