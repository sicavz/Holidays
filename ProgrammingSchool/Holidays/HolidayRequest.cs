/*
x
*/
using System;

namespace Holidays
{
    public enum RequestState
    {
        Created,
        Submitted,
        Approved,
        Rejected
    }

    public class HolidayRequest
    {
        public HolidayRequest(Employee requester, DateTime from, DateTime to, Employee approver)
        {
            EmployeeName = requester.Name;
            EmployeeEmail = requester.Email;
            ApproverName = approver.Name;
            ApproverEmail = approver.Email;
            From = from;
            To = to;
            State = RequestState.Created;
        }

        public string EmployeeName { private set; get; }
        public string EmployeeEmail { private set; get; }

        public string ApproverName { private set; get; }
        public string ApproverEmail { private set; get; }

        public DateTime From { private set; get; }
        public DateTime To { private set; get; }

        public RequestState State { get; set; }
    }
}
