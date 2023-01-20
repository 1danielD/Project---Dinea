namespace Project.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Corporation>? Corporations { get; set; } //navigation property
    }
}
