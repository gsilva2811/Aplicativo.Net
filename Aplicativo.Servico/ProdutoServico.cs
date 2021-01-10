using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aplicativo.Dominio;

namespace Aplicativo.Servico
{
    public class ProdutoServico : ServicoGenerico<Produto>
    {
        public ProdutoServico(bool enableLazyLoading = true) : base(enableLazyLoading)
        {
        }
    }
}
