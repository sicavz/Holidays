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

/* Sample output
 * 
 *
 * 
Email sent
        From    : employee@company.com
        To      : manager@company.com
        Subject : Employee asked a holiday for [25.11.2014 - 28.11.2014]
        Body    : Please accept/reject the request

Email sent
        From    : manager@company.com
        To      : hr@company.com
        Subject : Manager approved a holiday for Employee btw [25.11.2014 - 28.11.2014]
        Body    :

Email sent
        From    : manager@company.com
        To      : employee@company.com
        Subject : Manager rejected your holiday request btw [25.11.2014 - 28.11.2014]
        Body    :
 * 
 * 
 */
