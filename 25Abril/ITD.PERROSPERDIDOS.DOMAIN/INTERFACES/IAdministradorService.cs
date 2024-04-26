using System;
namespace _25Abril.ITD.PERROSPERDIDOS.DOMAIN.INTERFACES
{
    public interface IAdministradorService
    {
        Task<int> AgregarAdministrador(string usuario, long telefono, string contrasena);
        Task<int> ModificarNumeroCelular(int idUsuario, string contraseña, string nuevoNumeroCelular);
    }
}

