using System;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTADEnlazada<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Métodos
        #region Getters
        clsNodoEnlazado<Tipo> darPrimero();
        clsNodoEnlazado<Tipo> darUltimo();
        #endregion
        #endregion
    }
}
