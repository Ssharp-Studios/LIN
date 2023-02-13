
 

namespace Conexion.Controladores
{

    /// <summary>
    /// Acceso a datos de 'Proveedor'
    /// </summary>
    public static class Proveedor
    {


        /// <summary>
        /// Crea un Proveedor en la base de datos
        /// </summary>
        public static (EResponses response, int lastId) Create(Modelos.Proveedor modelo)
        {
            return  AccesoDatos.Proveedor.Create(modelo);
        }



        /// <summary>
        /// Crea un Proveedor en la base de datos (Async)
        /// </summary>
        public async static Task<(EResponses response, int lastId)> CreateAsync(Modelos.Proveedor modelo)
        {
            return await AccesoDatos.Proveedor.CreateAsync(modelo);
        }



        /// <summary>
        /// Obtiene la lista proveedores asociada a una cuenta
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public static (EResponses response, List<Modelos.Proveedor>) ReadAll(int id)
        {
            return AccesoDatos.Proveedor.ReadAll(id);
        }



        /// <summary>
        /// Obtiene la lista proveedores asociada a una cuenta (Async)
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        public async static Task<(EResponses response, List<Modelos.Proveedor>)> ReadAllAsync(int id)
        {
            return await AccesoDatos.Proveedor.ReadAllAsync(id);
        }



        /// <summary>
        /// Obtiene un elemento 'Proveedor' por medio del ID
        /// </summary>
        /// <param name="id">ID del proveedor</param>
        public static (EResponses response, Modelos.Proveedor) ReadOne(int id)
        {
            return AccesoDatos.Proveedor.ReadOne(id);
        }

        

        /// <summary>
        /// Obtiene un elemento 'Proveedor' por medio del ID (Async)
        /// </summary>
        /// <param name="id">ID del proveedor</param>
        public async static Task<(EResponses response, Modelos.Proveedor)> ReadOneAsync(int id)
        {
            return await AccesoDatos.Proveedor.ReadOneAsync(id);
        }



        /// <summary>
        /// Actualiza la informacion de un Proveedor
        /// </summary>
        public static EResponses Update(Modelos.Proveedor modelo)
        {
            return AccesoDatos.Proveedor.Update(modelo);
        }



        /// <summary>
        /// Actualiza la informacion de un Proveedor (Async)
        /// </summary>
        public async static Task<EResponses> UpdateAsync(Modelos.Proveedor modelo)
        {
            return await AccesoDatos.Proveedor.UpdateAsync(modelo);
        }



        /// <summary>
        /// Elimina un proveedor de la base de datos
        /// </summary>
        public static EResponses Delete(Modelos.Proveedor modelo)
        {
            return AccesoDatos.Proveedor.Delete(modelo);
        }


        /// <summary>
        /// Elimina un proveedor de la base de datos (Async)
        /// </summary>
        public async static Task<EResponses> DeleteAsync(Modelos.Proveedor modelo)
        {
            return await AccesoDatos.Proveedor.DeleteAsync(modelo);
        }


    }

}
