using System;

namespace Holidays
{
    public class HolidayRequest
    {
        private enum RequestState
        {
            Unknown,
            New,
            Accepted,
            Rejected
        }

        private RequestState state;
        private RequestState State
        {
            set
            {
                state = value;
            }
        }

        public HolidayRequest(Employee requester, DateTime from, DateTime to)
        {
            EmployeeName = requester.Name;
            EmployeeEmail = requester.Email;
            ManagerName = requester.Manager.Name;
            ManagerEmail = requester.Manager.Email;
            From = from;
            To = to;
        }

        public string EmployeeName { private set; get; }
        public string EmployeeEmail { private set; get; }

        public string ManagerName { private set; get; }
        public string ManagerEmail { private set; get; }

        // holiday period
        public DateTime From { private set; get; }
        public DateTime To { private set; get; }

        public void Submit()
        {
            State = RequestState.New;
            Submitted(this, EventArgs.Empty);
        }

        public void SetAccepted()
        {
            State = RequestState.Accepted;
            Accepted(this, EventArgs.Empty);
        }

        public void SetRejected()
        {
            State = RequestState.Rejected;
            Rejected(this, EventArgs.Empty);
        }

        public event EventHandler Submitted;
        public event EventHandler Accepted;
        public event EventHandler Rejected;
    }
}