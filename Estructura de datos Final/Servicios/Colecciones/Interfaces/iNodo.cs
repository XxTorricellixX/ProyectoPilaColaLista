using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iNodo<Tipo> where Tipo:IComparable<Tipo>
    {
        #region Métodos
        #region Getters
        Tipo darItems();
        #endregion
        #region Setters
        bool ponerItem(Tipo prmItem);
        #endregion
        #endregion
    }
}
