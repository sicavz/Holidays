using System.Net.Mail;

namespace Holidays.Renderers
{
    public class MailMessageRenderer : BaseRequestRenderer<MailMessage>
    {
        private readonly string hrEmailAddress;
        public MailMessageRenderer(string hrEmailAddress)
        {
            this.hrEmailAddress = hrEmailAddress;
        }

        protected override MailMessage RenderSubmitted(HolidayRequest request)
        {
            var result = new MailMessage
            {
                From = new MailAddress(request.EmployeeEmail, request.EmployeeName),
                Subject = "New holiday request",
                Body = string.Format("{0} asked a holiday for [{1} - {2}].\nPlease accept/reject the request.",
                                        request.EmployeeName, request.From, request.To)
            };
            result.To.Add(new MailAddress(request.ApproverEmail, request.ApproverName));

            return result;
        }

        protected override MailMessage RenderApproved(HolidayRequest request)
        {
            var result = new MailMessage
            {
                From = new MailAddress(request.ApproverEmail, request.ApproverName),
                Subject = "Holiday request approved",
                Body = string.Format("{0} approved the holiday request of {1} for [{2} - {3}]",
                                        request.ApproverName, request.EmployeeName, request.From, request.To)
            };
            result.To.Add(new MailAddress(hrEmailAddress));

            return result;
        }

        protected override MailMessage RenderRejected(HolidayRequest request)
        {
            var result = new MailMessage
            {
                From = new MailAddress(request.ApproverEmail, request.ApproverName),
                Subject = "Holiday request rejected",
                Body = string.Format("{0} rejected the holiday request of {1} for [{2} - {3}]",
                                    request.ApproverName, request.EmployeeName, request.From, request.To)
            };
            result.To.Add(hrEmailAddress);

            return result;
        }
    }
}