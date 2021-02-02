using GetDateTimeService;
using Polly;
using Polly.Retry;
using System;
using System.Threading.Tasks;

namespace PollyNetCore
{
    public class GetDateTimeService : WCFClientBaseConfig
    {
        public readonly GetDateTimeServiceClient _wcfClientService;
        private readonly AsyncRetryPolicy _retryPolicy;

        public GetDateTimeService(string url) : base(url)
        {
            _wcfClientService = new GetDateTimeServiceClient(_binding, _endpoint);

            _retryPolicy = Policy
             .Handle<Exception>()
             .WaitAndRetryAsync(5,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (ex, timeSpan) =>
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    Console.WriteLine($"Retentativa em {timeSpan.Seconds} segundos");
                });
        }

        public async Task<string> GetDateTimeCentralUSAsync()
        {
            return await _retryPolicy.ExecuteAsync(async () =>
            {
                return await _wcfClientService.GetDateTimeCentralUSAsync();
            });
        }
    }
}
