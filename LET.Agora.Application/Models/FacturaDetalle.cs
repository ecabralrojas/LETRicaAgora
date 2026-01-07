using System.Data;

namespace LET.Agora.Application.Models;

public class FacturaDetalle
{
    public string Serie { get; set; }
    public int Numero { get; set; }
    public int Linea { get; set; }
    public decimal Cantidad { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Importe { get; set; }
    public int IdTicket { get; set; }
    public int IdTicketLine { get; set; }
    public int IdInvoice { get; set; }
    public decimal TasaImpuesto { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal MontoTotal { get; set; }
    public decimal MontoDescuento { get; set; }
    public decimal PorcentajeDescuento { get; set; }
    public decimal MontoTotalDescuento { get; set; }
    public int PosId { get; set; }

    public static DataTable ToDataTable(List<FacturaDetalle> modelo)
    {
        DataTable t = new DataTable();

        t.Columns.Add("Serie", typeof(string));
        t.Columns.Add("Numero", typeof(string));
        t.Columns.Add("Linea", typeof(int));
        t.Columns.Add("Cantidad", typeof(decimal));
        t.Columns.Add("Descripcion", typeof(string));
        t.Columns.Add("Precio", typeof(decimal));
        t.Columns.Add("Impuesto", typeof(decimal));
        t.Columns.Add("Importe", typeof(decimal));
        t.Columns.Add("IdTicket", typeof(decimal));
        t.Columns.Add("IdTicketLine", typeof(decimal));
        t.Columns.Add("IdInvoice", typeof(decimal));
        t.Columns.Add("TasaImpuesto", typeof(decimal));
        t.Columns.Add("PrecioUnitario", typeof(decimal));
        t.Columns.Add("MontoTotal", typeof(decimal));
        t.Columns.Add("MontoDescuento", typeof(decimal));
        t.Columns.Add("PorcentajeDescuento", typeof(decimal));
        t.Columns.Add("MontoTotalDescuento", typeof(decimal));
        t.Columns.Add("PosId", typeof(int));


        modelo.ForEach(e =>
        {
            DataRow f = t.NewRow();
            f["Serie"] = e.Serie;
            f["Numero"] = e.Numero;
            f["Linea"] = e.Linea;
            f["Cantidad"] = e.Cantidad;
            f["Descripcion"] = e.Descripcion;
            f["Precio"] = e.Precio;
            f["Impuesto"] = e.Impuesto;
            f["Importe"] = e.Importe;
            f["IdTicket"] = e.IdTicket;
            f["IdTicketLine"] = e.IdTicketLine;
            f["IdInvoice"] = e.IdInvoice;
            f["TasaImpuesto"] = e.TasaImpuesto;
            f["PrecioUnitario"] = e.PrecioUnitario;
            f["MontoTotal"] = e.MontoTotal;
            f["MontoDescuento"] = e.MontoDescuento;
            f["PorcentajeDescuento"] = e.PorcentajeDescuento;
            f["MontoTotalDescuento"] = e.MontoTotalDescuento;
            f["PosId"] = e.PosId;

            t.Rows.Add(f);

        });

        return t;

    }
}
