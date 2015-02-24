using System;
using Holidays.Interfaces;

namespace Holidays.Notifiers
{
    public class ConsoleNotifier : IHolidayRequestConsumer
    {
        private readonly IRequestRenderer<string> requestRenderer;

        public ConsoleNotifier(IRequestRenderer<string> requestRenderer)
        {
            this.requestRenderer = requestRenderer;
        }

        public void Consume(HolidayRequest request)
        {
            var renderedRequest = requestRenderer.RenderRequest(request);
            Console.WriteLine(renderedRequest);
            Console.WriteLine();
        }
    }
}