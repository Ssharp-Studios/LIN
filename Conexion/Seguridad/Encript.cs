using System.Security.Cryptography;

namespace Conexion.Seguridad
{
    public static class Encript
    {

        /// <summary>
        /// Encripta una clave
        /// </summary>
        public static string Encriptar(string clave)
        {
            SHA512 hasher = SHA512.Create();
            var bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(clave));
            hasher.Dispose();
            return Convert.ToBase64String(bytes);
        }

    }

}
