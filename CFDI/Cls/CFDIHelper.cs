using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CFDI.Cls
{
    public class CFDIHelper
    {
        public static XmlDocument xml;
        public static XmlNamespaceManager nsgmr;



        public static Comprobante CFDI_Comprobante()
        {
            // Obtener el nodo principal del comprobante
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante", nsgmr);

            if (nodeList.Count == 0)
            {
                throw new Exception("No se encontró el nodo Comprobante en el archivo XML.");
            }

            // Obtener el nodo y verificar el tipo de comprobante
            var node = nodeList[0]; // Asumir que solo hay un nodo Comprobante principal
            var tipoComprobante = node.Attributes["TipoDeComprobante"]?.Value;

            // Si el comprobante es de tipo "P", solo leer los valores específicos
            if (tipoComprobante == "P")
            {
                return new Comprobante
                {
                    Version = node.Attributes["Version"]?.Value,
                    Serie = node.Attributes["Serie"]?.Value,
                    Folio = Convert.ToInt64(node.Attributes["Folio"]?.Value ?? "0"), // Usar Int64 (long) para evitar el overflow
                    Fecha = DateTime.Parse(node.Attributes["Fecha"]?.Value ?? DateTime.MinValue.ToString()),
                    SubTotal = Convert.ToDouble(node.Attributes["SubTotal"]?.Value ?? "0"),
                    Moneda = node.Attributes["Moneda"]?.Value,
                    Total = node.Attributes["Total"]?.Value,
                    TipoDeComprobante = node.Attributes["TipoDeComprobante"]?.Value,
                    Exportacion = Convert.ToInt32(node.Attributes["Exportacion"]?.Value ?? "0"),
                    LugarExpedicion = Convert.ToInt32(node.Attributes["LugarExpedicion"]?.Value ?? "0"),
                    NoCertificado = node.Attributes["NoCertificado"]?.Value,
                    Certificado = node.Attributes["Certificado"]?.Value,
                    Sello = node.Attributes["Sello"]?.Value
                };
            }


            // Para otros tipos de comprobantes, leer todos los atributos
            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Comprobante
                {
                    Version = node.Attributes["Version"].Value,
                    Serie = node.Attributes["Serie"].Value,
                    Folio = Convert.ToInt32(node.Attributes["Folio"].Value),
                    Fecha = DateTime.Parse(node.Attributes["Fecha"].Value),
                    FormaPago = Convert.ToInt32(node.Attributes["FormaPago"].Value),
                    CondicionesDePago = node.Attributes["CondicionesDePago"].Value,
                    SubTotal = Convert.ToDouble(node.Attributes["SubTotal"].Value),
                    Moneda = node.Attributes["Moneda"].Value,
                    TipoCambio = node.Attributes["TipoCambio"].Value,
                    Total = node.Attributes["Total"].Value,
                    TipoDeComprobante = node.Attributes["TipoDeComprobante"].Value,
                    MetodoPago = node.Attributes["MetodoPago"].Value,
                    LugarExpedicion = Convert.ToInt32(node.Attributes["LugarExpedicion"].Value),
                    Exportacion = Convert.ToInt32(node.Attributes["Exportacion"].Value),
                    NoCertificado = node.Attributes["NoCertificado"].Value,
                    Certificado = node.Attributes["Certificado"].Value,
                    Sello = node.Attributes["Sello"].Value
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró información válida en el archivo XML.");
            }

            return data;
        }


        public static Emisor CFDI_Emisor()
        {
            // Ejecutar la consulta XPath y crear el objeto Emisor
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Emisor", nsgmr);
            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Emisor
                {
                    Rfc = node.Attributes["Rfc"].Value,
                    Nombre = node.Attributes["Nombre"].Value,
                    RegimenFiscal = Convert.ToInt32(node.Attributes["RegimenFiscal"].Value)
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Emisor en el archivo XML.");
            }

            return data;
        }

        public static Receptor CFDI_Receptor()
        {
            // Ejecutar la consulta XPath y crear el objeto Emisor
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Receptor", nsgmr);
            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Receptor
                {
                    Rfc = node.Attributes["Rfc"].Value,
                    Nombre = node.Attributes["Nombre"].Value,
                    UsoCFDI = node.Attributes["UsoCFDI"].Value,
                    DomicilioFiscalReceptor = Convert.ToInt32(node.Attributes["DomicilioFiscalReceptor"].Value),
                    RegimenFiscalReceptor = Convert.ToInt32(node.Attributes["RegimenFiscalReceptor"].Value)
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Receptor en el archivo XML.");
            }

            return data;
        }

        public static Conceptos CFDI_Conceptos()
        {
            // Obtener el nodo principal del comprobante
            var comprobanteNodes = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante", nsgmr);
            if (comprobanteNodes.Count == 0)
            {
                throw new Exception("No se encontró el nodo Comprobante en el archivo XML.");
            }

            // Asumir que solo hay un nodo principal y obtener su tipo
            var comprobanteNode = comprobanteNodes[0];
            var tipoComprobante = comprobanteNode.Attributes["TipoDeComprobante"]?.Value;

            // Obtener los nodos de Conceptos
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", nsgmr);

            if (nodeList.Count == 0)
            {
                throw new Exception("No se encontraron nodos Concepto en el archivo XML.");
            }

            // Si el comprobante es de tipo "Pago", solo leer los valores específicos
            if (tipoComprobante == "P")
            {
                var data = nodeList
                    .Cast<XmlNode>()
                    .Select(node => new Concepto
                    {
                        ClaveProdServ = Convert.ToInt32(node.Attributes["ClaveProdServ"]?.Value ?? "0"),
                        Cantidad = Convert.ToDouble(node.Attributes["Cantidad"]?.Value ?? "0"),
                        ClaveUnidad = node.Attributes["ClaveUnidad"]?.Value,
                        Descripcion = node.Attributes["Descripcion"]?.Value,
                        ValorUnitario = Convert.ToDouble(node.Attributes["ValorUnitario"]?.Value ?? "0"),
                        Importe = Convert.ToDouble(node.Attributes["Importe"]?.Value ?? "0"),
                        ObjetoImp = Convert.ToInt32(node.Attributes["ObjetoImp"]?.Value ?? "0")
                    })
                    .ToList();

                return new Conceptos { Concepto = data };
            }

            // Para otros tipos de comprobantes, procesar todos los valores
            var conceptosGenerales = nodeList
                .Cast<XmlNode>()
                .Select(node => new Concepto
                {
                    ClaveProdServ = Convert.ToInt32(node.Attributes["ClaveProdServ"].Value),
                    NoIdentificacion = Convert.ToInt32(node.Attributes["NoIdentificacion"]?.Value ?? "0"),
                    Cantidad = Convert.ToDouble(node.Attributes["Cantidad"].Value),
                    ClaveUnidad = node.Attributes["ClaveUnidad"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    ValorUnitario = Convert.ToDouble(node.Attributes["ValorUnitario"].Value),
                    Importe = Convert.ToDouble(node.Attributes["Importe"].Value),
                    Unidad = node.Attributes["Unidad"].Value,
                    ObjetoImp = Convert.ToInt32(node.Attributes["ObjetoImp"]?.Value ?? "0"),
                    Impuestos = new Impuestos
                    {
                        Traslados = new Traslados
                        {
                            Traslado = new Traslado
                            {
                                Base = Convert.ToDouble(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Base"]?.Value ?? "0"),
                                Impuesto = Convert.ToInt32(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Impuesto"]?.Value ?? "0"),
                                TipoFactor = node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TipoFactor"]?.Value,
                                TasaOCuota = Convert.ToDouble(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TasaOCuota"]?.Value ?? "0"),
                                Importe = Convert.ToDouble(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Importe"]?.Value ?? "0")
                            }
                        }
                    }
                })
                .ToList();

            return new Conceptos { Concepto = conceptosGenerales };
        }










        public static Impuestos CFDI_Impuestos()
        {
            // Obtener el nodo principal del comprobante
            var comprobanteNodes = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante", nsgmr);
            if (comprobanteNodes.Count == 0)
            {
                throw new Exception("No se encontró el nodo Comprobante en el archivo XML.");
            }

            // Asumir que solo hay un nodo principal y obtener su tipo
            var comprobanteNode = comprobanteNodes[0];
            var tipoComprobante = comprobanteNode.Attributes["TipoDeComprobante"]?.Value;

            // Si el comprobante es de tipo "P", no leer nada
            if (tipoComprobante == "P")
            {
                return null; // O retornar un objeto vacío si es necesario
            }

            // Obtener los nodos de Impuestos
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Impuestos", nsgmr);
            if (nodeList.Count == 0)
            {
                throw new Exception("No se encontraron nodos Impuestos en el archivo XML.");
            }

            // Procesar los nodos de Impuestos
            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Impuestos
                {
                    TotalImpuestosTrasladados = Convert.ToDouble(node.Attributes["TotalImpuestosTrasladados"]?.Value ?? "0"),

                    Traslados = new Traslados
                    {
                        Traslado = new Traslado
                        {
                            Base = Convert.ToDouble(node.SelectSingleNode("cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Base"]?.Value ?? "0"),
                            Impuesto = Convert.ToInt32(node.SelectSingleNode("cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Impuesto"]?.Value ?? "0"),
                            TipoFactor = node.SelectSingleNode("cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TipoFactor"]?.Value,
                            TasaOCuota = Convert.ToDouble(node.SelectSingleNode("cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TasaOCuota"]?.Value ?? "0"),
                            Importe = Convert.ToDouble(node.SelectSingleNode("cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Importe"]?.Value ?? "0")
                        }
                    }
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró información válida de Impuestos en el archivo XML.");
            }

            return data;
        }




        public static Complemento CFDI_Complemento()
        {
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Complemento", nsgmr);

            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Complemento
                {
                    TimbreFiscalDigital = new TimbreFiscalDigital
                    {
                        Version = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["Version"]?.Value ?? "1900-01-01",
                        UUID = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["UUID"]?.Value,
                        FechaTimbrado = DateTime.Parse(node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["FechaTimbrado"]?.Value ?? "1900-01-01T00:00:00"),
                        RfcProvCertif = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["RfcProvCertif"]?.Value,
                        SelloCFD = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["SelloCFD"]?.Value,
                        NoCertificadoSAT = double.Parse(node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["NoCertificadoSAT"]?.Value ?? "0"),
                        SelloSAT = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["SelloSAT"]?.Value,

                    }
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Complemento en el archivo XML.");
            }

            return data;
        }

        public static Addenda Addenda()
        {

            try
            {
                var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante", nsgmr);
                var data = nodeList
                    .Cast<XmlNode>()
                    .Select(node => new Addenda
                    {
                        RequestForPayment = new RequestForPayment
                        {
                            OrderIdentification = new OrderIdentification
                            {
                                ReferenceIdentification = xml.SelectSingleNode("//requestForPayment/orderIdentification/referenceIdentification", nsgmr)?.InnerText,

                            }
                        }
                    })
                    .FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("No se encontró el nodo Addenda en el archivo XML.");
                }

                return data;
            }
            catch (Exception ex)
            {

                return null; // O devuelve un valor predeterminado, dependiendo de tus necesidades.
            }
        }



        public static Pagos Pagos()
        {
            try
            {
                // Obtener el nodo "cfdi:Complemento"
                var complementoNodes = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Complemento", nsgmr);
                if (complementoNodes.Count == 0)
                {
                    throw new Exception("No se encontró el nodo Complemento en el archivo XML.");
                }

                // Buscar el nodo "pago20:Pagos" dentro del nodo "cfdi:Complemento"
                var pagosNode = complementoNodes
                    .Cast<XmlNode>()
                    .SelectMany(node => node.SelectNodes("pago20:Pagos", nsgmr).Cast<XmlNode>())
                    .FirstOrDefault();

                if (pagosNode == null)
                {
                    throw new Exception("No se encontró el nodo Pagos en el archivo XML.");
                }

                // Leer los datos del nodo "pago20:Pagos"
                var pagos = new Pagos
                {
                    Version = pagosNode.Attributes["Version"]?.Value,
                    Totales = new Totales
                    {
                        MontoTotalPagos = pagosNode.SelectSingleNode("pago20:Totales", nsgmr)?.Attributes["MontoTotalPagos"]?.Value ?? "0",
                        TotalTrasladosBaseIVA0 = pagosNode.SelectSingleNode("pago20:Totales", nsgmr)?.Attributes["TotalTrasladosBaseIVA0"]?.Value ?? "0",
                        TotalTrasladosImpuestoIVA0 = pagosNode.SelectSingleNode("pago20:Totales", nsgmr)?.Attributes["TotalTrasladosImpuestoIVA0"]?.Value ?? "0"

                    },
                    PagosDetalles = pagosNode.SelectNodes("pago20:Pago", nsgmr)
                    .Cast<XmlNode>()
                        .Select(pagoNode => new Pago
                        {
                            FechaPago = DateTime.Parse(pagoNode.Attributes["FechaPago"]?.Value ?? DateTime.MinValue.ToString()),
                            FormaDePagoP = pagoNode.Attributes["FormaDePagoP"]?.Value,
                            MonedaP = pagoNode.Attributes["MonedaP"]?.Value,
                            TipoCambioP = pagoNode.Attributes["TipoCambioP"]?.Value ?? "0",
                            Monto = pagoNode.Attributes["Monto"]?.Value ?? "0",
                            NumOperacion = pagoNode.Attributes["NumOperacion"]?.Value,
                            RfcEmisorCtaOrd = pagoNode.Attributes["RfcEmisorCtaOrd"]?.Value,
                            NomBancoOrdExt = pagoNode.Attributes["NomBancoOrdExt"]?.Value,
                            RfcEmisorCtaBen = pagoNode.Attributes["RfcEmisorCtaBen"]?.Value,
                            CtaBeneficiario = pagoNode.Attributes["CtaBeneficiario"]?.Value,
                            DocumentosRelacionados = pagoNode.SelectNodes("pago20:DoctoRelacionado", nsgmr)
                                .Cast<XmlNode>()
                                .Select(docNode => new DoctoRelacionado
                                {
                                    IdDocumento = docNode.Attributes["IdDocumento"]?.Value,
                                    Folio = docNode.Attributes["Folio"]?.Value,
                                    MonedaDR = docNode.Attributes["MonedaDR"]?.Value,
                                    EquivalenciaDR = docNode.Attributes["EquivalenciaDR"]?.Value ?? "0",
                                    NumParcialidad = Convert.ToInt32(docNode.Attributes["NumParcialidad"]?.Value ?? "0"),
                                    ImpSaldoAnt = docNode.Attributes["ImpSaldoAnt"]?.Value ?? "0",
                                    ImpPagado = docNode.Attributes["ImpPagado"]?.Value ?? "0",
                                    ImpSaldoInsoluto = docNode.Attributes["ImpSaldoInsoluto"]?.Value ?? "0",
                                    ObjetoImpDR = docNode.Attributes["ObjetoImpDR"]?.Value,
                                    ImpuestosDR = new ImpuestosDR
                                    {
                                        TrasladosDR = docNode.SelectNodes("pago20:ImpuestosDR/pago20:TrasladosDR/pago20:TrasladoDR", nsgmr)
                                            .Cast<XmlNode>()
                                            .Select(trasladoNode => new TrasladoDR
                                            {
                                                BaseDR = trasladoNode.Attributes["BaseDR"]?.Value ?? "0",
                                                ImpuestoDR = trasladoNode.Attributes["ImpuestoDR"]?.Value,
                                                TipoFactorDR = trasladoNode.Attributes["TipoFactorDR"]?.Value,
                                                TasaOCuotaDR = trasladoNode.Attributes["TasaOCuotaDR"]?.Value ?? "0",
                                                ImporteDR = trasladoNode.Attributes["ImporteDR"]?.Value ?? "0"
                                            }).ToList()
                                    }
                                }).ToList(),
                            ImpuestosP = new ImpuestosP
                            {
                                TrasladosP = pagoNode.SelectNodes("pago20:ImpuestosP/pago20:TrasladosP/pago20:TrasladoP", nsgmr)
                                    .Cast<XmlNode>()
                                    .Select(trasladoNode => new TrasladoP
                                    {
                                        BaseP = trasladoNode.Attributes["BaseP"]?.Value ?? "0",
                                        ImpuestoP = trasladoNode.Attributes["ImpuestoP"]?.Value,
                                        TipoFactorP = trasladoNode.Attributes["TipoFactorP"]?.Value,
                                        TasaOCuotaP = trasladoNode.Attributes["TasaOCuotaP"]?.Value ?? "0",
                                        ImporteP = trasladoNode.Attributes["ImporteP"]?.Value ?? "0"
                                    }).ToList()
                            }
                        }).ToList()
                };

                return pagos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return null;
            }
        }

        //public static Pagos Pagos()
        //{
        //    try
        //    {
        //        // Buscar el nodo "pago20:Pagos" dentro de "cfdi:Complemento"
        //        var pagosNode = xml.SelectSingleNode("//cfdi:Comprobante/cfdi:Complemento/pago20:Pagos", nsmgr);

        //        if (pagosNode == null)
        //        {
        //            throw new Exception("No se encontró el nodo Pagos en el archivo XML.");
        //        }

        //        // Leer los datos del nodo "pago20:Pagos"
        //        var pagos = new Pagos
        //        {
        //            Version = pagosNode.Attributes["Version"]?.Value,
        //            Totales = new Totales
        //            {
        //                MontoTotalPagos = Convert.ToDouble(pagosNode.SelectSingleNode("pago20:Totales", nsmgr)?.Attributes["MontoTotalPagos"]?.Value ?? "0"),
        //                TotalTrasladosBaseIVA0 = Convert.ToDouble(pagosNode.SelectSingleNode("pago20:Totales", nsmgr)?.Attributes["TotalTrasladosBaseIVA0"]?.Value ?? "0"),
        //                TotalTrasladosImpuestoIVA0 = Convert.ToDouble(pagosNode.SelectSingleNode("pago20:Totales", nsmgr)?.Attributes["TotalTrasladosImpuestoIVA0"]?.Value ?? "0")
        //            },
        //            PagosDetalles = pagosNode.SelectNodes("pago20:Pago", nsmgr)
        //                .Cast<XmlNode>()
        //                .Select(pagoNode => new Pago
        //                {
        //                    FechaPago = DateTime.Parse(pagoNode.Attributes["FechaPago"]?.Value ?? DateTime.MinValue.ToString()),
        //                    FormaDePagoP = pagoNode.Attributes["FormaDePagoP"]?.Value,
        //                    MonedaP = pagoNode.Attributes["MonedaP"]?.Value,
        //                    TipoCambioP = Convert.ToDouble(pagoNode.Attributes["TipoCambioP"]?.Value ?? "0"),
        //                    Monto = Convert.ToDouble(pagoNode.Attributes["Monto"]?.Value ?? "0"),
        //                    NumOperacion = pagoNode.Attributes["NumOperacion"]?.Value,
        //                    RfcEmisorCtaOrd = pagoNode.Attributes["RfcEmisorCtaOrd"]?.Value,
        //                    NomBancoOrdExt = pagoNode.Attributes["NomBancoOrdExt"]?.Value,
        //                    RfcEmisorCtaBen = pagoNode.Attributes["RfcEmisorCtaBen"]?.Value,
        //                    CtaBeneficiario = pagoNode.Attributes["CtaBeneficiario"]?.Value,
        //                    DocumentosRelacionados = pagoNode.SelectNodes("pago20:DoctoRelacionado", nsmgr)
        //                        .Cast<XmlNode>()
        //                        .Select(docNode => new DoctoRelacionado
        //                        {
        //                            IdDocumento = docNode.Attributes["IdDocumento"]?.Value,
        //                            Folio = docNode.Attributes["Folio"]?.Value,
        //                            MonedaDR = docNode.Attributes["MonedaDR"]?.Value,
        //                            EquivalenciaDR = Convert.ToDouble(docNode.Attributes["EquivalenciaDR"]?.Value ?? "0"),
        //                            NumParcialidad = Convert.ToInt32(docNode.Attributes["NumParcialidad"]?.Value ?? "0"),
        //                            ImpSaldoAnt = Convert.ToDouble(docNode.Attributes["ImpSaldoAnt"]?.Value ?? "0"),
        //                            ImpPagado = Convert.ToDouble(docNode.Attributes["ImpPagado"]?.Value ?? "0"),
        //                            ImpSaldoInsoluto = Convert.ToDouble(docNode.Attributes["ImpSaldoInsoluto"]?.Value ?? "0"),
        //                            ObjetoImpDR = docNode.Attributes["ObjetoImpDR"]?.Value,
        //                            ImpuestosDR = new ImpuestosDR
        //                            {
        //                                TrasladosDR = docNode.SelectNodes("pago20:ImpuestosDR/pago20:TrasladosDR/pago20:TrasladoDR", nsmgr)
        //                                    .Cast<XmlNode>()
        //                                    .Select(trasladoNode => new TrasladoDR
        //                                    {
        //                                        BaseDR = Convert.ToDouble(trasladoNode.Attributes["BaseDR"]?.Value ?? "0"),
        //                                        ImpuestoDR = trasladoNode.Attributes["ImpuestoDR"]?.Value,
        //                                        TipoFactorDR = trasladoNode.Attributes["TipoFactorDR"]?.Value,
        //                                        TasaOCuotaDR = Convert.ToDouble(trasladoNode.Attributes["TasaOCuotaDR"]?.Value ?? "0"),
        //                                        ImporteDR = Convert.ToDouble(trasladoNode.Attributes["ImporteDR"]?.Value ?? "0")
        //                                    }).ToList()
        //                            }
        //                        }).ToList(),
        //                    ImpuestosP = new ImpuestosP
        //                    {
        //                        TrasladosP = pagoNode.SelectNodes("pago20:ImpuestosP/pago20:TrasladosP/pago20:TrasladoP", nsmgr)
        //                            .Cast<XmlNode>()
        //                            .Select(trasladoNode => new TrasladoP
        //                            {
        //                                BaseP = Convert.ToDouble(trasladoNode.Attributes["BaseP"]?.Value ?? "0"),
        //                                ImpuestoP = trasladoNode.Attributes["ImpuestoP"]?.Value,
        //                                TipoFactorP = trasladoNode.Attributes["TipoFactorP"]?.Value,
        //                                TasaOCuotaP = Convert.ToDouble(trasladoNode.Attributes["TasaOCuotaP"]?.Value ?? "0"),
        //                                ImporteP = Convert.ToDouble(trasladoNode.Attributes["ImporteP"]?.Value ?? "0")
        //                            }).ToList()
        //                    }
        //                }).ToList()
        //        };

        //        return pagos;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de excepciones
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return null;
        //    }
        //}








        public static Cab Cab()
        {

            try
            {

                var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Addenda/facturasap/Documento", nsgmr);
                var data = nodeList
                    .Cast<XmlNode>()
                    .Select(node => new Cab
                    {
                        //Documento = new Documento
                        //{ 
                            //Documento =new Documento
                            //{
                                //Cab = new Cab
                                //{
                                    //ORDCOMP =
                                    //ORDCOMP = xml.SelectSingleNode("//ORDCOMP", nsgmr)?.InnerText,
                        ORDCOMP = node.SelectSingleNode("//@ORDCOMP")?.Value,
                        INCOTERM = node.SelectSingleNode("//@INCOTERM")?.Value,
                        TOTPZA = node.SelectSingleNode("//@TOTPZA")?.Value
                        


                        //}
                        //}
                        //OrderIdentification = new OrderIdentification
                        //{
                        //    ReferenceIdentification = xml.SelectSingleNode("//requestForPayment/orderIdentification/referenceIdentification", nsgmr)?.InnerText,

                        //}
                        //}
                    })
                    .FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("No se encontró el nodo Cab de pedidoSAP en el archivo XML.");
                }

                return data;
            }
            catch (Exception ex)
            {

                return null; // O devuelve un valor predeterminado, dependiendo de tus necesidades.
            }
        }

        public static ComercioExterior CFDI_ComercioExterior()
        {
            try
            {
                // Ejecutar la consulta XPath y crear el objeto ComercioExterior
                //var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Complemento/cce11:ComercioExterior", nsgmr);
                var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Complemento/cce20:ComercioExterior", nsgmr);

                var data = nodeList
                        .Cast<XmlNode>()
                        .Select(node => new ComercioExterior
                        {
                            // Otras propiedades de ComercioExterior

                            Mercancias = node.SelectNodes("cce20:Mercancias", nsgmr)
                                .Cast<XmlNode>()
                                .Select(mercanciaNode => new Mercancias
                                {
                                    Mercancia = new Mercancia
                                    {
                                        NoIdentificacion = node.SelectSingleNode("//cce20:Mercancia", nsgmr)?.Attributes["NoIdentificacion"]?.Value ?? "",
                                        FraccionArancelaria = node.SelectSingleNode("//cce20:Mercancia", nsgmr)?.Attributes["FraccionArancelaria"]?.Value ?? "",
                                        CantidadAduana = double.Parse(node.SelectSingleNode("//cce20:Mercancia", nsgmr)?.Attributes["CantidadAduana"]?.Value ?? "0"),
                                        UnidadAduana = node.SelectSingleNode("//cce20:Mercancia", nsgmr)?.Attributes["UnidadAduana"]?.Value ?? "",
                                        ValorUnitarioAduana = double.Parse(node.SelectSingleNode("//cce20:Mercancia", nsgmr)?.Attributes["ValorUnitarioAduana"]?.Value ?? "0"),
                                        ValorDolares = double.Parse(node.SelectSingleNode("//cce20:Mercancia", nsgmr)?.Attributes["ValorDolares"]?.Value ?? "0"),
                                    }
                                })
                                .FirstOrDefault()
                        })
                        .FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("No se encontró el nodo ComercioExterior en el archivo XML.");
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo una excepción: {ex.Message}");
                return null;
            }
        }







    }
}
