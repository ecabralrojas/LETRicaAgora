namespace LET.Agora.Libreria.Impresion.SocketUrl
{
    public class SocketUrlFactory : ISocketUrlFactory
    {
        private readonly string _url;        
        public SocketUrlFactory(string url)
        {
            _url = url;            
        }

        public string SocketUrl()
        {
            return _url;
        }
        
    }
}
