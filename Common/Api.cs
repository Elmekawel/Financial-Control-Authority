namespace MICLifePortal.Common
{
    public class Api
    {
        //public static string Port { get; } = "insgatewaytest.fra.gov.eg:9090";
        public static string Port = "insgatewaytest.fra.gov.eg:9090";
        //public static string BasePath { get; } = $"http://{Port}/ords/insurance/InsuranceRequest/";
        public static string BasePath = "http://<IP_ADDRESS>/ords/insurance/InsuranceRequest/";
        public static string PathToken { get; } = $"http://{Port}/ords/insurance/InsuranceRequest/getToken";
        public static string ClientId { get; } = "70531AC2DA228156AB2B04438906C0B0226B9B8A";
        public static string ClientSecret { get; } = "9091F1BEB925FD34A99D9B83A60C4B31E6C05344";
        public static string Scope { get; } = "insuranceAPI";
        public static string GrantType { get; } = "client_credentials";
    }
}
