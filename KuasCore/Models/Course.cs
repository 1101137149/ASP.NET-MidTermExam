using System;

namespace KuasCore.Models
{
    public class Course
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Int32 Description { get; set; }

        public override string ToString()
        {
            return "Course: Id = " + Id + ", Name = " + Name + ".";
        }

    }
}
