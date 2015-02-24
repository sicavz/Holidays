
namespace Holidays
{
    public class Employee
    {
        public Employee(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { private set; get; }
        public string Email { private set; get; }
    }
}