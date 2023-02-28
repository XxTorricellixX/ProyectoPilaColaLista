using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTAD<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Métodos para utilizar es todas las clases
        #region Getters
        int darLongitud();
        Tipo[] darItems();
        #endregion
        #region Setters
        bool ponerItems(Tipo[] prmVector);
        #endregion
        #region Query
        bool contiene(Tipo prmItem);
        bool esValido(int prmIndice);
        bool estaVacia();
        int encontrar(Tipo prmItem);
        #endregion
        #region CRUD
        int limpiar();
        #endregion
        #region Sorting -> ordenamiento
        bool reversar();
        #endregion
        #endregion
    }
}
