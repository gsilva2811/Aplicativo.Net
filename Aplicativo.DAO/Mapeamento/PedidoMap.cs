using System.Data.Entity.ModelConfiguration;
using Aplicativo.Dominio;


namespace Aplicativo.DAO.Mapeamento
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            HasKey(x => x.Codigo);
            Property(x => x.Solicitante).IsRequired();
            Property(x => x.DataDoPedido).IsRequired();
            HasMany(x => x.Produtos);
        }
    }
}