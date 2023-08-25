using System.Runtime.Serialization;
using CoreWCF;
using System.Threading.Tasks;

namespace DomainBellaNS.API.ExternalService
{

    [ServiceContract]
    public interface ExternalService
    {
        [OperationContract]
[FaultContractAttribute(typeof(DomainFault))]
Task<List<ActiveBundle>> ExternalCall1(string url );

[OperationContract]
[FaultContractAttribute(typeof(DomainFault))]
Task<List<BundleWithPrice>> ExternalCall2(string url , List<int> body);


    }
}
