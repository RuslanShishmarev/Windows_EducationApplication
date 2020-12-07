
namespace EducationApp.Model
{
    class EducationObject
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public User Author { get; set; }

    }
}
