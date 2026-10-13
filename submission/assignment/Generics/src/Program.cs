using Generics.Store.Common;
using Generics.Store.Course;
using Generics.Store.Extensions;
using Generics.Store.Student;

var studentStore = new Store<Student>();

for (int i = 1; i <= 5; i++)
{
    studentStore.Add(new Student
    {
        Id = i,
        Name = $"Student {i}"
    });
}

var courseStore = new Store<Course>();

courseStore.Add(new Course { Id = 1, Title = "C#", Price = 100 });
courseStore.Add(new Course { Id = 2, Title = "SQL", Price = 150 });
courseStore.Add(new Course { Id = 3, Title = "ASP.NET Core", Price = 200 });

var student = studentStore.GetById(2);
var course = courseStore.GetById(3);

Console.WriteLine($"Student: {student?.Name}");
Console.WriteLine($"Course: {course?.Title}");

// Test duplicate Id
try
{
    studentStore.Add(new Student
    {
        Id = 2,
        Name = "Duplicate Student"
    });
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}


Console.WriteLine("Students - Page 2:");

foreach (var item in studentStore.GetAll().Page(2, 2))
{
    Console.WriteLine($"{item.Id}: {item.Name}");
}


var courses = new List<Course>
{
    new() { Id = 10, Title = "Design Patterns" },
    new() { Id = 20, Title = "Data Structures" }
};

var foundCourse = courses.FindById(20);

Console.WriteLine($"Found Course: {foundCourse?.Title}");


var dictionary = studentStore.GetAll().ToIdDictionary();

Console.WriteLine($"Dictionary Count: {dictionary.Count}");

// must NOT compile
// var invalidStore = new Store<string>();