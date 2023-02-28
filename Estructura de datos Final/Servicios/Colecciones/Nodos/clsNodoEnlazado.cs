using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo>: clsNodo<Tipo>, iNodoEnlazado<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoEnlazado<Tipo> atrSiguiente;
        #endregion
        #endregion
        #region Métodos
        #region Constructores
        #region Constructor creador personalmente
        public clsNodoEnlazado()
        {
            this.atrItem = default(Tipo);
            this.atrSiguiente = null;
        } 
        #endregion
        #endregion
        #region Método pasar siguiente
        #region Método creado personalmente
        public Tipo pasarItem
        {
            get { return atrItem; }
            set { atrItem = value; }
        }
        public clsNodoEnlazado<Tipo> GetAtrSiguiente
        {
            get { return atrSiguiente; }
            set { atrSiguiente = value; }
        }
        #endregion
        #region Getters
        public clsNodoEnlazado<Tipo> darSiguiente()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Setters
        public bool ponerSiguiente()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #endregion
        #endregion
    }
}
