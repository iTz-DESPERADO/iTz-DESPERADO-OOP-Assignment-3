using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Generics.Store.Course
{
    internal class CourseStore
    {
        private List<Course> _courses = [];

        public void Add(Course course)
        {
            ArgumentNullException.ThrowIfNull(course);
            _courses.Add(course);
        }

        public Course? GetById(int id)
            => _courses.FirstOrDefault(s => s.Id == id);

        public IReadOnlyList<Course> GetAll()
            => _courses.Count > 0 ? _courses : [];

        public void Remove(int id)
        {
            var result = GetById(id);
            if (result is null) return;
            _courses.Remove(result);
        }
    }
}
