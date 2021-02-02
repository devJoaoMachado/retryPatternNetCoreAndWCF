using System.ServiceModel;

namespace PocWCFService
{
    [ServiceContract]
    public interface IGetDateTimeService
    {
        [OperationContract]
        string GetDateTimeCentralUS();
    }
}
