using System;
using Holidays.Interfaces;

namespace Holidays
{
    public class Employee
    {
        public Employee(ICompany company, string name, string email)
        {
            Company = company;
            Name = name;
            Email = email;
        }

        public string Name { private set; get; }
        public string Email { private set; get; }

        public ICompany Company { private set; get; }
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