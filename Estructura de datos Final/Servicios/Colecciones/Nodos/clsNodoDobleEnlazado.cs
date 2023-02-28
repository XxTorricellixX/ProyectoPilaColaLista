using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo>: clsNodo<Tipo>, iNodoDobleEnlazado<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
        #endregion
        #endregion
        #region Constructores
        #region Constructor creado personalmente
        public clsNodoDobleEnlazado()
        {
            this.atrItem = default(Tipo);
            this.atrSiguiente = null;
        } 
        #endregion
        #endregion
        #region Operaciones
        #region Método pasar siguiente
        #region Método creado personalmente
        public Tipo pasarItem
        {
            get { return atrItem; }
            set { atrItem = value; }
        }
        public clsNodoDobleEnlazado<Tipo> GetAtrAnterior
        {
            get { return atrAnterior; }
            set { atrAnterior = value; }
        }
        public clsNodoDobleEnlazado<Tipo> GetAtrSiguiente
        {
            get { return atrSiguiente; }
            set { atrSiguiente = value; }
        }
        #endregion
        #region Getters
        public clsNodoDobleEnlazado<Tipo> darAnterior()
        {
            throw new NotImplementedException();
        }
        public clsNodoDobleEnlazado<Tipo> darSiguiente()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Setters
        public bool ponerAnterior()
        {
            throw new NotImplementedException();
        }
        public bool ponerSiguiente()
        {
            throw new NotImplementedException();
        } 
        #endregion
        #endregion
        #endregion
    }
}
