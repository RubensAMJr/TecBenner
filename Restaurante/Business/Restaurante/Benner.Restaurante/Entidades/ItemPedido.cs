using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;


namespace Benner.Restaurante.Entidades
{
    
    
    /// <summary>
    /// Nome da Tabela: ITEMPEDIDO.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo ItemPedido.properties.cs
    /// </summary>
    public partial class ItemPedido
    {

        public void FinalizarPedido(BusinessArgs args)
        {
            var produtoDao = ProdutoDao.CreateInstance();
            var mesaComandadao = MesacomandasDao.CreateInstance();
            var comandaDao = ComandasDao.CreateInstance();
            var mesaDao = MesasDao.CreateInstance();
            var produto = produtoDao.Get(this.ProdutoHandle);
            var mesacomanda = mesaComandadao.Get(this.ComandaHandle);
            var mesa = mesaDao.Get(mesacomanda.MesaHandle).Numero;
            var comanda = comandaDao.Get(mesacomanda.ComandaHandle).Numero;
            this.Entregue = true;
            mesacomanda.Valortotal += produto.Preco;
            mesaComandadao.Save(mesacomanda);
            Save();
            args.Message = "Entregar pedido na Comanda "+comanda+" Localizada na Mesa "+mesa;
        }


        protected override void Deleting()
        {
            
            var produtoDao = ProdutoDao.CreateInstance();
            var mesacomandaDao = MesacomandasDao.CreateInstance();
            var produto = produtoDao.Get(this.ProdutoHandle);
            var mesacomanda = mesacomandaDao.Get(this.ComandaHandle);
            if (mesacomanda.Valortotal > 0 )
            {
              mesacomanda.Valortotal -= produto.Preco;
              mesacomandaDao.Save(mesacomanda);
            }
            base.Deleting();
        }

        

        protected override void Saving()
        {
            if (this.Observacao == null)
            {
                this.Observacao = "Nenhuma";
            }
            base.Saving();
        }





    }
}
