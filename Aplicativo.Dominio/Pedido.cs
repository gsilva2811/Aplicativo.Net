using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicativo.Dominio
{
    public class Pedido
    {
        public int Codigo { get; set; }
        public string Solicitante { get; set; }
        public DateTime DataDoPedido { get; set; }
        public virtual List<Produto> Produtos { get; set; }

        #region Propriedades Calculadas / Não mapeadas

        public decimal ValorTotaldoPedido => Produtos.Sum(x => x.Valor);
        
        #endregion Propriedades Calculadas / Não mapeadas

        public Pedido()
        {
            Produtos = new List<Produto>();
            DataDoPedido = DateTime.Now;
        }
    }
}
