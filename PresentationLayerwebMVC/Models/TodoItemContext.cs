using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PresentationLayerwebMVC.Models
{
    // Puede agregar código personalizado a este archivo. Los cambios no se pueden sobrescribir.
    // 
    // Si desea que Entity Framework descarte y regenere el código de
    // automáticamente cuando modifique el esquema de modelo, agregue el
    // base de datos al método Application_Start en el archivo Global.asax.
    // Nota: esto destruirá la base de datos y la volverá a crear cada vez que se cambie el modelo.
    // 
    // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<PresentationLayerwebMVC.Models.TodoItemContext>());
    public class TodoItemContext : DbContext
    {
        public TodoItemContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}