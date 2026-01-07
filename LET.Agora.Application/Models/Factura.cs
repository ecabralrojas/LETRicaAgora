using System.Data;

namespace LET.Agora.Application.Models;

public class Factura
{
    public string Serie { get; set; }
    public int Numero { get; set; }
    public decimal BaseImponible { get; set; }
    public decimal Impuestos { get; set; }
    public decimal TotalNeto { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Propina { get; set; }
    public string MensajePropina { get; set; }
    public string Ubicacion { get; set; }
    public string Mesa { get; set; }
    public string Usuario { get; set; }
    public int IdInvoice { get; set; }
    public int IdTicket { get; set; }
    public int RelatedInvoiceId { get; set; }
    public decimal TasaUSD { get; set; }
    public decimal MontoTotalUSD { get; set; }
    public decimal Descuento { get; set; }
    public decimal DescuentoPorcentaje { get; set; }
    public decimal MontoTotalDescuento { get; set; }
    public int PosId { get; set; }
    public int IdCliente { get; set; }
    public string? CodigoCliente { get; set; }
    public string? NombreCliente { get; set; }

    public static DataTable ToDataTable(Factura modelo)
    {


        DataTable t = new DataTable();

        t.Columns.Add("Serie", typeof(string));
        t.Columns.Add("Numero", typeof(int));
        t.Columns.Add("BaseImponible", typeof(decimal));
        t.Columns.Add("Impuestos", typeof(decimal));
        t.Columns.Add("TotalNeto", typeof(decimal));
        t.Columns.Add("Fecha", typeof(DateTime));
        t.Columns.Add("Propina", typeof(decimal));
        t.Columns.Add("MensajePropina", typeof(string));
        t.Columns.Add("Ubicacion", typeof(string));
        t.Columns.Add("Mesa", typeof(string));
        t.Columns.Add("Usuario", typeof(string));
        t.Columns.Add("IdInvoice", typeof(int));
        t.Columns.Add("IdTicket", typeof(int));
        t.Columns.Add("RelatedInvoiceId", typeof(int));
        t.Columns.Add("TasaUSD", typeof(decimal));
        t.Columns.Add("MontoTotalUSD", typeof(decimal));
        t.Columns.Add("Descuento", typeof(decimal));
        t.Columns.Add("DescuentoPorcentaje", typeof(decimal));
        t.Columns.Add("MontoTotalDescuento", typeof(decimal));
        t.Columns.Add("PosId", typeof(int));
        t.Columns.Add("IdCliente", typeof(int));
        t.Columns.Add("CodigoCliente", typeof(string));
        t.Columns.Add("NombreCliente", typeof(string));


        DataRow f = t.NewRow();
        f["Serie"] = modelo.Serie;
        f["Numero"] = modelo.Numero;
        f["BaseImponible"] = modelo.BaseImponible;
        f["Impuestos"] = modelo.Impuestos;
        f["TotalNeto"] = modelo.TotalNeto;
        f["Fecha"] = modelo.Fecha;
        f["Propina"] = modelo.Propina;
        f["MensajePropina"] = modelo.MensajePropina;
        f["Ubicacion"] = modelo.Ubicacion;
        f["Mesa"] = modelo.Mesa;
        f["Usuario"] = modelo.Usuario;
        f["IdInvoice"] = modelo.IdInvoice;
        f["IdTicket"] = modelo.IdTicket;
        f["RelatedInvoiceId"] = modelo.RelatedInvoiceId;
        f["TasaUSD"] = modelo.TasaUSD;
        f["MontoTotalUSD"] = modelo.MontoTotalUSD;
        f["Descuento"] = modelo.Descuento;
        f["DescuentoPorcentaje"] = modelo.DescuentoPorcentaje;
        f["MontoTotalDescuento"] = modelo.MontoTotalDescuento;
        f["PosId"] = modelo.PosId;
        f["IdCliente"] = modelo.IdCliente;
        f["CodigoCliente"] = modelo.CodigoCliente;
        f["NombreCliente"] = modelo.NombreCliente;
        t.Rows.Add(f);


        return t;

    }
}
