using System;
using Holidays.NotifyPolicies;

namespace Holidays
{
    class Program
    {
        static void Main()
        {
            var company = new Company(new HolidaysProcess(new ConsoleNotifyPolicy()) //SmtpNotifyPolicy()
                {
                    HREmailAddress = "hr@company.com"
                }
            );

            var manager = new Manager(company, "Manager", "manager@company.com");
            var employee = new Employee(company, "Employee", "employee@company.com")
            {
                Manager = manager
            };

            var holidayRequest = employee.AskForHoliday(new DateTime(2014, 11, 25), new DateTime(2014, 11, 28));

            manager.ApproveHoliday(holidayRequest);

            manager.RejectHoliday(holidayRequest);
        }
    }
}
