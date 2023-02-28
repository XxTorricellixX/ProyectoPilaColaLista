using System;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.TAD;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>, iPila<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        #endregion
        #region Accesores
        #endregion
        #endregion
        #region Accesores
        #endregion
        #region Mutadores
        #endregion
        #region Constructores
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
    }
}
