using System;

namespace Holidays
{
    public class Employee
    {
        public string Name;
        public string Email;

        public Company Company;
        public Manager Manager;

        public HolidayRequest AskForHoliday(DateTime from, DateTime to)
        {
            var request = new HolidayRequest(this, from, to);

            Company.GetHolidaysProcess().RegisterHolidayRequest(request);
            request.Submit();

            return request;
        }
    }
}