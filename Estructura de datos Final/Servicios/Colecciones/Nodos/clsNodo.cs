using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo>: iNodo<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Atributos
        #region Propios
        protected Tipo atrItem;
        #endregion
        #endregion
        #region Métodos
        #region Accesores
        public Tipo darItems()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Mutadores
        public bool ponerItem(Tipo prmItem)
        {
            atrItem = prmItem;
            return true;
        } 
        #endregion
        #endregion
    }
}
