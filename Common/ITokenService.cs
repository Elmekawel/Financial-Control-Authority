namespace MICLifePortal.Common
{
    public interface ITokenService
    {
        Task<string> GetAccessToken();
    }
}
