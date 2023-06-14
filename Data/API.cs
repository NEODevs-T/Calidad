using Microsoft.EntityFrameworkCore;


namespace TiempoPerdido.Data.API
{
    public interface IDataAPI
    {

        Task<Dictionary<string,string>>? obtenerUsuario(string ficha);
        Task<List<string>>? ObtenerTurnoYGrupo();
        Task<Dictionary<string,string>>? ObtenerProductosActuales(string centroCostoLinea);
        Task<Dictionary<string,string>> ObtenerProductosActualesConOrdenesAbiertas(string centroCostoLinea);
    }

    public class DataAPI : IDataAPI
    {
        private HttpClient cliente;
        
        public async Task<Dictionary<string,string>>? obtenerUsuario(string ficha){
            Dictionary<string,string>? usuario = new Dictionary<string,string>();
            try{
                string url = "http://neo.paveca.com.ve/neoapi/usuario/BuscarUsuarioPorFicha/" + ficha;
                this.cliente = new HttpClient();
                usuario = await cliente.GetFromJsonAsync<Dictionary<string,string>?>(url);
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return usuario;
        }

        public async Task<List<string>>? ObtenerTurnoYGrupo(){
            List<string> usuario;
            string url = "http://neo.paveca.com.ve/neoapi/turno/ObtenerTurnoYGrupoActual";
            this.cliente = new HttpClient();
            usuario = await cliente.GetFromJsonAsync<List<string>>(url);
            return usuario;
        }

        public async Task<Dictionary<string,string>>? ObtenerProductosActuales(string centroCostoLinea){
            Dictionary<string,string> producto;
            string url = "http://neo.paveca.com.ve/NeoApi/OEE/obtenerProductosActualesDeLaLiena/" + centroCostoLinea;
            this.cliente = new HttpClient();
            producto = await cliente.GetFromJsonAsync<Dictionary<string,string>>(url);
            return producto;
        }

        public async Task<Dictionary<string,string>> ObtenerProductosActualesConOrdenesAbiertas(string centroCostoLinea){
            Dictionary<string,string> producto;
            string url = "http://neo.paveca.com.ve/NeoApi/BPCS/obtenerProductoConOrdenDeFabricacionAbierta/" + centroCostoLinea;
            this.cliente = new HttpClient();
            producto = await cliente.GetFromJsonAsync<Dictionary<string,string>>(url);
            return producto;
        }

        

    }   
}