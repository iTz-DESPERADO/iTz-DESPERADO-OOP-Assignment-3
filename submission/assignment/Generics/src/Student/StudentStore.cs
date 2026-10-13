using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Store.Student
{
    internal class StudentStore
    {
        private List<Student> _students = [];
        public void Add(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);
            _students.Add(student);
        }
    
        public Student? GetById(int id)
            => _students.FirstOrDefault(s => s.Id == id);

        public IReadOnlyList<Student> GetAll()
            => _students.Count > 0 ? _students : [];

        public void Remove(int id)
        {
            var result = GetById(id);
            if (result is null) return;
            _students.Remove(result);
        }

    }
}
