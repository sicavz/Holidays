namespace Holidays.Interfaces
{
    public interface INotifyPolicy
    {
        INotifier CreateNotifier();
    }
}