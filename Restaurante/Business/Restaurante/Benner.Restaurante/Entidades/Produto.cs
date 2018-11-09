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
    /// Nome da Tabela: PRODUTO.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Produto.properties.cs
    /// </summary>
    public partial class Produto
    {
        public void MudarFalta(BusinessArgs args)
        {
            this.EstaEmFalta = !this.EstaEmFalta;
            Save();
            args.Message = "Falta alterada!";
        }

    }
}
