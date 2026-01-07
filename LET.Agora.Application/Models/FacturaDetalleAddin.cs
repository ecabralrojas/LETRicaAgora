using System.Data;

namespace LET.Agora.Application.Models;

public class FacturaDetalleAddin
{
    public string Serie { get; set; }
    public int Numero { get; set; }
    public int LineaTicket { get; set; }
    public int FormatoIdVenta { get; set; }
    public string NombreProducto { get; set; }
    public decimal Precio { get; set; }
    public int IdImpuesto { get; set; }
    public decimal TasaImpuesto { get; set; }
    public decimal PrecioCosto { get; set; }
    public int AddinIndex { get; set; }
    public int PosId { get; set; }

    public static DataTable ToDataTable(List<FacturaDetalleAddin> modelo)
    {
        DataTable t = new DataTable();
        t.Columns.Add("Serie", typeof(string));
        t.Columns.Add("Numero", typeof(int));
        t.Columns.Add("LineaTicket", typeof(int));
        t.Columns.Add("FormatoIdVenta", typeof(int));
        t.Columns.Add("NombreProducto", typeof(string));
        t.Columns.Add("Precio", typeof(decimal));
        t.Columns.Add("IdImpuesto", typeof(int));
        t.Columns.Add("TasaImpuesto", typeof(decimal));
        t.Columns.Add("PrecioCosto", typeof(decimal));
        t.Columns.Add("AddinIndex", typeof(int));
        t.Columns.Add("PosId", typeof(int));

        modelo.ForEach(e =>
        {
            DataRow f = t.NewRow();
            f["Serie"] = e.Serie;
            f["Numero"] = e.Numero;
            f["LineaTicket"] = e.LineaTicket;
            f["FormatoIdVenta"] = e.FormatoIdVenta;
            f["NombreProducto"] = e.NombreProducto;
            f["Precio"] = e.Precio;
            f["IdImpuesto"] = e.IdImpuesto;
            f["TasaImpuesto"] = e.TasaImpuesto;
            f["PrecioCosto"] = e.PrecioCosto;
            f["AddinIndex"] = e.AddinIndex;
            f["PosId"] = e.PosId;
            t.Rows.Add(f);
        });


        return t;
    }
}
