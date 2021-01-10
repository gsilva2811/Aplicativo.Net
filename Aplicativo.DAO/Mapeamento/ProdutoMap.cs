using System.Data.Entity.ModelConfiguration;
using Aplicativo.Dominio;

namespace Aplicativo.DAO.Mapeamento
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            HasKey(x => x.Codigo);
            Property(x => x.Nome).IsRequired();
            Property(x => x.Valor).IsRequired();
        }
    }
}