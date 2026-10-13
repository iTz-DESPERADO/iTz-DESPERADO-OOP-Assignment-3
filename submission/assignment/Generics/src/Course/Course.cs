using Generics.Store.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Store.Course
{
    internal class Course : IHasId
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
