using Benner.Restaurante.Components;
using Benner.Restaurante.Interfaces;
using Benner.Tecnologia.Business;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Restaurante.Nucleo.IoC
{
    public class RegistradorDependencia : NinjectModule
    {
        public override void Load()
        {

            BusinessComponent.Register<IGerenciadorDeMesasEComandas, GerenciadorDeMesasEComanda>(Kernel);
        }
    }
}
