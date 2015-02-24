namespace Holidays.Interfaces
{
    public interface IRequestRenderer<out T>
    {
        T RenderRequest(HolidayRequest request);
    }
}