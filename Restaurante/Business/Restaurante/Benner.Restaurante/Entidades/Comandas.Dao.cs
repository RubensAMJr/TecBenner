using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.Restaurante.Entidades
{

    public partial interface IComandasDao
    {
        int PegarNumeroDeComandasDaMesa(Handle mesaHandle);
    }
    public partial class ComandasDao : IComandasDao
    {
       

        public int PegarNumeroDeComandasDaMesa(Handle mesaHandle)
        {
            Query query = new Query("SELECT * FROM MESACOMANDAS C WHERE C.MESA = :MESAHANDLE");
            query.Parameters.Add(new Parameter("MESAHANDLE", mesaHandle));

            var resultado = query.Execute().ToList();
            return resultado.Count;

            /*Criteria filtro = new Criteria();
            filtro.AddWhereClause("A.HANDLE = :PHANDLE AND A.OCUPADO = 'N'");
            filtro.Parameters.Add("PHANDLE", 12);
            Mesas mesas = Mesas.GetMany(filtro).FirstOrDefault();
            mesas.Edit();
            mesas.Ocupada = true;
            mesas.Save();*/


        }
    }
}
