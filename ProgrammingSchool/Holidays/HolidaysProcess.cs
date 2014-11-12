using System;
using Holidays.Interfaces;

namespace Holidays
{
    public class HolidaysProcess: IHolidaysProcess
    {
        public string HREmailAddress;
        public INotifier Notifier;

        public void RegisterHolidayRequest(HolidayRequest request)
        {
            request.Submitted += OnRequestSubmitted;
            request.Accepted += OnRequestAccepted;
            request.Rejected += OnRequestRejected;
        }

        private void OnRequestRejected(object r, EventArgs e)
        {
            var req = (HolidayRequest) r;
            var subject = string.Format("{0} rejected your holiday request btw [{1} - {2}]", 
                                req.ManagerName, req.From.ToShortDateString(), req.To.ToShortDateString());
            var body = "";

            Notifier.Notify(req.ManagerEmail, req.EmployeeEmail, subject, body);
        }

        private void OnRequestAccepted(object r, EventArgs e)
        {
            var req = (HolidayRequest) r;
            var subject = string.Format("{0} approved a holiday for {1} btw [{2} - {3}]", 
                                req.ManagerName, req.EmployeeName, req.From.ToShortDateString(), req.To.ToShortDateString());
            var body = "";

            Notifier.Notify(req.ManagerEmail, HREmailAddress, subject, body);
        }

        private void OnRequestSubmitted(object r, EventArgs e)
        {
            var req = (HolidayRequest) r;
            var subject = string.Format("{0} asked a holiday for [{1} - {2}]", 
                                req.EmployeeName, req.From.ToShortDateString(), req.To.ToShortDateString());
            var body = "Please accept/reject the request";

            Notifier.Notify(req.EmployeeEmail, req.ManagerEmail, subject, body);
        }

    }
}