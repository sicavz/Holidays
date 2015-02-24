
namespace Holidays.Renderers
{
    public class SimpleTextRenderer : BaseRequestRenderer<string>
    {
        protected override string RenderSubmitted(HolidayRequest request)
        {
            return string.Format("{0} initiated holiday request for [{1} - {2}]. Approver: {3}", request.EmployeeName,
                request.From, request.To, request.ApproverName);
        }

        protected override string RenderApproved(HolidayRequest request)
        {
            return string.Format("{0} approved the holiday request initiated by {3} for [{1} - {2}].", request.ApproverName,
                request.From, request.To, request.EmployeeName);
        }

        protected override string RenderRejected(HolidayRequest request)
        {
            return string.Format("{0} rejected the holiday request initiated by {3} for [{1} - {2}]", request.ApproverName,
                request.From, request.To, request.EmployeeName);
        }
    }
}