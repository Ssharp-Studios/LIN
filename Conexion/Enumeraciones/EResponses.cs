namespace Conexion
{

    /// <summary>
    /// Enumeracion de respuestas
    /// </summary>
    public enum EResponses
    {

        /// <summary>
        /// Accion realizada con exito
        /// </summary>
        Success,

        /// <summary>
        /// Sin conexion a la base de datos
        /// </summary>
        NotConnection,

        /// <summary>
        /// No existe una cuenta
        /// </summary>
        NotExistAccount,

        /// <summary>
        /// Ya existe una cuenta
        /// </summary>
        ExistAccount,

        /// <summary>
        /// Cuenta bloqueada
        /// </summary>
        LockAccount,

        /// <summary>
        /// Cuenta desactivada
        /// </summary>
        DisableAccount,

        /// <summary>
        /// Contraseña invalida
        /// </summary>
        InvalidPassword,

        /// <summary>
        /// No hay columnas que mostrar
        /// </summary>
        NotRows,

        /// <summary>
        /// Usuario vacio
        /// </summary>
        UserVoid,

        /// <summary>
        /// Contraseña vacia
        /// </summary>
        PasswordVoid,

        /// <summary>
        /// Contraseña corta
        /// </summary>
        PasswordShort,

        /// <summary>
        /// Nombre vacia
        /// </summary>
        NameVoid,

        /// <summary>
        /// Error indefinido
        /// </summary>
        Undefined

    }

}
