using Benner.Restaurante.Entidades;
using Benner.Restaurante.Interfaces;
using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Restaurante.Components
{
    public class GerenciadorDeMesasEComanda : BusinessComponent<GerenciadorDeMesasEComanda>, IGerenciadorDeMesasEComandas
    {

        private readonly IMesasDao _mesasDao;
        private readonly IComandasDao _comandasDao;
       

        public GerenciadorDeMesasEComanda(IMesasDao mesasDao, IComandasDao comandasDao)
        {
            _mesasDao = mesasDao;
            _comandasDao = comandasDao;
        }

        public void OcupaComandaEMesa(IMesacomandas MesaComandas)
        {

            var comanda = _comandasDao.Get(MesaComandas.ComandaHandle);
            var mesa = _mesasDao.Get(MesaComandas.MesaHandle);
            comanda.MesaHandle = mesa.Handle;
            mesa.Ocupada = true;
            comanda.Ocupada = true;
            _comandasDao.Save(comanda);
            _mesasDao.Save(mesa);
        }
    }
}
