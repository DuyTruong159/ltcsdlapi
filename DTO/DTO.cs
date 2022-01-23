using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string email { get; set; }
    }

    public class CourseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
    }

    public class LessonModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int courseId { get; set; }
    }

    public class UnitModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string trans_name { get; set; }
        public int lessonId { get; set; }
    }

    public class UnitInfoModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string trans_name { get; set; }
        public string description { get; set; }
        public string video { get; set; }
        public string css { get; set; }
        public int unitId { get; set; }
        public int lessonId { get; set; }
    }
}
