﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqMaterialization
    {
        [Fact]
        public void Test()
        {
            var names = new List<string> { "Bill", "Steve", "Ram", "Moin", "Mike" };

            IEnumerable<string> enumerableNames = names.Where(n => n.Contains('M'));
            enumerableNames = names.Where(n => n.Contains('o'));

            var name = names.First().ToList();

            Assert.Equal("Moin", name);
        }
    }
}