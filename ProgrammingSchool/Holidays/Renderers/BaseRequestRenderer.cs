using Holidays.Interfaces;

namespace Holidays.Renderers
{
    public abstract class BaseRequestRenderer<T> : IRequestRenderer<T>
    {
        public T RenderRequest(HolidayRequest request)
        {
            switch (request.State)
            {
                case RequestState.Created:
                    return RenderCreated(request);
                case RequestState.Submitted:
                    return RenderSubmitted(request);
                case RequestState.Approved:
                    return RenderApproved(request);
                default:
                    return RenderRejected(request);
            }
        }

        protected virtual T RenderCreated(HolidayRequest request)
        {
            throw new System.NotImplementedException();
        }
        protected abstract T RenderSubmitted(HolidayRequest request);
        protected abstract T RenderApproved(HolidayRequest request);
        protected abstract T RenderRejected(HolidayRequest request);
    }
}
