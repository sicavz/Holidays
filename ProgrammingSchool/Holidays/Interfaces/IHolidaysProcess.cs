
namespace Holidays.Interfaces
{
    public interface IHolidaysProcess
    {
        void RegisterRequestsConsumer(IHolidayRequestConsumer consumer);
        void UnregisterRequestsConsumer(IHolidayRequestConsumer consumer);

        HolidayRequest SubmitRequest(HolidayRequest request);
        HolidayRequest RejectRequest(HolidayRequest request);
        HolidayRequest ApproveRequest(HolidayRequest request);
    }
}