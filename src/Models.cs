namespace DomainBellaNS.API.ExternalService
{
[DataContract]
public class ActiveBundle
{
[DataMember]
public int id { get; set; }
[DataMember]
public String name { get; set; }
}

[DataContract]
public class BundleWithPrice
{
[DataMember]
public int bundleId { get; set; }
[DataMember]
public String name { get; set; }
[DataMember]
public DateTime startDate { get; set; }
[DataMember]
public DateTime endDate { get; set; }
[DataMember]
public Decimal amount { get; set; }
}




    [DataContract]
    public class DomainFault
    {
        [DataMember]
        public DomainError Code;

        [DataMember]
        public string Message;
    }


    [DataContract]
    public enum DomainError
    {
        [EnumMember]
        DomainError = 1
    }
}