﻿using System.Collections.Generic;

namespace School.BL.Models.EqualityComparers
{
    public class GradeModelEqualityComparer : IEqualityComparer<GradeModel>
    {
        public bool Equals(GradeModel x, GradeModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name) && string.Equals(x.Section, y.Section);
        }

        public int GetHashCode(GradeModel obj)
        {
            unchecked
            {
                return ((obj.Name != null ? obj.Name.GetHashCode() : 0) * 397) ^
                       (obj.Section != null ? obj.Section.GetHashCode() : 0);
            }
        }
    }
}