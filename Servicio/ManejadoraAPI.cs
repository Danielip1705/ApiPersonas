using ENT;
using Newtonsoft.Json;
using System.Net;

namespace Servicio
{
    public class ManejadoraAPI
    {

        /// <summary>
        /// Funcion que recoge de una api una lista de personas
        /// </summary>
        /// <returns>Lista de personaas obtenidas de la api</returns>
        public static async Task<List<Personas>> getListadoPersonasAPI()
        {
            List<Personas> listadoPersonas = new List<Personas>();
            string url = UriBase.ObtenerAPI();
            HttpClient miHttp = new HttpClient();
            Uri miUri = new Uri($"{url}/persona");
            HttpResponseMessage miRespuesta;
            string textoJsonRespuesta;
            miHttp = new HttpClient();

            miRespuesta = await miHttp.GetAsync(miUri);

            try
            {
                miRespuesta = await miHttp.GetAsync(miUri);
                if (miRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await miHttp.GetStringAsync(miUri);
                    miHttp.Dispose();
                    listadoPersonas = JsonConvert.DeserializeObject<List<Personas>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoPersonas;
        }

        public static async Task<HttpStatusCode> postPersonasAPI(Personas persona)
        {

            HttpClient miHttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = UriBase.ObtenerAPI();
            Uri miUri = new Uri(miCadenaUrl);

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(persona);
                contenido = new StringContent(datos,System.Text.Encoding.UTF8,"application/json");
                miRespuesta = await miHttpClient.PostAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return miRespuesta.StatusCode;
        }
    
       
    }
}
