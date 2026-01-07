using LET.AgoraPantallaFormaPago.Models;

namespace LET.AgoraPantallaFormaPago.Services.ParametroService
{
    public class ParametroPosService : IParametroPosService
    {
        private readonly Parametro _parametro;

        public ParametroPosService(Parametro parametro)
        {
            _parametro = parametro;
        }

        public Parametro CreateAgoraParametro()
        { return _parametro; }

    }
}
