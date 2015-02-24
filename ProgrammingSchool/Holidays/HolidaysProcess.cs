using System;
using System.Collections.Generic;
using Holidays.Interfaces;

namespace Holidays
{
    public class HolidaysProcess: IHolidaysProcess
    {
        private readonly List<IHolidayRequestConsumer> requestConsumers;

        public HolidaysProcess()
        {
            requestConsumers = new List<IHolidayRequestConsumer>();
        }

        public string HREmailAddress;

        public void RegisterRequestsConsumer(IHolidayRequestConsumer consumer)
        {
            requestConsumers.Add(consumer);
        }

        public void UnregisterRequestsConsumer(IHolidayRequestConsumer consumer)
        {
            if (!requestConsumers.Remove(consumer))
                throw new Exception("Trying to un-register an unknown consumer!");
        }

        public HolidayRequest SubmitRequest(HolidayRequest request)
        {
            request.State = RequestState.Submitted;
            SendToConsumers(request);
            return request;
        }

        public HolidayRequest RejectRequest(HolidayRequest request)
        {
            request.State = RequestState.Rejected;
            SendToConsumers(request);
            return request;
        }

        public HolidayRequest ApproveRequest(HolidayRequest request)
        {
            request.State = RequestState.Approved;
            SendToConsumers(request);
            return request;
        }

        private void SendToConsumers(HolidayRequest request)
        {
            foreach (var consumer in requestConsumers)
            {
                consumer.Consume(request);
            }
        }
    }
}