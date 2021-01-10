using System.Web.Mvc;
using Aplicativo.Dominio;
using Aplicativo.Servico;

namespace Aplicativo.MVC.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Listar()
        {
            PedidoServico servico = new PedidoServico();
            return PartialView("_Lista", servico.ObterTudo());
        }

        public PartialViewResult Cadastrar()
        {
            return PartialView("_Cadastrar");
        }

        [HttpPost]
        public PartialViewResult Cadastrar(Pedido pedido)
        {
            PedidoServico servico = new PedidoServico();
            servico.Cadastrar(pedido);

            return Listar();
        }

        public PartialViewResult Editar(int codigo)
        {
            PedidoServico servico = new PedidoServico();
            Pedido pedido = servico.ObterPorCodigoComProdutos(codigo);
            return PartialView("_Editar", pedido);
        }

        [HttpPost]
        public PartialViewResult Editar(Pedido pedido)
        {
            PedidoServico servico = new PedidoServico();
            servico.Editar(pedido);

            return Listar();
        }

        public PartialViewResult Excluir(int codigo)
        {
            PedidoServico servico = new PedidoServico();
            Pedido pedido = servico.ObterPorCodigoComProdutos(codigo);
            return PartialView("_Excluir", pedido);
        }

        [HttpPost]
        public PartialViewResult ConfirmarExcluir(int codigo)
        {
            PedidoServico servico = new PedidoServico();
            servico.Excluir(codigo);

            return Listar();
        }
    }
}