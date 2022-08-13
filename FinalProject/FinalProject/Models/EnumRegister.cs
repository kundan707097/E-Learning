namespace FinalProject.Models
{
    public class EnumRegister
    {
        public RollTypes rollType { get; set; }
    }
    public enum RollTypes
    {
        Faculty = 1,
        Student = 2,
        Admin = 3
    }
}
