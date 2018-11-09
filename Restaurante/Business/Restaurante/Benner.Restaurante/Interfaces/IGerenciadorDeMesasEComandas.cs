using Benner.Restaurante.Entidades;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Restaurante.Interfaces
{
    public interface IGerenciadorDeMesasEComandas
    {

        void OcupaComandaEMesa(IMesacomandas MesaComandas);
        

    }
}
