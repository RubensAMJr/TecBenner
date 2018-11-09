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
    /// Nome da Tabela: CARTOES.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Cartoes.properties.cs
    /// </summary>
    public partial class Cartoes
    {
        public void AlterarAtivo(BusinessArgs args)
        {
            if (this.Ativo == true)
            {
                this.Ativo = false;
                args.Message = "Cartão desativado!";

            }
            else
            {
                this.Ativo = true;
                args.Message = "Cartão ativado!";
            }
            Save();
            
        }

    }
}
