using LET.Agora.Libreria.Impresion.EscPos;
using LET.Agora.Libreria.Impresion.Models;
using LET.Agora.Libreria.Impresion.Utilidades;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace LET.Agora.Libreria.Impresion.Repositories
{
    public class ImpresionService : IImpresionService
    {
        public ServiceResponse<bool> ImprimirFactura(FacturaResponse fr)
        {
            var response = new ServiceResponse<bool>();

            try
            {

                for (int i = 0; i < fr.monitorParametros.Copias; i++)
                {

                    MemoryStream ms = new MemoryStream();
                    BinaryWriter bw = new BinaryWriter(ms);
                    bw.Write('\u001b');
                    bw.Write('@');
      

                    bw.JustifyText(0);
      
                    bw.NormalFont(fr.company.BusinessName);
                    bw.NormalFont($"{fr.company.Street} {fr.company.City}");
                    bw.NormalFont($"Telefono: {fr.company.Telephone}");
                    bw.NormalFont($"RNC: {fr.company.Cif}");
                    
                    bw.JustifyText(0);

                    bw.PrintDashes(42);
                    bw.JustifyText(1);
                    bw.NormalFont($"COMPROBANTE AUTORIZADO POR DGII");
                    bw.JustifyText(0);
                    bw.PrintDashes(42);


              
                   if (fr.facturaComprobanteFiscal.RazonSocial.Length > 0)
                   {
                        bw.NormalFont($"CLIENTE:{fr.facturaComprobanteFiscal.RazonSocial}");
                        bw.NormalFont($"RNC: {fr.facturaComprobanteFiscal.RNC}");
                   }
               
                    bw.NormalFont($"{fr.factura.MensajePropina}");
                    bw.NormalFont($"NCF: {fr.facturaComprobanteFiscal.NCF}");
                    bw.NormalFont($"FACTURA: {fr.factura.Serie}-{Utilidad.RightZeroFill(fr.factura.Numero.ToString())}");
                    bw.NormalFont($"{Convert.ToDateTime(fr.factura.Fecha)}");
                    bw.PrintDashes(42);
                    bw.JustifyText(1);
                    bw.NormalFont($"{fr.facturaComprobanteFiscal.NCFDescripcion}");
                    bw.JustifyText(0);
                    bw.PrintDashes(42);             
                 
                    bw.NormalFont(Utilidad.FormatLineas("DESCRIPCION", "ITBIS", "VALOR", 15, 11, 14));
                      

                   bw.PrintDashes(42);

                        foreach (FacturaDetalle facturadetalle in fr.FacturaDetalles)
                        {
                      
                            if (fr.monitorParametros.LineaImpuesto == 0)
                            {
                                bw.NormalFont(Utilidad.FormatLineas($"{facturadetalle.Cantidad} X {facturadetalle.Precio.ToString("N", new CultureInfo("es-DO"))}", "", facturadetalle.Importe.ToString("N", new CultureInfo("es-DO")), 20, 10, 10));

                            }
                            else if (fr.monitorParametros.LineaImpuesto == 1)
                            {
                                bw.NormalFont(Utilidad.FormatLineas($"{facturadetalle.Cantidad} X {facturadetalle.PrecioUnitario.ToString("N", new CultureInfo("es-DO"))}", "", facturadetalle.MontoTotal.ToString("N", new CultureInfo("es-DO")), 20, 10, 10));
                            }

                            bw.NormalFont(Utilidad.FormatLineas(facturadetalle.Descripcion, "", "", 40, 0, 0));
                            bw.NormalFont(Utilidad.FormatLineas($"%:{Convert.ToInt32(facturadetalle.TasaImpuesto).ToString()}", facturadetalle.Impuesto.ToString(), "", 14, 11, 10));


                            if (facturadetalle.MontoDescuento > 0)
                            {

                                bw.NormalFont(Utilidad.FormatLineas($"Dto: {facturadetalle.MontoDescuento}", "", "", 20, 10, 10));
                            }

                            if (facturadetalle.PorcentajeDescuento > 0)
                            {

                                bw.NormalFont(Utilidad.FormatLineas($"Dto: {facturadetalle.PorcentajeDescuento} % ({facturadetalle.MontoTotalDescuento})", "", "", 25, 10, 10));
                            }

                            var facturaAddins = fr.facturaDetalleAddins.Where(p => p.LineaTicket == facturadetalle.IdTicketLine);

                            foreach (var addins in facturaAddins)
                            {
                                bw.NormalFont(Utilidad.FormatLineas(addins.NombreProducto, "", addins.Precio.ToString(), 20, 10, 10));
                            }

                        }

                        if (fr.factura.Descuento > 0)
                        {
                            bw.NormalFont("");
                            bw.NormalFont(Utilidad.FormatLineas($"Dto. Ticket: {fr.factura.Descuento}", "", "", 20, 10, 10));
                        }

                        if (fr.factura.DescuentoPorcentaje > 0)
                        {
                            bw.NormalFont("");
                            bw.NormalFont(Utilidad.FormatLineas($"Dto. Ticket: {fr.factura.DescuentoPorcentaje} % ({fr.factura.MontoTotalDescuento})", "", "", 25, 10, 10));
                        }

                        bw.PrintDashes(42);

                        bw.NormalFont(Utilidad.FormatLineas("SUBTOTAL: ", Convert.ToString(fr.factura.Impuestos.ToString("N", new CultureInfo("es-DO"))), Convert.ToString(fr.factura.BaseImponible.ToString("N", new CultureInfo("es-DO"))), 14, 11, 15).Trim());
                        bw.NormalFont(Utilidad.FormatLineas("TOTAL: ", Convert.ToString(fr.factura.Impuestos.ToString("N", new CultureInfo("es-DO"))), fr.factura.TotalNeto.ToString("N", new CultureInfo("es-DO")), 14, 11, 15).Trim());
                       

                        if (fr.factura.Propina > 0)
                        {
                            bw.NormalFont(Utilidad.FormatLineas(fr.factura.MensajePropina, "", Convert.ToString(fr.factura.Propina.ToString("N", new CultureInfo("es-DO"))), 20, 10, 10).Trim());
                        }


                        bw.PrintDashes(42);


                        foreach (FacturaFormaPago formapago in fr.facturaFormaPagos)
                        {
                            bw.NormalFont(Utilidad.FormatLineas(formapago.DescripcionPago, "", formapago.TotalPagado.ToString("N", new CultureInfo("es-DO")), 20, 10, 10));

                            if (formapago.TotalDevuelta > 0)
                            {
                                bw.NormalFont(Utilidad.FormatLineas("CAMBIO:", "", formapago.TotalDevuelta.ToString("N", new CultureInfo("es-DO")), 20, 10, 10));
                            }
                        }

                        bw.PrintDashes(42);

                        if (fr.factura.Propina > 0)
                        {
                            bw.NormalFont($"CENTRO DE VENTA: {fr.factura.Ubicacion}");
                            bw.NormalFont($"MESA: {fr.factura.Mesa}");
                        }


                        bw.NormalFont($"CAJERO: {fr.factura.Usuario}");

                        if (fr.factura.IdCliente > 0)
                        {
                            bw.NormalFont("");
                            bw.NormalFont($"CODIGO CLIENTE: {fr.factura.CodigoCliente}");
                            bw.NormalFont($"NOMBRE: {fr.factura.NombreCliente}");
                        }   

                        if (fr.comentarioPiePaginas.Count() > 0)
                        {
                            foreach (ComentarioPiePagina pcomentario in fr.comentarioPiePaginas)
                            {
                                bw.NormalFont(pcomentario.Descripcion);
                            }
                        }

                        bw.PrintDashes(42);

                        bw.Write('\u001d');
                        bw.Write('V');
                        bw.Write((byte)66);
                        bw.Write((byte)3);
                        bw.Flush();

                        Print(fr.monitorParametros.NombrePrinter, ms.ToArray());

                

                    response.Mensaje = "";
                    response.Exito = true;
             }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;

                response.Exito = false;
                Logs.WriteLog(ex.Message);
            }


            return response;
        }

        private static void Print(string printerName, byte[] document)
        {

            NativeMethods.DOC_INFO_1 dOC_INFO_ = new NativeMethods.DOC_INFO_1();
            dOC_INFO_.pDataType = "RAW";
            dOC_INFO_.pDocName = "Receipt";
            IntPtr hPrinter = new IntPtr(0);
            if (NativeMethods.OpenPrinter(printerName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (NativeMethods.StartDocPrinter(hPrinter, 1, dOC_INFO_))
                {
                    IntPtr intPtr = Marshal.AllocCoTaskMem(document.Length);
                    Marshal.Copy(document, 0, intPtr, document.Length);
                    if (NativeMethods.StartPagePrinter(hPrinter))
                    {
                        NativeMethods.WritePrinter(hPrinter, intPtr, document.Length, out var _);
                        NativeMethods.EndPagePrinter(hPrinter);
                        Marshal.FreeCoTaskMem(intPtr);
                        NativeMethods.EndDocPrinter(hPrinter);
                        NativeMethods.ClosePrinter(hPrinter);
                        return;
                    }
                    throw new Win32Exception();
                }
                throw new Win32Exception();
            }
            throw new Win32Exception();

        }
    }
}
