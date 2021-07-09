
namespace Test_IBAGruop_RVS.Functional
{
    internal static class ValidationOfInputData
    {
       internal static string DataTimeFormat = "dd.MM.yyyy HH:mm:ss";
       internal static string CarNumberFormat = "[0-9]{4} [A,B,E,I,K,M,H,O,P,C,T,X]{2}-[1-7]{1}";
       internal static string CarNumberDefault = "0000 AA-1";
       internal static string SeepdFormat4 = "[4-9]{1}[0-9]{1},[0-9]{1}";
       internal static string SeepdFormat5 = "[1-3]{1}[0-9]{1}[0-9]{1},[0-9]{1}";
       internal static string SeepdDefault = "60,0"; 
    }
}
