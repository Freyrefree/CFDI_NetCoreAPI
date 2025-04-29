using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDI
{

	[XmlRoot(ElementName = "Emisor")]
	public class Emisor
	{

		[XmlAttribute(AttributeName = "Rfc")]
		public string Rfc { get; set; }

		[XmlAttribute(AttributeName = "Nombre")]
		public string Nombre { get; set; }

		[XmlAttribute(AttributeName = "RegimenFiscal")]
		public int RegimenFiscal { get; set; }
	}

	[XmlRoot(ElementName = "Receptor")]
	public class Receptor
	{

		[XmlAttribute(AttributeName = "Rfc")]
		public string Rfc { get; set; }

		[XmlAttribute(AttributeName = "Nombre")]
		public string Nombre { get; set; }

		[XmlAttribute(AttributeName = "UsoCFDI")]
		public string UsoCFDI { get; set; }

		[XmlAttribute(AttributeName = "DomicilioFiscalReceptor")]
		public int DomicilioFiscalReceptor { get; set; }

		[XmlAttribute(AttributeName = "RegimenFiscalReceptor")]
		public int RegimenFiscalReceptor { get; set; }
	}

	[XmlRoot(ElementName = "Traslado")]
	public class Traslado
	{

		[XmlAttribute(AttributeName = "Base")]
		public double Base { get; set; }

		[XmlAttribute(AttributeName = "Impuesto")]
		public int Impuesto { get; set; }

		[XmlAttribute(AttributeName = "TipoFactor")]
		public string TipoFactor { get; set; }

		[XmlAttribute(AttributeName = "TasaOCuota")]
		public double TasaOCuota { get; set; }

		[XmlAttribute(AttributeName = "Importe")]
		public double Importe { get; set; }
	}

	[XmlRoot(ElementName = "Traslados")]
	public class Traslados
	{

		[XmlElement(ElementName = "Traslado")]
		public Traslado Traslado { get; set; }
	}

	[XmlRoot(ElementName = "Impuestos")]
	public class Impuestos
	{

		[XmlElement(ElementName = "Traslados")]
		public Traslados Traslados { get; set; }

		[XmlAttribute(AttributeName = "TotalImpuestosTrasladados")]
		public double TotalImpuestosTrasladados { get; set; }
	}

	[XmlRoot(ElementName = "Concepto")]
	public class Concepto
	{

		[XmlElement(ElementName = "Impuestos")]
		public Impuestos Impuestos { get; set; }

		[XmlAttribute(AttributeName = "ClaveProdServ")]
		public int ClaveProdServ { get; set; }

		[XmlAttribute(AttributeName = "NoIdentificacion")]
		public int NoIdentificacion { get; set; }

		[XmlAttribute(AttributeName = "Cantidad")]
		public Double Cantidad { get; set; }

		[XmlAttribute(AttributeName = "ClaveUnidad")]
		public string ClaveUnidad { get; set; }

		[XmlAttribute(AttributeName = "Descripcion")]
		public string Descripcion { get; set; }

		[XmlAttribute(AttributeName = "ValorUnitario")]
		public double ValorUnitario { get; set; }

		[XmlAttribute(AttributeName = "Importe")]
		public double Importe { get; set; }

		[XmlAttribute(AttributeName = "Unidad")]
		public string Unidad { get; set; }

		[XmlAttribute(AttributeName = "ObjetoImp")]
		public int ObjetoImp { get; set; }


    }

	[XmlRoot(ElementName = "Conceptos")]
	public class Conceptos
	{

        //[XmlElement(ElementName = "Concepto")]
        //public Concepto Concepto { get; set; }
        [XmlElement(ElementName = "Concepto")]
        public List<Concepto> Concepto { get; set; }

    }

	[XmlRoot(ElementName = "TimbreFiscalDigital")]
	public class TimbreFiscalDigital
	{

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation { get; set; }

		[XmlAttribute(AttributeName = "Version")]
		public String Version { get; set; }

		[XmlAttribute(AttributeName = "UUID")]
		public string UUID { get; set; }

		[XmlAttribute(AttributeName = "FechaTimbrado")]
		public DateTime FechaTimbrado { get; set; }

		[XmlAttribute(AttributeName = "RfcProvCertif")]
		public string RfcProvCertif { get; set; }

		[XmlAttribute(AttributeName = "SelloCFD")]
		public string SelloCFD { get; set; }

		[XmlAttribute(AttributeName = "NoCertificadoSAT")]
		public double NoCertificadoSAT { get; set; }

		[XmlAttribute(AttributeName = "SelloSAT")]
		public string SelloSAT { get; set; }

		[XmlAttribute(AttributeName = "tfd")]
		public string Tfd { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }
	}

	[XmlRoot(ElementName = "Complemento")]
	public class Complemento
	{

		[XmlElement(ElementName = "TimbreFiscalDigital")]
		public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
	}

	[XmlRoot(ElementName = "Cab")]
	public class Cab
	{

		[XmlAttribute(AttributeName = "IDDOCUMENTO")]
		public string IDDOCUMENTO { get; set; }

		[XmlAttribute(AttributeName = "IMPLETRA")]
		public string IMPLETRA { get; set; }

		[XmlAttribute(AttributeName = "NOMEMI")]
		public object NOMEMI { get; set; }

		[XmlAttribute(AttributeName = "CALLEEMI")]
		public string CALLEEMI { get; set; }

		[XmlAttribute(AttributeName = "COLEMI")]
		public object COLEMI { get; set; }

		[XmlAttribute(AttributeName = "NUMEMI")]
		public int NUMEMI { get; set; }

		[XmlAttribute(AttributeName = "EDOEMI")]
		public string EDOEMI { get; set; }

		[XmlAttribute(AttributeName = "CPEMI")]
		public int CPEMI { get; set; }

		[XmlAttribute(AttributeName = "CALLEEXP")]
		public string CALLEEXP { get; set; }

		[XmlAttribute(AttributeName = "COLEXP")]
		public object COLEXP { get; set; }

		[XmlAttribute(AttributeName = "NUMEXP")]
		public string NUMEXP { get; set; }

		[XmlAttribute(AttributeName = "EDOEEXP")]
		public string EDOEEXP { get; set; }

		[XmlAttribute(AttributeName = "CPEXP")]
		public int CPEXP { get; set; }

		[XmlAttribute(AttributeName = "CALLEREC")]
		public string CALLEREC { get; set; }

		[XmlAttribute(AttributeName = "COLREC")]
		public object COLREC { get; set; }

		[XmlAttribute(AttributeName = "NUMREC")]
		public string NUMREC { get; set; }

		[XmlAttribute(AttributeName = "EDOREC")]
		public string EDOREC { get; set; }

		[XmlAttribute(AttributeName = "CPREC")]
		public int CPREC { get; set; }

		[XmlAttribute(AttributeName = "NOMDEST")]
		public string NOMDEST { get; set; }

		[XmlAttribute(AttributeName = "RFCDEST")]
		public object RFCDEST { get; set; }

		[XmlAttribute(AttributeName = "CALLEDEST")]
		public string CALLEDEST { get; set; }

		[XmlAttribute(AttributeName = "COLDEST")]
		public object COLDEST { get; set; }

		[XmlAttribute(AttributeName = "NUMDEST")]
		public string NUMDEST { get; set; }

		[XmlAttribute(AttributeName = "EDODEST")]
		public string EDODEST { get; set; }

		[XmlAttribute(AttributeName = "CPDEST")]
		public int CPDEST { get; set; }

		[XmlAttribute(AttributeName = "CLIENTSAP")]
		public int CLIENTSAP { get; set; }

		[XmlAttribute(AttributeName = "COMENCAB")]
		public string COMENCAB { get; set; }

		[XmlAttribute(AttributeName = "ZONA")]
		public object ZONA { get; set; }

		[XmlAttribute(AttributeName = "DESCDOC")]
		public string DESCDOC { get; set; }

		[XmlAttribute(AttributeName = "CANAL")]
		public int CANAL { get; set; }

		[XmlAttribute(AttributeName = "PEDIDOSAP")]
		public int PEDIDOSAP { get; set; }

		[XmlAttribute(AttributeName = "VENDEDOR")]
		public object VENDEDOR { get; set; }

		[XmlAttribute(AttributeName = "TOTPZA")]
		public string TOTPZA { get; set; }

		[XmlAttribute(AttributeName = "INCOTERM")]
		public string INCOTERM { get; set; }

		[XmlAttribute(AttributeName = "VENCIMIENTO")]
		public string VENCIMIENTO { get; set; }

		[XmlAttribute(AttributeName = "CIE")]
		public object CIE { get; set; }

		[XmlAttribute(AttributeName = "ORDCOMP")]
		public string ORDCOMP { get; set; }

		[XmlAttribute(AttributeName = "EMAILCONTACTO")]
		public string EMAILCONTACTO { get; set; }
	}

	[XmlRoot(ElementName = "POS")]
	public class POS_
	{

		[XmlAttribute(AttributeName = "POS")]
		public int POS { get; set; }

		[XmlAttribute(AttributeName = "NoIdentificacion")]
		public int NoIdentificacion { get; set; }

		[XmlAttribute(AttributeName = "SERIE")]
		public object SERIE { get; set; }

		[XmlAttribute(AttributeName = "NCLIENT")]
		public int NCLIENT { get; set; }

		[XmlAttribute(AttributeName = "COMENTPOS")]
		public object COMENTPOS { get; set; }

		[XmlAttribute(AttributeName = "LOTE")]
		public string LOTE { get; set; }

		[XmlAttribute(AttributeName = "UNIDAD")]
		public string UNIDAD { get; set; }

		[XmlAttribute(AttributeName = "CANTIDAD")]
		public DateTime CANTIDAD { get; set; }

		[XmlAttribute(AttributeName = "CODIGO")]
		public int CODIGO { get; set; }
	}

	[XmlRoot(ElementName = "Posiciones")]
	public class Posiciones
	{

		[XmlElement(ElementName = "POS")]
		public POS_ POS { get; set; }
	}

	[XmlRoot(ElementName = "Documento")]
	public class Documento
	{

		[XmlElement(ElementName = "Cab")]
		public Cab Cab { get; set; }

		[XmlElement(ElementName = "Posiciones")]
		public Posiciones Posiciones { get; set; }

		[XmlAttribute(AttributeName = "FormatoXML")]
		public object FormatoXML { get; set; }

		[XmlAttribute(AttributeName = "Logo")]
		public string Logo { get; set; }

		[XmlAttribute(AttributeName = "ColorXML")]
		public string ColorXML { get; set; }
	}

	[XmlRoot(ElementName = "facturasap")]
	public class Facturasap
	{

		[XmlElement(ElementName = "Documento")]
		public Documento Documento { get; set; }

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation { get; set; }

		[XmlAttribute(AttributeName = "Version")]
		public int Version { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }
	}

	[XmlRoot(ElementName = "Addenda")]


    public class Addenda
    {
		[XmlElement(ElementName = "facturasap")]
		public Facturasap Facturasap { get; set; }

		[XmlElement(ElementName = "requestForPayment")]
        public RequestForPayment RequestForPayment { get; set; }
    }

    [XmlRoot(ElementName = "Comprobante")]
	public class Comprobante
	{

		[XmlElement(ElementName = "Emisor")]
		public Emisor Emisor { get; set; }

		[XmlElement(ElementName = "Receptor")]
		public Receptor Receptor { get; set; }

		[XmlElement(ElementName = "Conceptos")]
		public Conceptos Conceptos { get; set; }

		[XmlElement(ElementName = "Impuestos")]
		public Impuestos Impuestos { get; set; }

		[XmlElement(ElementName = "Complemento")]
		public Complemento Complemento { get; set; }

        [XmlElement(ElementName = "ComercioExterior")]
        public ComercioExterior ComercioExterior { get; set; }

        [XmlElement(ElementName = "Addenda")]
		public Addenda Addenda { get; set; }

        [XmlElement(ElementName = "Cab")]
        public Cab Cab { get; set; }

        [XmlAttribute(AttributeName = "cce11")]
		public string Cce11 { get; set; }

		[XmlAttribute(AttributeName = "cfdi")]
		public string Cfdi { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation { get; set; }

		[XmlAttribute(AttributeName = "Version")]
		public string Version { get; set; }

		[XmlAttribute(AttributeName = "Serie")]
		public string Serie { get; set; }

		[XmlAttribute(AttributeName = "Folio")]
		public long Folio { get; set; }

		[XmlAttribute(AttributeName = "Fecha")]
		public DateTime Fecha { get; set; }

		[XmlAttribute(AttributeName = "FormaPago")]
		public int FormaPago { get; set; }

		[XmlAttribute(AttributeName = "CondicionesDePago")]
		public string CondicionesDePago { get; set; }

		[XmlAttribute(AttributeName = "SubTotal")]
		public double SubTotal { get; set; }

		[XmlAttribute(AttributeName = "Moneda")]
		public string Moneda { get; set; }

		[XmlAttribute(AttributeName = "TipoCambio")]
		public string TipoCambio { get; set; }

		[XmlAttribute(AttributeName = "Total")]
		public string Total { get; set; }

		[XmlAttribute(AttributeName = "TipoDeComprobante")]
		public string TipoDeComprobante { get; set; }

		[XmlAttribute(AttributeName = "MetodoPago")]
		public string MetodoPago { get; set; }

		[XmlAttribute(AttributeName = "LugarExpedicion")]
		public int LugarExpedicion { get; set; }

		[XmlAttribute(AttributeName = "Exportacion")]
		public int Exportacion { get; set; }

		[XmlAttribute(AttributeName = "NoCertificado")]
		public string NoCertificado { get; set; }

		[XmlAttribute(AttributeName = "Certificado")]
		public string Certificado { get; set; }

		[XmlAttribute(AttributeName = "Sello")]
		public string Sello { get; set; }

        [XmlAttribute(AttributeName = "Pagos")]
        public Pagos Pagos { get; set; }
    }

    [XmlRoot(ElementName = "requestForPayment", Namespace = "http://www.sat.gob.mx/cfd/4")]
    public class RequestForPayment
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "contentVersion")]
        public string ContentVersion { get; set; }

        [XmlAttribute(AttributeName = "documentStructureVersion")]
        public string DocumentStructureVersion { get; set; }

        [XmlAttribute(AttributeName = "documentStatus")]
        public string DocumentStatus { get; set; }

        [XmlAttribute(AttributeName = "DeliveryDate")]
        public DateTime DeliveryDate { get; set; }

        public RequestForPaymentIdentification RequestForPaymentIdentification { get; set; }
        public SpecialInstruction SpecialInstruction { get; set; }
        public OrderIdentification OrderIdentification { get; set; }
        public AdditionalInformation AdditionalInformation { get; set; }
        public Buyer Buyer { get; set; }
        public Seller Seller { get; set; }
        public LineItem LineItem { get; set; }
        public BaseAmount BaseAmount { get; set; }
        public Tax VAT { get; set; }
        public Tax GST { get; set; }
        public PayableAmount PayableAmount { get; set; }
    }

    public class RequestForPaymentIdentification
    {
        public string EntityType { get; set; }
        public string UniqueCreatorIdentification { get; set; }
    }

    public class SpecialInstruction
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        public string Text { get; set; }
    }

    public class OrderIdentification
    {
        public string ReferenceIdentification { get; set; }
    }

    public class AdditionalInformation
    {
        public string ReferenceIdentification { get; set; }
    }

    public class Buyer
    {
        public string GLN { get; set; }
    }

    public class Seller
    {
        public string GLN { get; set; }

        [XmlElement(ElementName = "alternatePartyIdentification")]
        public AlternatePartyIdentification AlternatePartyIdentification { get; set; }
    }

    public class AlternatePartyIdentification
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class LineItem
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }

        public TradeItemIdentification TradeItemIdentification { get; set; }
        public TradeItemDescriptionInformation TradeItemDescriptionInformation { get; set; }
        public InvoicedQuantity InvoicedQuantity { get; set; }
        public AditionalQuantity AditionalQuantity { get; set; }
        public NetPrice NetPrice { get; set; }
        public List<TradeItemTaxInformation> TradeItemTaxInformation { get; set; }
        public TotalLineAmount TotalLineAmount { get; set; }
    }

    public class TradeItemIdentification
    {
        public string GTIN { get; set; }
    }

    public class TradeItemDescriptionInformation
    {
        public string LongText { get; set; }
    }

    public class InvoicedQuantity
    {
        [XmlAttribute(AttributeName = "unitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        public double Value { get; set; }
    }

    public class AditionalQuantity
    {
        [XmlAttribute(AttributeName = "QuantityType")]
        public string QuantityType { get; set; }
    }

    public class NetPrice
    {
        public double Amount { get; set; }
    }

    public class TradeItemTaxInformation
    {
        public string TaxTypeDescription { get; set; }
        public TradeItemTaxAmount TradeItemTaxAmount { get; set; }
    }

    public class TradeItemTaxAmount
    {
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
    }

    public class TotalLineAmount
    {
        public NetAmount NetAmount { get; set; }
    }

    public class NetAmount
    {
        public double Amount { get; set; }
    }

    public class BaseAmount
    {
        public double Amount { get; set; }
    }

    public class Tax
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
    }

    public class PayableAmount
    {
        public double Amount { get; set; }
    }

    //--------------------------------- Comercio Exterio -------------------------

    [XmlRoot(ElementName = "ComercioExterior", Namespace = "http://www.sat.gob.mx/ComercioExterior11")]
    public class ComercioExterior
    {
        [XmlAttribute("Version")]
        public string Version { get; set; }

        [XmlAttribute("TipoOperacion")]
        public string TipoOperacion { get; set; }

        [XmlAttribute("ClaveDePedimento")]
        public string ClaveDePedimento { get; set; }

        [XmlAttribute("CertificadoOrigen")]
        public string CertificadoOrigen { get; set; }

        [XmlAttribute("Incoterm")]
        public string Incoterm { get; set; }

        [XmlAttribute("TipoCambioUSD")]
        public string TipoCambioUSD { get; set; }

        [XmlAttribute("TotalUSD")]
        public string TotalUSD { get; set; }

        [XmlAttribute("Subdivision")]
        public string Subdivision { get; set; }

        [XmlAttribute("Observaciones")]
        public string Observaciones { get; set; }

        public Emisor Emisor { get; set; }

        public Receptor Receptor { get; set; }

        public Mercancias Mercancias { get; set; }
    }

    public class Mercancias
    {
        public Mercancia Mercancia { get; set; }
    }

    public class Mercancia
    {
        [XmlAttribute("NoIdentificacion")]
        public string NoIdentificacion { get; set; }

        [XmlAttribute("FraccionArancelaria")]
        public string FraccionArancelaria { get; set; }

        [XmlAttribute("CantidadAduana")]
        public double CantidadAduana { get; set; }

        [XmlAttribute("UnidadAduana")]
        public string UnidadAduana { get; set; }

        [XmlAttribute("ValorUnitarioAduana")]
        public double ValorUnitarioAduana { get; set; }

        [XmlAttribute("ValorDolares")]
        public double ValorDolares { get; set; }
    }




    //// para pagos (Complementos de pago) **************************************++
    ///

    public class Pagos
    {
        [XmlAttribute("Version")]
        public string Version { get; set; }

        [XmlElement("Totales")]
        public Totales Totales { get; set; }

        [XmlElement("Pago")]
        public List<Pago> PagosDetalles { get; set; } = new List<Pago>();
    }

    public class Totales
    {
        [XmlAttribute("MontoTotalPagos")]
        public string MontoTotalPagos { get; set; }

        [XmlAttribute("TotalTrasladosBaseIVA0")]
        public string TotalTrasladosBaseIVA0 { get; set; }

        [XmlAttribute("TotalTrasladosImpuestoIVA0")]
        public string TotalTrasladosImpuestoIVA0 { get; set; }
    }

    public class Pago
    {
        [XmlAttribute("FechaPago")]
        public DateTime FechaPago { get; set; }

        [XmlAttribute("FormaDePagoP")]
        public string FormaDePagoP { get; set; }

        [XmlAttribute("MonedaP")]
        public string MonedaP { get; set; }

        [XmlAttribute("TipoCambioP")]
        public string TipoCambioP { get; set; }

        [XmlAttribute("Monto")]
        public string Monto { get; set; }

        [XmlAttribute("NumOperacion")]
        public string NumOperacion { get; set; }

        [XmlAttribute("RfcEmisorCtaOrd")]
        public string RfcEmisorCtaOrd { get; set; }

        [XmlAttribute("NomBancoOrdExt")]
        public string NomBancoOrdExt { get; set; }

        [XmlAttribute("RfcEmisorCtaBen")]
        public string RfcEmisorCtaBen { get; set; }

        [XmlAttribute("CtaBeneficiario")]
        public string CtaBeneficiario { get; set; }

        [XmlElement("DoctoRelacionado")]
        public List<DoctoRelacionado> DocumentosRelacionados { get; set; } = new List<DoctoRelacionado>();

        [XmlElement("ImpuestosP")]
        public ImpuestosP ImpuestosP { get; set; }
    }

    public class DoctoRelacionado
    {
        [XmlAttribute("IdDocumento")]
        public string IdDocumento { get; set; }

        [XmlAttribute("Folio")]
        public string Folio { get; set; }

        [XmlAttribute("MonedaDR")]
        public string MonedaDR { get; set; }

        [XmlAttribute("EquivalenciaDR")]
        public string EquivalenciaDR { get; set; }

        [XmlAttribute("NumParcialidad")]
        public int NumParcialidad { get; set; }

        [XmlAttribute("ImpSaldoAnt")]
        public string ImpSaldoAnt { get; set; }

        [XmlAttribute("ImpPagado")]
        public string ImpPagado { get; set; }

        [XmlAttribute("ImpSaldoInsoluto")]
        public string ImpSaldoInsoluto { get; set; }

        [XmlAttribute("ObjetoImpDR")]
        public string ObjetoImpDR { get; set; }

        [XmlElement("ImpuestosDR")]
        public ImpuestosDR ImpuestosDR { get; set; }
    }

    public class ImpuestosDR
    {
        [XmlElement("TrasladoDR")]
        public List<TrasladoDR> TrasladosDR { get; set; } = new List<TrasladoDR>();
    }

    public class TrasladoDR
    {
        [XmlAttribute("BaseDR")]
        public string BaseDR { get; set; }

        [XmlAttribute("ImpuestoDR")]
        public string ImpuestoDR { get; set; }

        [XmlAttribute("TipoFactorDR")]
        public string TipoFactorDR { get; set; }

        [XmlAttribute("TasaOCuotaDR")]
        public string TasaOCuotaDR { get; set; }

        [XmlAttribute("ImporteDR")]
        public string ImporteDR { get; set; }
    }

    public class ImpuestosP
    {
        [XmlElement("TrasladoP")]
        public List<TrasladoP> TrasladosP { get; set; } = new List<TrasladoP>();
    }

    public class TrasladoP
    {
        [XmlAttribute("BaseP")]
        public string BaseP { get; set; }

        [XmlAttribute("ImpuestoP")]
        public string ImpuestoP { get; set; }

        [XmlAttribute("TipoFactorP")]
        public string TipoFactorP { get; set; }

        [XmlAttribute("TasaOCuotaP")]
        public string TasaOCuotaP { get; set; }

        [XmlAttribute("ImporteP")]
        public string ImporteP { get; set; }
    }





}
