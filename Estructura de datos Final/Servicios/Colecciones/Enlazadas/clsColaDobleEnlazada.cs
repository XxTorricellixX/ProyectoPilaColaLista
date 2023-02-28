using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.TAD;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsColaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>, iCola<Tipo> where Tipo : IComparable<Tipo>
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
        public bool encolar(Tipo prmItem)
        {
            return insertarUltimo(prmItem);
        }
        public bool desencolar(ref Tipo prmItem)
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
