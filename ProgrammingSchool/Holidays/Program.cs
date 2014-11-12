using System;
using Holidays.NotifyPolicies;

namespace Holidays
{
    class Program
    {
        static void Main()
        {
            var company = new Company
            {
                NotifyPolicy = new ConsoleNotifyPolicy()
                //NotifyPolicy = new SmtpNotifyPolicy()
            };

            var manager = new Manager
            {
                Name = "Manager",
                Email = "manager@company.com",
                Company = company
            };

            var employee = new Employee
            {
                Name = "Employee",
                Email = "employee@company.com",
                Company = company,
                Manager = manager
            };

            var holidayRequest = employee.AskForHoliday(new DateTime(2014, 11, 25), new DateTime(2014, 11, 28));

            manager.ApproveHoliday(holidayRequest);

            manager.RejectHoliday(holidayRequest);
        }
    }
}
