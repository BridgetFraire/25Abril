using System;
using Abril25.ITD.PERROSPERDIDOS.DOMAIN.INTERFACES;

namespace _25Abril.ITD.PERROSPERDIDOS.DOMAIN.INTERFACES
{
    public interface IMascotaPerdidaService
    {
        Task<int> ModificarCaracteristicasPerroPerdido(int idMascota, string nuevasCaracteristicas);
        Task<int> ReportarPerroPerdido(int idUsuario, int celular, string raza, string color, string tamano, char sexo, string caracteristicas, DateTime fechaVisto, string lugarVisto, byte[] imagen);
        Task<IEnumerable<MascotaPerdida>> ObtenerPublicacionesRecientes();
    }
}

