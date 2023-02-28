using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.TAD
{
    public class clsTAD<Tipo> : iTAD<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        protected int atrLongitud;
        #endregion
        #region Métodos
        #region Implementados
        public virtual bool contiene(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public virtual Tipo[] darItems()
        {
            throw new NotImplementedException();
        }
        public int darLongitud()
        {
            return atrLongitud;
        }
        public virtual int encontrar(Tipo prmItem)
        { 
            throw new NotImplementedException();
        }
        public int limpiar()
        {
            throw new NotImplementedException();
        }
        public virtual bool ponerItems(Tipo[] prmVector)
        {
            throw new NotImplementedException();
        }
        public virtual bool reversar()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Constructores
        protected virtual void constructorSinParametros()
        {
            throw new NotImplementedException();
        }
        protected virtual void constructorConCapacidad(int prmCapacidad)
        {
            throw new NotImplementedException();
        }
        protected virtual void constructorCapacidadFlexible(int prmCapacidad, bool prmDinamica)
        {
            throw new NotImplementedException();
        }
        protected virtual void constructorCapacidadFactorCrecimiento(int prmCapacidad, int prmFactorCrecimiento)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CRUDs
        #region Inserción
        protected bool insertarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice == 0) return insertarPrimero(prmItem);
            if (prmIndice == atrLongitud) return insertarUltimo(prmItem);
            if (esValido(prmIndice)) return insertarEnMedio(prmIndice, prmItem);
            return false;
        }
        protected virtual bool insertarPrimero(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected virtual bool insertarUltimo(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected virtual bool insertarEnMedio(int prmIndice, Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Extracción
        protected virtual bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice == 0) return extraerPrimero(ref prmItem);
            if (prmIndice == atrLongitud-1) return extraerUltimo(ref prmItem);
            if (esValido(prmIndice)) return extraerEnMedio(prmIndice, ref prmItem);
            return false;
        }
        protected virtual bool extraerPrimero(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected virtual bool extraerUltimo(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected virtual bool extraerEnMedio(int prmIndice, ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Modificación
        protected bool modificarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice == 0) return modificarPrimero(prmItem);
            if (prmIndice == atrLongitud - 1) return modificarUltimo(prmItem);
            if (esValido(prmIndice)) return modificarEnMedio(prmIndice, prmItem);
            return false;
        }
        protected bool modificarPrimero(Tipo prmItem)
        {
            if (irPrimero())
            {
                ponerItemActual(prmItem);
                return true;
            }
            return false;
        }
        protected bool modificarUltimo(Tipo prmItem)
        {
            if (irUltimo())
            {
                ponerItemActual(prmItem);
                return true;
            }
            return false;
        }
        protected bool modificarEnMedio(int prmIndice, Tipo prmItem)
        {
            if (irIndice(prmIndice))
            {
                ponerItemActual(prmItem);
                return true;
            }
            return false;
        }
        #endregion
        #region Revisión  o Recuperadores
        protected bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice == 0) return recuperarPrimero(ref prmItem);
            if (prmIndice == atrLongitud - 1) return recuperarUltimo(ref prmItem);
            if (esValido(prmIndice)) return recuperarEnMedio(prmIndice, ref prmItem);
            return false;
        }
        protected bool recuperarPrimero(ref Tipo prmItem)
        {
            if (irPrimero())
            {
                prmItem = atrItemActual;
                return true;
            }
            prmItem = default(Tipo);
            return false;
        }
        protected bool recuperarUltimo(ref Tipo prmItem)
        {
            if (irUltimo())
            {
                prmItem = atrItemActual;
                return true;
            }
            prmItem = default(Tipo);
            return false;
        }
        protected bool recuperarEnMedio(int prmIndice, ref Tipo prmItem)
        {
            if (irIndice(prmIndice))
            {
                prmItem = atrItemActual;
                return true;
            }
            prmItem = default(Tipo);
            return false;
        }
        #endregion
        #region Consultores
        public bool esValido(int prmIndice)
        {
            if (prmIndice>0 && prmIndice<atrLongitud)
            {
                return true;
            }
            return false;
        }
        public bool estaVacia()
        {
            if (atrLongitud==0)
            {
                return true;
            }
            return false;
        }
        #endregion
        #endregion
        #region Patrón iterador  -> AUN POR IMPLEMENTAR
        #region Atributos
        protected int atrIndiceActual;
        protected Tipo atrItemActual;
        #endregion
        #region Operaciones
        #region Accesores
        public int darIndiceActual()
        {
            return atrIndiceActual;
        }
        public Tipo darItemActual()
        {
            return atrItemActual;
        }
        #endregion
        #region Mutadores
        public virtual void ponerItemActual(Tipo prmItem) { }
        #endregion
        #region Posicionadores
        public virtual bool irPrimero()
        {
            return false;
        }
        public virtual bool irUltimo()
        {
            return false;
        }
        public bool irAnterior()
        {
            if (hayAnterior())
            {
                return retrocederItem();
            }
            else { return false; }
        }
        public bool irSiguiente()
        {
            if (haySiguiente())
            {
                return avanzarItem();
            }
            else { return false; }
        }
        public virtual bool irIndice(int prmIndice)
        {
            if (prmIndice == 0) return irPrimero();
            if (prmIndice == atrLongitud - 1) return irUltimo();
            if (esValido(prmIndice))
            {
                irPrimero();
                while (atrIndiceActual < prmIndice)
                {
                    irSiguiente();
                    return true;
                }
            }
            return false;
        }
        protected virtual bool avanzarItem()
        {
            return false;
        }
        protected virtual bool retrocederItem()
        {
            return false;
        }
        #endregion
        #region Consultores
        public bool hayAnterior()
        {
            return (estaVacia() == false && atrIndiceActual > 0);
        }
        public bool haySiguiente()
        {
            return (estaVacia() == false && atrIndiceActual < atrLongitud - 1);
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}
