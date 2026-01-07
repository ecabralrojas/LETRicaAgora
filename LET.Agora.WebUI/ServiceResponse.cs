namespace LET.Agora.WebUI;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Exito { get; set; } = true;
    public string Mensaje { get; set; } = string.Empty;
}
