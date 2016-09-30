/*
*/
using Holidays.Interfaces;

namespace Holidays
{
    public class Company: ICompany
    {
        private readonly IHolidaysProcess holidaysProcess;

        public Company(IHolidaysProcess holidaysProcess)
        {
            this.holidaysProcess = holidaysProcess;
        }

        public IHolidaysProcess GetHolidaysProcess()
        {
            return holidaysProcess;
        }
    }
}