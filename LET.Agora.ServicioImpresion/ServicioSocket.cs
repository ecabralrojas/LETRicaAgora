using LET.Agora.Libreria.Impresion.Repositories;
using LET.Agora.Libreria.Impresion.SocketUrl;
using LET.Agora.Libreria.Impresion.WebSocket;
using Topshelf;

namespace LET.Agora.ServicioImpresion
{
    public class ServicioSocket
    {
        private readonly ISocketUrlFactory _socketUrlFactory;
        private readonly IImpresionService _impresionService;

        public ServicioSocket(ISocketUrlFactory socketUrlFactory, IImpresionService impresionService)
        {
            _socketUrlFactory = socketUrlFactory;
            _impresionService = impresionService;
        }

        public void IniciarServicio()
        {

            var exitCode = HostFactory.Run(x =>
            {
                x.Service<ImpresionsSocketServices>(s =>
                {
                    s.ConstructUsing(iss => new ImpresionsSocketServices(_impresionService, _socketUrlFactory));
                    s.WhenStarted(iss => iss.Start());
                    s.WhenStopped(iss => iss.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("Servicio Impresion Factura Agora");
                x.SetDisplayName("Servicio Impresion Factura Agora");
                x.SetDescription("Servicio que se encarga de imprimir las facturas");
            });
        }

    }
}
