namespace Holidays.Interfaces
{
    public interface INotifier
    {
        void Notify(string sender, string receiver, string subject, string body);
    }
}