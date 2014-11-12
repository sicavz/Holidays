namespace Holidays
{
    public class Manager : Employee
    {
        public void ApproveHoliday(HolidayRequest request)
        {
            request.SetAccepted();
        }

        public void RejectHoliday(HolidayRequest request)
        {
            request.SetRejected();
        }
    }
}