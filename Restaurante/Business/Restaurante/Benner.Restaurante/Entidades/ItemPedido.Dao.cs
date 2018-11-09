using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Restaurante.Entidades
{
    public partial interface IItemPedidoDao
    {
        IList<EntityBase> PegarPedidosDaComanda(Handle mesacomanda);
    }

    public partial class ItemPedidoDao
    {
        public IList<EntityBase> PegarPedidosDaComanda(Handle mesacomanda)
        {
            Query query = new Query("SELECT * FROM ITEMPEDIDO WHERE COMANDA = :MESACOMANDAHANDLE");
            query.Parameters.Add(new Parameter("MESACOMANDAHANDLE", mesacomanda));

            var resultado = query.Execute();
            return resultado;

        }


    }
}
