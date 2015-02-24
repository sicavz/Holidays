using System;
using Holidays.Notifiers;
using Holidays.Renderers;

namespace Holidays
{
    class Program
    {
        static void Main()
        {
            //wire-up
            var holidayProcess = new HolidaysProcess { HREmailAddress = "hr@company.com" };

            var consoleNotifier = new ConsoleNotifier(new SimpleTextRenderer());
            var smtpNotifier = new SmtpNotifier(new MailMessageRenderer(holidayProcess.HREmailAddress));

            holidayProcess.RegisterRequestsConsumer(consoleNotifier);
            holidayProcess.RegisterRequestsConsumer(smtpNotifier);

            //start using
            var employee = new Employee("Employee", "employee@company.com");
            var manager = new Employee("Manager", "manager@company.com");

            var holidayRequest = new HolidayRequest(employee, new DateTime(2014, 11, 25), new DateTime(2014, 11, 28), manager);

            holidayProcess.SubmitRequest(holidayRequest);
            holidayProcess.ApproveRequest(holidayRequest);
            holidayProcess.RejectRequest(holidayRequest);
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
