using Generics.Store.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Store.Student
{
    internal class Student : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
