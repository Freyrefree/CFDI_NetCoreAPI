using CFDI.Cls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace CFDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpPost]
        public ActionResult ParseXml([FromForm(Name = "file")] string file)
        {
           



                try
                {


                    CFDIHelper ObjCFDI = new CFDIHelper();

                    CFDIHelper.xml = XmlHelper.LoadXml(file);
                    CFDIHelper.nsgmr = XmlHelper.XMLNamespaces(CFDIHelper.xml, file);

                    var CFDI = new Comprobante();

                    // Llamar a los métodos y guardar los resultados en variables
                    var dataEmisor = CFDIHelper.CFDI_Emisor();
                    var dataReceptor = CFDIHelper.CFDI_Receptor();
                    var dataConceptos = CFDIHelper.CFDI_Conceptos();
                    var dataImpuestos = CFDIHelper.CFDI_Impuestos();
                    var dataComplemento = CFDIHelper.CFDI_Complemento();
                    var dataComprobante = CFDIHelper.CFDI_Comprobante();
                    var dataAddenda = CFDIHelper.Addenda();
                    var dataComercioExterior = CFDIHelper.CFDI_ComercioExterior();
                    var dataCab = CFDIHelper.Cab();
                    var dataPagos = CFDIHelper.Pagos();

                // Asignar los valores al objeto CFDI
                    CFDI.Emisor = dataEmisor;
                    CFDI.Receptor = dataReceptor;
                    CFDI.Conceptos = dataConceptos;
                    CFDI.Impuestos = dataImpuestos;
                    CFDI.Complemento = dataComplemento;
                    CFDI.Version = dataComprobante.Version;
                    CFDI.Serie = dataComprobante.Serie;
                    CFDI.Folio = dataComprobante.Folio;
                    CFDI.Fecha = dataComprobante.Fecha;
                    CFDI.FormaPago = dataComprobante.FormaPago;
                    CFDI.CondicionesDePago = dataComprobante.CondicionesDePago;
                    CFDI.SubTotal = dataComprobante.SubTotal;
                    CFDI.Moneda = dataComprobante.Moneda;
                    CFDI.TipoCambio = dataComprobante.TipoCambio;
                    CFDI.Total = dataComprobante.Total;
                    CFDI.TipoDeComprobante = dataComprobante.TipoDeComprobante;
                    CFDI.MetodoPago = dataComprobante.MetodoPago;
                    CFDI.LugarExpedicion = dataComprobante.LugarExpedicion;
                    CFDI.Exportacion = dataComprobante.Exportacion;
                    CFDI.NoCertificado = dataComprobante.NoCertificado;
                    CFDI.Certificado = dataComprobante.Certificado;
                    CFDI.Sello = dataComprobante.Sello;
                    CFDI.Addenda = dataAddenda;
                    CFDI.ComercioExterior = dataComercioExterior;
                    CFDI.Cab = dataCab;
                    CFDI.Pagos = dataPagos;
                


                


                    return Ok(CFDI);


                    //return Ok(dataEmisor);
                }
                
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            


        }

    }
}
