using Calidad.Model;
using Microsoft.EntityFrameworkCore;

namespace Calidad.ProductoNoConforme
{
    public interface IDataPNCIdentificacion
    {
        Task<List<Pncidentif>> ObtenerTodosLasIdentificaciones();
    }

    public class DataPNCIdentificacion : IDataPNCIdentificacion
    {

        private readonly DbNeoContext _cotext;

        public DataPNCIdentificacion(DbNeoContext context)
        {
            this._cotext = context;
        }

        public async Task<List<Pncidentif>> ObtenerTodosLasIdentificaciones()
        {
            return await this._cotext.Pncidentifs.Where(i => i.Iestado == true).ToListAsync();
        }
    }

    public interface IDataPNCTipo
    {
        Task<List<Pnctipo>> ObtenerTodosLosTipos();
    }

    public class DataPNCTipo : IDataPNCTipo
    {

        private readonly DbNeoContext _cotext;

        public DataPNCTipo(DbNeoContext context)
        {
            this._cotext = context;
        }

        public async Task<List<Pnctipo>> ObtenerTodosLosTipos()
        {
            return await this._cotext.Pnctipos.Where(t => t.Testado == true).ToListAsync();
        }
    }

    public interface IDataPNCDisposicionDefinitiva
    {
        Task<List<PncdisDefi>> ObtenerTodosLasDisposicionDefinitiva();
    }


    public class DataPNCDisposicionDefinitiva : IDataPNCDisposicionDefinitiva
    {

        private readonly DbNeoContext _cotext;

        public DataPNCDisposicionDefinitiva(DbNeoContext context)
        {
            this._cotext = context;
        }

        public async Task<List<PncdisDefi>> ObtenerTodosLasDisposicionDefinitiva()
        {
            return await this._cotext.PncdisDefis.Where(d => d.Ddestado == true).ToListAsync();
        }
    }

    public interface IDataPNCCausante
    {
        Task<List<Pnccausante>> ObtenerTodosLosCausantes();
    }

    public class DataPNCCausante : IDataPNCCausante
    {

        private readonly DbNeoContext _cotext;

        public DataPNCCausante(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<List<Pnccausante>> ObtenerTodosLosCausantes()
        {
            return await this._cotext.Pnccausantes.Where(c => c.Cestado == true).ToListAsync();
        }

    }

    public interface IDataPNCPropuestaDisposicion
    {
        Task<List<PncproDisp>> ObtenerTodasLasPropuestaDisposicion();

        Task<bool> InsertarPropuestaDisposicion(PncproDisp registro);
    }

    public class DataPNCPropuestaDisposicion : IDataPNCPropuestaDisposicion
    {

        private readonly DbNeoContext _cotext;

        public DataPNCPropuestaDisposicion(DbNeoContext context)
        {
            this._cotext = context;
        }

        public async Task<List<PncproDisp>> ObtenerTodasLasPropuestaDisposicion()
        {
            return await this._cotext.PncproDisps.Where(p => p.Pdestado == true).ToListAsync();
        }

        public async Task<bool> InsertarPropuestaDisposicion(PncproDisp registro){
            this._cotext.PncproDisps.Add(registro);
            return await _cotext.SaveChangesAsync() > 0;
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
        Task<List<Pncunidad>> ObtenerTodosLasUnidades();
    }

    public class DataPNCUnidad : IDataPNCUnidad 
    {

        private readonly DbNeoContext _cotext;

        public DataPNCUnidad(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<List<Pncunidad>> ObtenerTodosLasUnidades()
        {
            return await this._cotext.Pncunidads.Where(u => u.Uestado == true).ToListAsync();
        }
    }

    public interface IDataProductoNoConforme
    {
        Task<bool> InsertarProductoNoConforme(ProNoCon registro);

        Task<bool> ActualizarProductoNoConforme(int idProNoCon, ProNoCon registro);

        Task<List<Calidad.Model.ProductoNoConforme>> ObtenerProductoNoConformePorFecha(DateTime Fecha);

        Task<List<Calidad.Model.ProductoNoConforme>> ObtenerProductoNoConformeEntreFechas(DateTime FechaInicio, DateTime FechaFinal);

        Task<List<Calidad.Model.ProductoNoConforme>> ObtenerProductoNoConformePorFiltro(DateTime fechaInicio, DateTime fechaFinal);
    }

    public class DataProductoNoConforme : IDataProductoNoConforme
    {

        private readonly DbNeoContext _cotext;

        public DataProductoNoConforme(DbNeoContext context)
        {
            this._cotext = context;
        }
        public async Task<bool> InsertarProductoNoConforme(ProNoCon registro)
        {
            this._cotext.ProNoCons.Add(registro);
            return await _cotext.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarProductoNoConforme(int idProNoCon, ProNoCon registro){
            ProNoCon? data = await this._cotext.ProNoCons.Where(p => p.IdProNoCon == idProNoCon).FirstOrDefaultAsync();
            if(data != null){
                data.IdCausante = registro.IdCausante;
                data.IdDisDefi = registro.IdDisDefi;
                data.IdEstado = registro.IdEstado;
                data.IdIdentif = registro.IdIdentif;
                data.IdLugaEven = registro.IdLugaEven;
                data.IdProDisp = registro.IdProDisp;
                data.IdRiesgo = registro.IdRiesgo;
                data.IdTipo = registro.IdTipo;
                data.IdUnidad = registro.IdUnidad;
                data.Pnccantida = registro.Pnccantida;
                data.Pnccargador = registro.Pnccargador;
                data.PnccauLibe = registro.PnccauLibe;
                data.Pnccausa = registro.Pnccausa;
                data.PnccodProd = registro.PnccodProd;
                data.Pncconsecu = registro.Pncconsecu;
                data.PncdesProd = registro.PncdesProd;
                data.Pncfecha = registro.Pncfecha;
                data.Pncinconfo = registro.Pncinconfo;
                data.PncindLibe = registro.PncindLibe;
                data.Pnclote = registro.Pnclote;
                return 0 < await _cotext.SaveChangesAsync();
            }
            return false;
        }

        public async Task<List<Calidad.Model.ProductoNoConforme>> ObtenerProductoNoConformePorFecha(DateTime Fecha){
            return await this._cotext.ProductoNoConformes.Where(p => p.Fecha.Date == Fecha.Date).ToListAsync();
        }

        public async Task<List<Calidad.Model.ProductoNoConforme>> ObtenerProductoNoConformeEntreFechas(DateTime fechaInicio, DateTime fechaFinal){
            return await this._cotext.ProductoNoConformes.Where(p => p.Fecha.Date >= fechaInicio.Date && p.Fecha.Date <= fechaFinal.Date).ToListAsync();
        }

        public async Task<List<Calidad.Model.ProductoNoConforme>> ObtenerProductoNoConformePorFiltro(DateTime fechaInicio, DateTime fechaFinal){
            if(fechaInicio.Date == fechaFinal.Date){
                return await this.ObtenerProductoNoConformePorFecha(fechaInicio);
            }else if(fechaInicio.Date < fechaFinal.Date){
                return await this.ObtenerProductoNoConformeEntreFechas(fechaInicio,fechaFinal);
            }
            return await this.ObtenerProductoNoConformeEntreFechas(fechaFinal,fechaInicio);

        }
    }


}