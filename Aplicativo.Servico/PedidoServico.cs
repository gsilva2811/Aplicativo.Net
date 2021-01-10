using Aplicativo.Dominio;

namespace Aplicativo.Servico
{
    public class PedidoServico : ServicoGenerico<Pedido>
    {
        public PedidoServico(bool enableLazyLoading = true) : base(enableLazyLoading)
        {
        }

        public Pedido ObterPorCodigoComProdutos(int id)
        {
            return Repositorio.FindFirst(x => x.Codigo == id, x => x.Produtos);
        }
    }
}
