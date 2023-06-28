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
            return await this._cotext.Pncidentifs.Where(d => d.Iestado == true).ToListAsync();
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
            return await this._cotext.Pnctipos.Where(d => d.Testado == true).ToListAsync();
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
}