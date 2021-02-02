using System;
using System.ServiceModel;

namespace PollyNetCore
{
    public class WCFClientBaseConfig
    {
        protected BasicHttpBinding _binding;
        protected EndpointAddress _endpoint;

        public WCFClientBaseConfig(string url)
        {
            _binding = new BasicHttpBinding();
            _binding.Security.Mode = BasicHttpSecurityMode.None;
            _binding.MaxReceivedMessageSize = int.MaxValue;
            _endpoint = new EndpointAddress(new Uri(url));
        }
    }
}
