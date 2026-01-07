using System.Data;

namespace LET.Agora.Application.Models;

public class FacturaFormaPago
{
    public int IdPago { get; set; }
    public string Serie { get; set; }
    public int Numero { get; set; }
    public int IdFormaPago { get; set; }
    public int PosId { get; set; }
    public int IdTransaccionTarjeta { get; set; }
    public DateTime Fecha { get; set; }
    public decimal TotalPagado { get; set; }
    public decimal TotalDevuelta { get; set; }
    public decimal TotalPropina { get; set; }
    public string InformacionExtra { get; set; }
    public string DescripcionPago { get; set; }

    public static DataTable ToDataTable(List<FacturaFormaPago> modelo)
    {

        DataTable t = new DataTable();

        t.Columns.Add("IdPago", typeof(int));
        t.Columns.Add("Serie", typeof(string));
        t.Columns.Add("Numero", typeof(int));
        t.Columns.Add("IdFormaPago", typeof(int));
        t.Columns.Add("PosId", typeof(int));
        t.Columns.Add("IdTransaccionTarjeta", typeof(int));
        t.Columns.Add("Fecha", typeof(DateTime));
        t.Columns.Add("TotalPagado", typeof(decimal));
        t.Columns.Add("TotalDevuelta", typeof(decimal));
        t.Columns.Add("TotalPropina", typeof(decimal));
        t.Columns.Add("InformacionExtra", typeof(string));
        t.Columns.Add("DescripcionPago", typeof(string));

        modelo.ForEach(e =>
        {
            DataRow f = t.NewRow();
            f["IdPago"] = e.IdPago;
            f["Serie"] = e.Serie;
            f["Numero"] = e.Numero;
            f["IdFormaPago"] = e.IdFormaPago;
            f["PosId"] = e.PosId;
            f["IdTransaccionTarjeta"] = e.IdTransaccionTarjeta;
            f["Fecha"] = e.Fecha;
            f["TotalPagado"] = e.TotalPagado;
            f["TotalDevuelta"] = e.TotalDevuelta;
            f["TotalPropina"] = e.TotalPropina;
            f["InformacionExtra"] = e.InformacionExtra;
            f["DescripcionPago"] = e.DescripcionPago;

            t.Rows.Add(f);
        });

        return t;
    }
}
