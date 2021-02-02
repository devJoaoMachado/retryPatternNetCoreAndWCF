using System;

namespace PocWCFService
{
    public class GetDateTimeService : IGetDateTimeService
    {
        public string GetDateTimeCentralUS()
        {
            RandomError();

            var timezone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            var dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timezone);

            return $"{dateTime.ToShortDateString().ToString()} {dateTime.ToLongTimeString().ToString()}";
        }


        private void RandomError()
        {
            var number = new Random().Next(2, 4);
            if (number % 2 == 0) throw new Exception("Testando resiliência com Polly em serviços WCF");
        }
    }
}
