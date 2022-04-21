using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using bankCore.DataSet1TableAdapters;
using bankCore.Models.Answers;
using bankCore.Models.Calls;
using Newtonsoft.Json;

namespace bankCore
{
    /// <summary>
    /// Summary description for coreWservice
    /// </summary>
    [WebService(Namespace = "http://bankCore.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class coreWservice : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string InsertarCliente(string json)
        {
            adapterCliente adapterCliente = new adapterCliente();
            InsertarClienteResp respuesta = null;
            string jsonRespuesta = null;
            try
            {
                InsertarCliente clienteSolicitado = JsonConvert.DeserializeObject<InsertarCliente>(json);
                adapterCliente.ppInsertarClienteUsuario(clienteSolicitado.CLientName, clienteSolicitado.ClientUsername, clienteSolicitado.ClientPassword,
                    clienteSolicitado.sex, clienteSolicitado.ClientCedula);
                DataTable dt = adapterCliente.ppMostrarClienteUsuarioCreado(clienteSolicitado.ClientCedula);
                respuesta = new InsertarClienteResp()
                {
                    Id = long.Parse(dt.Rows[0].ToString()),
                    Usuario =
                    {
                        Id = long.Parse(dt.Rows[1].ToString()),
                        Username = dt.Rows[2].ToString(),
                        Password = dt.Rows[3].ToString(),
                        LastLoginTime = DateTime.Parse(dt.Rows[4].ToString())
                    },
                    Name = dt.Rows[5].ToString(),
                    Cedula = dt.Rows[6].ToString(),
                    sex = bool.Parse(dt.Rows[7].ToString()),
                    estado = bool.Parse(dt.Rows[8].ToString())
                };
                jsonRespuesta = JsonConvert.SerializeObject(respuesta, Formatting.Indented);
                return jsonRespuesta;
            }
            catch (Exception)
            {
                jsonRespuesta = JsonConvert.SerializeObject(respuesta, Formatting.Indented);
                return jsonRespuesta;
            }

        }

        [WebMethod]
        public string InsertarTransaccion(string json)
        {
            tblTransaccionTableAdapter adapterTransaccion = new tblTransaccionTableAdapter();
            InsertarTransaccionResp respuesta = null;
            try
            {
                InsertarTransaccion transaccionSolicitada = JsonConvert.DeserializeObject<InsertarTransaccion>(json);
                adapterTransaccion.ppInsertarTransaccion(transaccionSolicitada.id_TipoTransaccion, transaccionSolicitada.CuentaOrigen,
                    transaccionSolicitada.CuentaDestino, transaccionSolicitada.Monto);
                DataTable dt = adapterTransaccion.ppMostrarTransaccionCreada();
                respuesta = new InsertarTransaccionResp()
                {
                    id = long.Parse(dt.Rows[0].ToString())
                };
                string respJson = JsonConvert.SerializeObject(respuesta, Formatting.Indented);
                return respJson;
            }
            catch (Exception)
            {
                string respJson = JsonConvert.SerializeObject(respuesta, Formatting.Indented);
                return respJson;
            }
        }

        [WebMethod]
        public string InsertarPrestamo(string json)
        {
            tblPrestamoTableAdapter adapterPrestamo = new tblPrestamoTableAdapter();
            InsertarPrestamoResp respuesta = null;
            string jsonResp = null;
            try
            {
                InsertarPrestamo prestamoSolicitado = JsonConvert.DeserializeObject<InsertarPrestamo>(json);
                adapterPrestamo.ppInsertarPresamoWs(prestamoSolicitado.ID_Cliente, prestamoSolicitado.ID_EstadoPrestamo, prestamoSolicitado.ID_TipoPrestamo,
                    prestamoSolicitado.Fuente, prestamoSolicitado.Monto, prestamoSolicitado.Interes);
                DataTable dt = adapterPrestamo.ppMostrarPrestamoCreado();
                respuesta = new InsertarPrestamoResp()
                {
                    id = long.Parse(dt.Rows[0].ToString()),
                    id_Cliente = long.Parse(dt.Rows[1].ToString()),
                    id_EstadoPrestamo = byte.Parse(dt.Rows[2].ToString()),
                    id_TipoPrestamo = byte.Parse(dt.Rows[3].ToString()),
                    Fuente = long.Parse(dt.Rows[3].ToString()),
                    Monto = decimal.Parse(dt.Rows[4].ToString()),
                    Interes = decimal.Parse(dt.Rows[5].ToString()),
                    fechaCreacion = DateTime.Parse(dt.Rows[6].ToString())
                };
                jsonResp = JsonConvert.SerializeObject(respuesta, Formatting.Indented);
                return jsonResp;
            }
            catch (Exception)
            {
                jsonResp = JsonConvert.SerializeObject(respuesta, Formatting.Indented);
                return jsonResp;
            }
        }


    }
}
