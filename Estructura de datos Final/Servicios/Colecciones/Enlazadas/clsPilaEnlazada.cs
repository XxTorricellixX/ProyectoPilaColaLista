using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.TAD;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaEnlazada<Tipo> : clsTADEnlazado<Tipo>, iPila<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        #endregion
        #region Accesores
        #endregion
        #endregion
        #region Métodos
        #region Accesores
        #endregion
        #region Constructores
        #endregion
        #region Mutadores
        #endregion
        #region CRUDs
        public bool apilar(Tipo prmItem)
        {
            return insertarPrimero(prmItem);
        }
        public bool desapilar(ref Tipo prmItem)
        {
            return extraerPrimero(ref prmItem);
        }
        public bool revisar(ref Tipo prmItem)
        {
            return recuperarPrimero(ref prmItem);
        }
        #endregion 
        #endregion
    }
}
