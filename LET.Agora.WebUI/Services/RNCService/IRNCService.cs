using LET.Agora.WebUI.Models;

namespace LET.Agora.WebUI.Services.RNCService
{
    public interface IRNCService
    {
        Task<ServiceResponse<RNCDGII>> ObtenerRNC(string RNCContribuyente);
    }
}