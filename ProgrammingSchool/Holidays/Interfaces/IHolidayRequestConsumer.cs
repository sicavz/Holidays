namespace Holidays.Interfaces
{
    public interface IHolidayRequestConsumer
    {
        void Consume(HolidayRequest request);
    }
}