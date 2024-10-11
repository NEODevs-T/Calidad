using Calidad.Model;
using Microsoft.EntityFrameworkCore;
using Calidad.DTOs.PNC;

namespace Calidad.ProductoNoConforme
{
    public interface IDataPNCIdentificacion
    {
        Task<List<IdentifDTO>> GetTodosLosIdentifi();
    }

    public class DataPNCIdentificacion : IDataPNCIdentificacion
    {

        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/PNCIdentificacion";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";


        public DataPNCIdentificacion (IHttpClientFactory clientFactory)

        {
            _clientFactory = clientFactory;
        }

        public async Task<List<IdentifDTO>> GetTodosLosIdentifi()
        {
            List<IdentifDTO> data;
            url = $"{BaseUrl}/GetTodosLosIdentifi/";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<IdentifDTO>>(url) ?? new List<IdentifDTO>();
            return data;
        }
    }



    public interface IDataPNCTipo
    {
        Task<List<TipoDTO>> GetTodosLosTipos();
    }

    public class DataPNCTipo : IDataPNCTipo
    {

        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/PNCTipo";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = " ";

        public DataPNCTipo (IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<TipoDTO>> GetTodosLosTipos()
        {
            List<TipoDTO> data;
            url = $"{BaseUrl}/GetTodosLosTipos/";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<TipoDTO>>(url) ?? new List<TipoDTO>();
            return data;
        }
    }



    public interface IDataPNCDisposicionDefinitiva
    {
        Task<List<DisDefiDTO>> GetTodosLasDisposicionDefinitiva();
    }


    public class DataPNCDisposicionDefinitiva : IDataPNCDisposicionDefinitiva
    {

    private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/PNCDisposicionDefinitiva";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = " ";


        public DataPNCDisposicionDefinitiva (IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<DisDefiDTO>> GetTodosLasDisposicionDefinitiva()
        {
            List<DisDefiDTO> data;
            url = $"{BaseUrl}/GetTodosLasDisposicionDefinitiva/";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<DisDefiDTO>>(url) ?? new List<DisDefiDTO>();
            return data;
        }

    }



    public interface IDataPNCCausante
    {
        Task<List<CausanteDTO>> GetTodosLosCausantes();
    }

    public class DataPNCCausante : IDataPNCCausante
    {

        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/PNCTipo";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = " ";


        public DataPNCCausante(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<List<CausanteDTO>> GetTodosLosCausantes()
        {
            List<CausanteDTO> data;
            url = $"{BaseUrl}/GetTodosLosCausantes/";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<CausanteDTO>>(url) ?? new List<CausanteDTO>();
            return data;

        }

    }




    public interface IDataPNCPropuestaDisposicion
    {
        Task<List<ProDispDTO>> GetTodasLasPropuestaDisposicion();

        Task<bool> AddPropuestaDisposicion(ProDispDTO registro);
    }

    public class DataPNCPropuestaDisposicion : IDataPNCPropuestaDisposicion
    {

        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/PNCPropuestaDisposicion";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = " ";


        public DataPNCPropuestaDisposicion(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<ProDispDTO>> GetTodasLasPropuestaDisposicion()
        {
            List<ProDispDTO> data;
            url = $"{BaseUrl}/GetTodasLasPropuestaDisposicion/";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<ProDispDTO>>(url) ?? new List<ProDispDTO>();
            return data;
        }



        public async Task<bool> AddPropuestaDisposicion(ProDispDTO registro)
        {
            bool band;
            url = $"{BaseUrl}/AddPropuestaDisposicion/{registro}";
            cliente = _clientFactory.CreateClient();
            band = await cliente.GetFromJsonAsync<bool>(url);
            return band;

        }
    }


    public interface IDataPNCRiesgo
    {
        Task<List<Pncriesgo>> ObtenerTodosLosRiesgos();

        Task<bool> RegistrarRiesgo(Pncriesgo registro);
    }


    public class DataPNCRiesgo : IDataPNCRiesgo
    {

        private readonly DbNeoContext _cotext;

        public DataPNCRiesgo(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<List<Pncriesgo>> ObtenerTodosLosRiesgos()
        {
            return await this._cotext.Pncriesgos.Where(r => r.Restado == true).ToListAsync();
        }
        public async Task<bool> RegistrarRiesgo(Pncriesgo registro){
            this._cotext.Pncriesgos.Add(registro);

            return await _cotext.SaveChangesAsync() > 0;
        }
    }




    public interface IDataPNCUnidad
    {
        Task<List<CaUnidadDTO>> GetTodosLasUnidades();
    }

    public class DataPNCUnidad : IDataPNCUnidad 
    {

        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/PNCUnidad";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = " ";


        public DataPNCUnidad(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<CaUnidadDTO>> GetTodosLasUnidades()
        {
            List<CaUnidadDTO> data;
            url = $"{BaseUrl}/GetTodosLasUnidades/";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<CaUnidadDTO>>(url) ?? new List<CaUnidadDTO>();
            return data;
        }
    }



    public interface IDataProductoNoConforme
    {
        Task<bool> AddProductoNoConforme(ProNoConDTO registro);
        Task<bool> ActualizarProductoNoConforme(int idProNoCon, ProNoConDTO registro);
        Task<List<ProNoConDTO>> GetProductoNoConforme(int idRegistro);
        Task<List<ProNoConDTO>> GetProductoNoConformeConTodaLaData(int idRegistro);
        Task<List<Calidad.DTOs.PNC.ProNoConDTO>> GetProductoNoConformePorFecha(DateTime Fecha);

        Task<List<Calidad.DTOs.PNC.ProNoConDTO>> GetProductoNoConformeEntreFechas(DateTime FechaInicio, DateTime FechaFinal);

        Task<List<Calidad.DTOs.PNC.ProNoConDTO>> GetProductoNoConformePorFiltro(DateTime fechaInicio, DateTime fechaFinal);
    }

    public class DataProductoNoConforme : IDataProductoNoConforme
    {

        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/ProductoNoConforme";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = " ";


        public DataProductoNoConforme (IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<bool> AddProductoNoConforme(ProNoConDTO registro)
        {
        {
            bool band = false;
            url = $"{BaseUrl}/AddProductoNoConforme/{registro}";
            cliente =  _clientFactory.CreateClient();
            mensaje = await cliente.PostAsJsonAsync(url, registro);
            var error = await mensaje.Content.ReadAsStringAsync();
            if(mensaje.IsSuccessStatusCode){
                band = await mensaje.Content.ReadFromJsonAsync<bool>();
            }
            return band;
        }

        }





        public async Task<bool> ActualizarProductoNoConforme(int idProNoCon, ProNoConDTO registro)
        {

        try
        {

            var client = _clientFactory.CreateClient();
            var result = await client.PutAsJsonAsync($"{BaseUrl}ActualizarProductoNoConforme/{registro}", registro);
            return result.IsSuccessStatusCode;

        }
        catch 
        {
        return false;
        }

        }



        public async Task<List<Calidad.DTOs.PNC.ProNoConDTO>> GetProductoNoConformePorFecha (DateTime Fecha)
        {
            List<Calidad.DTOs.PNC.ProNoConDTO> data;
            string fechaString = Fecha.ToString("yyyy-MM-dd");
            url = $"{BaseUrl}/GetProductoNoConformePorFecha?Fecha={fechaString}";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<Calidad.DTOs.PNC.ProNoConDTO>>(url) ?? new List<Calidad.DTOs.PNC.ProNoConDTO>();
            return data;

        }


        public async Task<List<Calidad.DTOs.PNC.ProNoConDTO>> GetProductoNoConformeEntreFechas(DateTime fechaInicio, DateTime fechaFinal)
        {

            List<Calidad.DTOs.PNC.ProNoConDTO> data;
            string fechaInicioString = fechaInicio.ToString("yyyy-MM-dd");
            string fechaFinalString = fechaFinal.ToString("yyyy-MM-dd");
            url = $"{BaseUrl}/GetProductoNoConformeEntreFechas?FechaInico={fechaInicioString}&FechaFinal={fechaFinalString}";
            data = await cliente.GetFromJsonAsync<List<Calidad.DTOs.PNC.ProNoConDTO>>(url) ?? new List<Calidad.DTOs.PNC.ProNoConDTO>();
            return data;


        }



        public async Task<List<Calidad.DTOs.PNC.ProNoConDTO>> GetProductoNoConformePorFiltro(DateTime fechaInicio, DateTime fechaFinal){
            if(fechaInicio.Date == fechaFinal.Date){
                return await this.GetProductoNoConformePorFiltro(fechaInicio, fechaFinal);
            }else if(fechaInicio.Date < fechaFinal.Date){
                return await this.GetProductoNoConformePorFiltro(fechaInicio, fechaFinal);
            }
            return await this.GetProductoNoConformePorFiltro(fechaFinal, fechaInicio);
        }



        public async Task<List<ProNoConDTO>> GetProductoNoConforme (int idRegistro)
        {
            List<ProNoConDTO> data;
            url = $"{BaseUrl}/GetProductoNoConformePorFiltro/{idRegistro}";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<ProNoConDTO>>(url) ?? new List<ProNoConDTO>();
            return data;

        }

        public async Task<List<ProNoConDTO>> GetProductoNoConformeConTodaLaData(int idRegistro)
        {
            List<ProNoConDTO> data;
            url = $"{BaseUrl}/GetProductoNoConformeConTodaLaData/{idRegistro}";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<ProNoConDTO>>(url) ?? new List<ProNoConDTO>();
            return data;

        }
    }




    public interface IDataPNCCausa
    {
        Task<List<causaDTO>> GetTodosLasCausas();
        Task<List<causaDTO>> GetTodosLasCausasPorCausante(int idCausante);

        Task<bool> AddCausa (causaDTO registro);
    }

    public class DataPNCCausa : IDataPNCCausa
    {

        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/PNCCausa";

        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = " ";


        public DataPNCCausa(IHttpClientFactory clientFactory)
        {

        _clientFactory = clientFactory;        
        
        }


        public async Task<List<causaDTO>> GetTodosLasCausas()
        {
            List<causaDTO> data;
            url = $"{BaseUrl}/GetTodosLasCausas/";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<causaDTO>>(url) ?? new List<causaDTO>();
            return data;

        }


        public async Task<List<causaDTO>> GetTodosLasCausasPorCausante(int idCausante)
        {
            List<causaDTO> datas;
            url = $"{BaseUrl}/GetTodosLasCausasPorCausante/{idCausante}";
            cliente = _clientFactory.CreateClient();
            datas = await cliente.GetFromJsonAsync<List<causaDTO>>(url) ?? new List<causaDTO>();
            return datas;
        }


        public async Task<bool> AddCausa(causaDTO registro)
        
        {
            bool band = false;
            url = $"{BaseUrl}/AddCausa/{registro}";
            cliente =  _clientFactory.CreateClient();
            mensaje = await cliente.PostAsJsonAsync(url, registro);
            var error = await mensaje.Content.ReadAsStringAsync();
            if(mensaje.IsSuccessStatusCode){
                band = await mensaje.Content.ReadFromJsonAsync<bool>();
            }
            return band;
        }
        }
    }