using System.Collections.Generic;
using System.Data;
namespace marcatel_api.Models
{
    public class DetalleModel
    {
        
        public string Codigo { get; set; }
        public string UM { get; set; }
        public float Cantidad { get; set; }
        public string Descripcion { get; set; }
        public float Iva { get; set; }
        public float PrecioOriginal { get; set; }
        public float PrecioFinal { get; set; }
        public float Ieps { get; set; }
        public float PrecioOriginalImpuestos { get; set; }
        public float PrecioFinalImpuestos { get; set; }
        public float TotalRenglon { get; set; }
        public float TotalRenglonImpuestos { get; set; }
        public string FolioTicket { get; set; }
        public string FolioInterno { get; set; }
        public int Folio { get; set; }
        public int ConsecutivoLocal { get; set; }
        public int Id { get; set; }
        public decimal IepsSeis {get; set;}
        public int BoolOferta {get; set;}
        public int Departamento {get; set;}

    }

    public class PagoParcialTicket
    {
        public int Id {get; set;}
        public int IdTipo {get;set;}
        public string Tipo {get; set;}
        public decimal Monto {get;set;}
        public string FolioInterno {get;set;}

    }

    public class InsertDetalleReq
    {
        public int Id {get;set ;}
        public DataTable Detalle { get; set; }
    }

    public class InsertBodyReq
    {
        public int Id {get; set;}
        public List<RenglonTicketModelDT> Detalle {get; set;}
    }


    public class RenglonTicketModelDT
    {
        public int CTBS_CIA {get; set;}
	    public int TICC_SUCURSAL {get; set;}
	    public string TICN_AAAAMMDDVENTA {get; set;}
	    public int TICN_FOLIO {get; set;}
	    public int ARTN_CONSECUTIVO {get ; set; }
        public string ARTC_ARTICULO {get; set;}
        public decimal ARTN_CANTIDAD {get; set;}
        public decimal ARTN_PRECIOVENTA {get; set;}
        public string ARTC_UNIMEDIDA {get; set;}
        public decimal ARTN_DESCUENTO {get; set;}
        public decimal ARTN_PRECIOORIGINAL {get; set;}
        public decimal  ARTN_MONTO_IMPUESTOS {get; set;}
        public decimal ARTN_MONTO_IVA {get; set;}
        public decimal ARTN_MONTO_IEPS {get; set;}
        public int ARTN_ESPAQUETE {get; set;}
        public int IdTicket {get; set;}
    }

    public class EstadoMercadoModel
    {
        public int Estado {get;set;}
        public int SolicitaCorte {get; set;}
    }

    public class GetEstadoMercado
    {
        public int Caja {get; set;}
        
    }
    
}
