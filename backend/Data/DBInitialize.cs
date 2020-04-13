using System.Linq;
using backend.Models;

namespace backend.Data{
    public static class DbInitializer
    {
        public static void Initialize(Contexto context)
        {
            if (context.Cliente.Any())
            {
                return;   // DB has been seeded
            }

            var clientes = new Cliente[]
            {
            new Cliente{Nome="Jose"},
            new Cliente{Nome="Maria"},
        
            };
            foreach (Cliente s in clientes)
            {
                context.Cliente.Add(s);
            }
            context.SaveChanges();

        }
    }
}