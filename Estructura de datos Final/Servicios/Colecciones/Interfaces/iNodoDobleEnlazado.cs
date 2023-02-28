using System;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Interfaces
{
    public interface iNodoDobleEnlazado<Tipo>: iNodo<Tipo> where Tipo:IComparable<Tipo>
    {
        #region Métodos
        #region Getters
        clsNodoDobleEnlazado<Tipo> darAnterior();
        clsNodoDobleEnlazado<Tipo> darSiguiente();
        #endregion
        #region Setters
        bool ponerAnterior();
        bool ponerSiguiente();
        #endregion
        #endregion
    }
}
