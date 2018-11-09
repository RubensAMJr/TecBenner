using Benner.Restaurante.Interfaces;
using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;


namespace Benner.Restaurante.Entidades
{
    
    
    /// <summary>
    /// Nome da Tabela: MESACOMANDAS.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Mesacomandas.properties.cs
    /// </summary>
    public partial class Mesacomandas
    {
        //[Inject]
        //public IGerenciadorDeMesasEComandas Gerenciador{ get; set; }

        protected override void Created()
        {
           
            this.Valortotal = 0;
            base.Created();
        }

        public void PagaPedido(BusinessArgs args)
        {
                
                var itemPedidoDao = ItemPedidoDao.CreateInstance();
                var itens = itemPedidoDao.PegarPedidosDaComanda(this.Handle);
                foreach (var item in itens)
                {
                    var atual = itemPedidoDao.Get(item.Handle);
                    atual.Entregue = true;
                    atual.ComandaHandle = null;
                    itemPedidoDao.Save(atual);
                }
                args.Message = "Comanda finalizada , Troco a pagar:" + (this.ValorDigitado - this.Valortotal);
                this.Delete();
        }

        protected override void Saving()
        {
            if (this.ValorDigitado == null)
            {
                var comandaDao = ComandasDao.CreateInstance();
                var mesaDao = MesasDao.CreateInstance();
                var comanda = comandaDao.Get(this.ComandaHandle);
                var mesa = mesaDao.Get(this.MesaHandle);
                mesa.Ocupada = true;
                comanda.Ocupada = true;
                comandaDao.Save(comanda);
                mesaDao.Save(mesa);
            }else if (this.ValorDigitado < this.Valortotal)
            {
                throw new BusinessException("Valor digitado é menor do que o total!");

            }

            base.Saving();
        }


        protected override void Deleting()
        {
                var comandaDao = ComandasDao.CreateInstance();
                var mesaDao = MesasDao.CreateInstance();
                var comanda = comandaDao.Get(this.ComandaHandle);
                var mesa = mesaDao.Get(this.MesaHandle);
                if (comandaDao.PegarNumeroDeComandasDaMesa(this.MesaHandle) <= 1)
                {
                    mesa.Ocupada = false;
                    mesaDao.Save(mesa);
                }
                comanda.Ocupada = false;
                comandaDao.Save(comanda);
                base.Deleting();
           
        }


    }
}
