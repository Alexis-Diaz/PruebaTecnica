using System;
using System.Data.Entity;
using System.Linq;

namespace VentaEN
{
    public class ComunDB : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'ComunDB' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'VentaEN.ComunDB' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'ComunDB'  en el archivo de configuración de la aplicación.
        private const string conn = @"Data source=DELL-PC\SQLEXPRESS; initial catalog=DbVentas; integrated security=true; app=EntityFramework ";
        public ComunDB()
            : base(conn)
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}