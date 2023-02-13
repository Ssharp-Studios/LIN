
namespace Conexion.StringFormat
{

    /// <summary>
    /// Formato a las cadenas
    /// </summary>
    internal static class FormatoString
    {

        /// <summary>
        /// Formato basico alfanumerico
        /// </summary>
        public static string AlphaNumericFormat(string input)
        {

            string letters = "qwertyuiopasdfghjklñzxcvbnm";
            string numbers = "1234567890";
            string chars = " ";

            // Fomato
            return FormatLevel(input, letters + numbers + chars);

        }



        /// <summary>
        /// Formato alfanumerico caracteres 
        /// </summary>
        public static string MailFormat(string input)
        {

            string letters = "qwertyuiopasdfghjklñzxcvbnm";
            string numbers = "1234567890";
            string chars = " .@-_";

            // Fomato
            return FormatLevel(input, letters + numbers + chars);

        }




        /// <summary>
        /// Formato
        /// </summary>
        private static string FormatLevel(string input, string chars)
        {
            if (input == null)
                return "";

            string formated = "";
            foreach (char c in input)
            {
                if (chars.Contains(c))
                    formated += c;
            }

            return formated;
        }


    }
}
