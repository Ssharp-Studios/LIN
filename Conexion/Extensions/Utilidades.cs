using System;
using System.Collections.Generic;

namespace Conexion.Extensions
{

    /// <summary>
    /// Clase utilidades
    /// </summary>
    public class Utilidades
    {

        /// <summary>
        /// Obtiene la IP publica del dispocitivo
        /// </summary>
        public async static Task<string> GetIpPublica()
        {
            try
            {
                // Conexion Web
                var request = new HttpClient();
                string html = await request.GetStringAsync("https://api.ipify.org/");

                // Organiza la IP
                string ip = html.Replace("\n", "");
                return ip;
            }
            catch
            {
                return "";
            }
        }


    }
}
