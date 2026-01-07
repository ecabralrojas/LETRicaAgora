using Dapper;
using LET.Agora.Application.Models;
using LET.Agora.Database;
using System.Data;
namespace LET.Agora.Application.Repositories;

public class FacturaRepository : IFacturaRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public FacturaRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobantesFiscales(string serie)
    {
        var response = new ServiceResponse<IEnumerable<NCFSecuencia>>();

        try
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            var p = new DynamicParameters();
            p.Add("@Serie", serie);
            response.Data = await connection.QueryAsync<NCFSecuencia>("ObtenerComprobantesFiscales",p, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            response.Mensaje = ex.Message;
            response.Exito = false;

        }

        return response;
    }
    public async Task<ServiceResponse<RNCDGII>> ObtenerRNC(string rnc)
    {
        var response = new ServiceResponse<RNCDGII>();

        try
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            var p = new DynamicParameters();
            p.Add("@RNC", rnc);
            response.Data = await connection.QueryFirstOrDefaultAsync<RNCDGII>("ObtenerRNC", p, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            response.Exito = false;
            response.Mensaje = ex.Message;  
            
        }

        return response;    
    }
    public async Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(string serie, int number)
    {
        var response = new ServiceResponse<FacturaAgora>();
        try
        {
            using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
            {
                var p = new DynamicParameters();
                p.Add("@Serie", serie);
                p.Add("@Number", number);
                var result = await connection.QueryMultipleAsync("ObtenerFacturaAgora", p, commandType: CommandType.StoredProcedure);
                var factura = await result.ReadFirstAsync<Factura>();
                var facturadetalle = result.Read<FacturaDetalle>().ToList();
                var facturaaddins = result.Read<FacturaDetalleAddin>().ToList();
                var facturaformapago = result.Read<FacturaFormaPago>().ToList();

                FacturaAgora letFacturasEnviar = new FacturaAgora()
                {
                    factura = factura,
                    FacturaDetalles = facturadetalle,
                    facturaDetalleAddins = facturaaddins,                    
                    facturaFormaPagos = facturaformapago,
                };

                response.Data = letFacturasEnviar;
            }
        }
        catch (Exception ex)
        {
            response.Exito = false;
            response.Mensaje = ex.Message;

        }

        return response;
    }

    //public async Task<ServiceResponse<FacturaResponse>> ObtenerFacturaAgora(string serie, int number)
    //{
    //    var response = new ServiceResponse<FacturaResponse>();
    //    try
    //    {
    //        using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
    //        {
    //            var p = new DynamicParameters();
    //            p.Add("@Serie", serie);
    //            p.Add("@Number", number);
    //            var result = await connection.QueryMultipleAsync("ObtenerFacturaAgora", p, commandType: CommandType.StoredProcedure);
    //            var factura = await result.ReadFirstAsync<Factura>();
    //            var facturadetalle = result.Read<FacturaDetalle>().ToList();
    //            var facturaaddins = result.Read<FacturaDetalleAddin>().ToList();
    //            var facturaformapago = result.Read<FacturaFormaPago>().ToList();
    //            var monitorParametros = result.ReadFirst<MonitorParametros>();
    //            var comentarioCabeceras = result.Read<ComentarioCabecera>().AsList();
    //            var comentarioPiePaginas = result.Read<ComentarioPiePagina>().AsList();
    //            var company = result.ReadFirst<Company>();


    //            FacturaResponse letFacturasEnviar = new FacturaResponse()
    //            {
    //                factura = factura,
    //                FacturaDetalles = facturadetalle,
    //                facturaDetalleAddins = facturaaddins,
    //                facturaFormaPagos = facturaformapago,
    //                monitorParametros = monitorParametros,  
    //                comentarioCabeceras = comentarioCabeceras,    
    //                comentarioPiePaginas = comentarioPiePaginas,
    //                company = company 
    //            };

    //            response.Data = letFacturasEnviar;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        response.Exito = false;
    //        response.Mensaje = ex.Message;

    //    }

    //    return response;
    //}

    public async Task<ServiceResponse<bool>> RegistrarFacturaAgora_bk(FacturaAgora facturaAgora)
    {
        var response = new ServiceResponse<bool>(); 

        try
        {
            var dtFactura = Factura.ToDataTable(facturaAgora.factura);
            var dtFacturaDetalle = FacturaDetalle.ToDataTable(facturaAgora.FacturaDetalles.ToList());
            var dtFacturaFormaPagos = FacturaFormaPago.ToDataTable(facturaAgora.facturaFormaPagos.ToList());
            var dtfacturaDetalleAddins = FacturaDetalleAddin.ToDataTable(facturaAgora.facturaDetalleAddins.ToList());

            using var connection = await _dbConnectionFactory.CreateConnectionAsync();

            var p = new DynamicParameters();
            p.Add("@udtFactura", dtFactura.AsTableValuedParameter("udtFactura"));
            p.Add("@udtFacturaDetalle", dtFacturaDetalle.AsTableValuedParameter("udtFacturaDetalle"));
            p.Add("@udtFacturaFormaPago", dtFacturaFormaPagos.AsTableValuedParameter("udtFacturaFormaPago"));
            p.Add("@udtFacturaDetalleAddin", dtfacturaDetalleAddins.AsTableValuedParameter("udtFacturaDetalleAddin"));
            p.Add("@TipoComprobante", facturaAgora.TipoComprobante);
            p.Add("@RNC", facturaAgora.rnc);
            p.Add("@Mensaje", "", dbType: DbType.String, direction: ParameterDirection.Output);
            p.Add("@Respuesta", "", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var resultado = await connection.ExecuteAsync("RegistrarFacturaAgora", p, commandType: CommandType.StoredProcedure);

            response.Mensaje = p.Get<string>("@Mensaje");
            int respuesta = p.Get<int>("@Respuesta");
            response.Data = (resultado > 0) ? true : false;

        }
        catch (Exception ex)
        {
            response.Exito = false;
            response.Mensaje =ex.Message;               
        }

        return response;
    }

    public async Task<ServiceResponse<FacturaResponse>> RegistrarFacturaAgora(FacturaAgora facturaAgora)
    {
        var response = new ServiceResponse<FacturaResponse>
        {
            Data = new FacturaResponse()
        };


        try
        {
            var dtFactura = Factura.ToDataTable(facturaAgora.factura);
            var dtFacturaDetalle = FacturaDetalle.ToDataTable(facturaAgora.FacturaDetalles.ToList());
            var dtFacturaFormaPagos = FacturaFormaPago.ToDataTable(facturaAgora.facturaFormaPagos.ToList());
            var dtfacturaDetalleAddins = FacturaDetalleAddin.ToDataTable(facturaAgora.facturaDetalleAddins.ToList());

            using var connection = await _dbConnectionFactory.CreateConnectionAsync();

            var p = new DynamicParameters();
            p.Add("@udtFactura", dtFactura.AsTableValuedParameter("udtFactura"));
            p.Add("@udtFacturaDetalle", dtFacturaDetalle.AsTableValuedParameter("udtFacturaDetalle"));
            p.Add("@udtFacturaFormaPago", dtFacturaFormaPagos.AsTableValuedParameter("udtFacturaFormaPago"));
            p.Add("@udtFacturaDetalleAddin", dtfacturaDetalleAddins.AsTableValuedParameter("udtFacturaDetalleAddin"));
            p.Add("@TipoComprobante", facturaAgora.TipoComprobante);
            p.Add("@RNC", facturaAgora.rnc);
            p.Add("@Mensaje", "", dbType: DbType.String, direction: ParameterDirection.Output);
            p.Add("@Respuesta", "", dbType: DbType.Int32, direction: ParameterDirection.Output);            

            using (var multi = connection.QueryMultiple("RegistrarFacturaAgora", p, commandType: CommandType.StoredProcedure))
            {
                response.Data.factura = multi.ReadFirst<Factura>();
                response.Data.FacturaDetalles = multi.Read<FacturaDetalle>().AsList();
                response.Data.facturaComprobanteFiscal = multi.ReadFirst<FacturaComprobanteFiscal>();
                response.Data.facturaFormaPagos = multi.Read<FacturaFormaPago>().AsList();
                response.Data.facturaDetalleAddins = multi.Read<FacturaDetalleAddin>().AsList();
                response.Data.monitorParametros = multi.ReadFirst<MonitorParametros>();
                response.Data.comentarioCabeceras = multi.Read<ComentarioCabecera>().AsList();
                response.Data.comentarioPiePaginas = multi.Read<ComentarioPiePagina>().AsList();
                response.Data.company = multi.ReadFirst<Company>();
            }

            response.Mensaje = p.Get<string>("@Mensaje");
            response.Exito = p.Get<int>("@Respuesta") == 0;            

        }
        catch (Exception ex)
        {
            response.Exito = false;
            response.Mensaje = ex.Message;
        }

        return response;
    }
}
