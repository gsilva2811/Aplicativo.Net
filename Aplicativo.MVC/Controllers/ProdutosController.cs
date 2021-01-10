using System.Web.Mvc;
using Aplicativo.Dominio;
using Aplicativo.Servico;

namespace Aplicativo.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Listar()
        {
            ProdutoServico servico = new ProdutoServico();
            return PartialView("_Lista", servico.ObterTudo());
        }

        public PartialViewResult Cadastrar()
        {
            return PartialView("_Cadastrar");
        }

        [HttpPost]
        public PartialViewResult Cadastrar(Produto produto)
        {
            ProdutoServico servico = new ProdutoServico();
            servico.Cadastrar(produto);

            return Listar();
        }

        public PartialViewResult Editar(int codigo)
        {
            ProdutoServico servico = new ProdutoServico();
            Produto produto = servico.ObterPorCodigo(codigo);
            
            return PartialView("_Editar", produto);
        }

        [HttpPost]
        public PartialViewResult Editar(Produto produto)
        {
            ProdutoServico servico = new ProdutoServico();
            servico.Editar(produto);

            return Listar();
        }

        public PartialViewResult Excluir(int codigo)
        {
            ProdutoServico servico = new ProdutoServico();
            Produto produto = servico.ObterPorCodigo(codigo);
            
            return PartialView("_Excluir", produto);
        }

        [HttpPost]
        public PartialViewResult ConfirmarExcluir(int codigo)
        {
            ProdutoServico servico = new ProdutoServico();
            servico.Excluir(codigo);

            return Listar();
        }
    }
}