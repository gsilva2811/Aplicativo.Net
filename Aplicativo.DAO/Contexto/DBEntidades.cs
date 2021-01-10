using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Aplicativo.DAO.Mapeamento;
using Aplicativo.Dominio;


namespace Aplicativo.DAO.Contexto
{
    public class DBEntidades : DbContext
    {
        public DBEntidades() : base("ConnectionString")
        {
        }

        public DBEntidades(bool lazyLoadingEnabled = true) : base("ConnectionString")
        {
            //Database.SetInitializer<DBEntidades>(null);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DBEntidades>());

            Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            Configuration.ProxyCreationEnabled = lazyLoadingEnabled;

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 600;

            Database.Log = sql => System.Diagnostics.Debug.WriteLine(sql);
        }
        
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new PedidoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
