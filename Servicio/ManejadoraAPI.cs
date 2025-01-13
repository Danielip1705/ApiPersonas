using ENT;
using Newtonsoft.Json;

namespace Servicio
{
    public class ManejadoraAPI
    {

        public static string ObtenerAPI()
        {
            return "https://danielip.azurewebsites.net/api/persona/";
        }

        public static async Task<List<Personas>> getListadoPersonasAPI()
        {
            List<Personas> listadoPersonas = new List<Personas>();
            string url = ObtenerAPI();
            HttpClient miHttp = new HttpClient();
            Uri miUri = new Uri(url);
            HttpResponseMessage miRespuesta;
            string textoJsonRespuesta;
            miHttp = new HttpClient();

            try
            {
                miRespuesta = await miHttp.GetAsync(miUri);
                if(miRespuesta.IsSuccessStatusCode)
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

    }
}
