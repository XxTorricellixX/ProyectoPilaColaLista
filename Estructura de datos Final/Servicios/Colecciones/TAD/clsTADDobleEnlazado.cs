using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.TAD
{
    public class clsTADDobleEnlazado<Tipo> : clsTAD<Tipo>, iTADDobleEnlazado<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        protected clsNodoDobleEnlazado<Tipo> atrPrimero;
        protected clsNodoDobleEnlazado<Tipo> atrUltimo;
        protected Tipo[] atrItems;
        #endregion
        #region Métodos
        #region Operaciones
        #region Accesores
        #region Implementados
        public clsNodoDobleEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }
        public clsNodoDobleEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
        #endregion
        public override Tipo[] darItems()
        {
            return atrItems;
        }
        #endregion
        #region Setters
        public override bool ponerItems(Tipo[] prmVector)
        {
            bool varComprobante = true;
            atrItems = prmVector;
            if (prmVector.Length == 0)
            {
                varComprobante = false;
            }
            else if (prmVector.Length == int.MaxValue / 16)
            {
                atrLongitud = atrItems.Length;
            }
            else if (prmVector.Length == int.MaxValue / 16 + 1)
            {
                varComprobante = false;
                atrLongitud = 0;
                atrItems = null;
            }
            else
            {
                atrLongitud = atrItems.Length;
                for (int i = 0; i < atrItems.Length; i++)
                {
                    clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
                    varActual.pasarItem = atrItems[i];
                    if (atrPrimero == null)
                    {
                        atrPrimero = varActual;
                        atrUltimo = atrPrimero;
                    }
                    else
                    {
                        atrUltimo.GetAtrSiguiente = varActual;
                        varActual.GetAtrAnterior = atrUltimo;
                        atrUltimo = varActual;
                    }
                }
            }
            return varComprobante;
        }
        #endregion
        #region Constructores

        #endregion
        #region CRUDs
        #region Inserción
        protected override bool insertarPrimero(Tipo prmItem)
        {
            Tipo[] varVectorClonado;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            int i = 0;
            if (atrItems == null)
            {
                atrItems = new Tipo[atrLongitud + 1];
            }
            else if (atrItems.Length == atrLongitud && atrItems.Length < int.MaxValue / 16)
            {
                varVectorClonado = new Tipo[atrLongitud + 1];
                Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                atrItems = varVectorClonado;
            }
            else if (atrItems.Length >= int.MaxValue / 16)
            {
                return false;
            }
            if (atrItems.Length > 0 && atrItems.Length < int.MaxValue / 16)
            {
                varActual.pasarItem = prmItem;
                if (atrPrimero == null)
                {
                    atrPrimero = varActual;
                    atrUltimo = atrPrimero;
                }
                else
                {
                    varActual.GetAtrSiguiente = atrPrimero;
                    varActual.GetAtrSiguiente.GetAtrAnterior = varActual;
                    atrPrimero = varActual;
                }
                varActual = atrPrimero;
                while (varActual != null)
                {
                    atrItems[i] = varActual.pasarItem;
                    varActual = varActual.GetAtrSiguiente;
                    i++;
                }
                atrLongitud++;
            }
            return true;
        }
        protected override bool insertarUltimo(Tipo prmItem)
        {
            bool varComprobante = true;
            int i = 0;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            Tipo[] varVectorClonado;
            if (atrItems == null)
            {
                atrItems = new Tipo[atrLongitud + 1];
            }
            else if (atrLongitud == atrItems.Length && atrItems.Length != int.MaxValue / 16)
            {
                varVectorClonado = new Tipo[atrLongitud + 1];
                Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                atrItems = varVectorClonado;
            }
            else if (atrItems.Length == int.MaxValue / 16)
            {
                varComprobante = false;
            }
            if (atrItems.Length < int.MaxValue / 16)
            {
                varActual.pasarItem = prmItem;
                if (atrPrimero == null)
                {
                    atrPrimero = varActual;
                    atrUltimo = atrPrimero;
                }
                else
                {
                    atrUltimo.GetAtrSiguiente = varActual;
                    varActual.GetAtrAnterior = atrUltimo;
                    atrUltimo = varActual;
                }
                varActual = atrPrimero;
                while (varActual != null)
                {
                    atrItems[i] = varActual.pasarItem;
                    varActual = varActual.GetAtrSiguiente;
                    i++;
                }
                atrLongitud++;
            }
            return varComprobante;
        }
        protected override bool insertarEnMedio(int prmIndice, Tipo prmItem)
        {
            bool varComprobante = true;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            Tipo[] varVectorClonado;
            if (prmIndice < 0)
            {
                varComprobante = false;
            }
            if (prmIndice <= atrLongitud)
            {
                if (prmIndice >= 0)
                {
                    if (atrItems == null)
                    {
                        atrItems = new Tipo[atrLongitud + 1];
                    }
                    else if (atrItems.Length == atrLongitud)
                    {
                        varVectorClonado = new Tipo[atrLongitud + 1];
                        Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                        atrItems = varVectorClonado;
                    }
                    if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                    {
                        varActual.pasarItem = prmItem;
                        if (prmIndice == 0)
                        {
                            if (atrPrimero == null)
                            {
                                atrPrimero = varActual;
                                atrUltimo = atrPrimero;
                            }
                            else
                            {
                                varActual.GetAtrSiguiente = atrPrimero;
                                varActual.GetAtrSiguiente.GetAtrAnterior = varActual;
                                atrPrimero = varActual;
                            }
                        }
                        else if (prmIndice == atrItems.Length - 1)
                        {
                            atrUltimo.GetAtrSiguiente = varActual;
                            varActual.GetAtrAnterior = atrUltimo;
                            atrUltimo = varActual;
                        }
                        else
                        {
                            varCopia = atrPrimero;
                            while (!varCopia.pasarItem.Equals(atrItems[prmIndice]))
                            {
                                varCopia = varCopia.GetAtrSiguiente;
                            }
                            varActual.GetAtrSiguiente = varCopia;
                            varCopia = atrPrimero;
                            while (!varCopia.pasarItem.Equals(atrItems[prmIndice - 1]))
                            {
                                if (varCopia.GetAtrSiguiente != null)
                                {
                                    varCopia = varCopia.GetAtrSiguiente;
                                }
                            }
                            varCopia.GetAtrSiguiente = varActual;
                            varActual.GetAtrAnterior = varCopia;
                            varActual.GetAtrSiguiente.GetAtrAnterior = varActual;
                            atrUltimo = varActual.GetAtrSiguiente;
                            atrUltimo.GetAtrAnterior = varActual;
                            atrPrimero.GetAtrSiguiente = varCopia;
                        }
                        varActual = atrPrimero;
                        for (int i = 0; i < atrItems.Length; i++)
                        {
                            atrItems[i] = varActual.pasarItem;
                            varActual = varActual.GetAtrSiguiente;
                        }
                        atrLongitud++;
                    }
                }
            }
            else
            {
                varComprobante = false;
            }
            return varComprobante;
        }
        #endregion
        #region Extracción
        protected override bool extraerPrimero(ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            int i = 0;
            if (atrItems == null)
            {
                prmItem = default(Tipo);
                return false;
            }
            else
            {
                atrLongitud--;
                atrItems = new Tipo[atrLongitud];
                #region Desapilar en Nodo
                if (atrPrimero != null)
                {
                    varActual = atrPrimero;
                    atrPrimero = varActual.GetAtrSiguiente;
                    atrPrimero.GetAtrAnterior = null;
                }
                else
                {
                    atrPrimero = null;
                    atrUltimo = atrPrimero;
                }
                #endregion
                #region Pasar datos del Nodo a Vector
                prmItem = varActual.pasarItem;
                varActual = atrPrimero;
                while (varActual != null)
                {
                    atrItems[i] = varActual.pasarItem;
                    varActual = varActual.GetAtrSiguiente;
                    i++;
                }
                #endregion
                return true;
            }
        }
        protected override bool extraerUltimo(ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            bool varComprobante = true;
            if (atrLongitud == 0)
            {
                varComprobante = false;
            }
            else if (varComprobante == true)
            {
                varActual = atrPrimero;
                varCopia = atrPrimero;
                while (varActual.GetAtrSiguiente != null)
                {
                    varCopia = varActual;
                    varActual = varActual.GetAtrSiguiente;
                }
                prmItem = varCopia.GetAtrSiguiente.pasarItem;
                varCopia.GetAtrSiguiente = null;
                atrUltimo = varCopia;
                atrPrimero.GetAtrSiguiente = varCopia;
                atrLongitud--;
                atrItems = new Tipo[atrLongitud];
                varActual = atrPrimero;
                for (int i = 0; i < atrItems.Length; i++)
                {
                    atrItems[i] = varActual.pasarItem;
                    varActual = varActual.GetAtrSiguiente;
                }
            }
            else
            {
                varComprobante = false;
            }
            return varComprobante;
        }
        protected override bool extraerEnMedio(int prmIndice, ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            bool prueba = false;
            bool varComprobante = true;
            if (prmIndice < 0 || atrLongitud == 0)
            {
                varComprobante = false;
            }
            else
            {
                if (prmIndice < atrLongitud)
                {
                    if (prmIndice >= 0)
                    {
                        if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                        {
                            varCopia = atrPrimero;
                            while (!varCopia.pasarItem.Equals(atrItems[prmIndice]))
                            {
                                varCopia = varCopia.GetAtrSiguiente;
                            }
                            varActual.GetAtrSiguiente = varCopia;
                            varCopia = atrPrimero;
                            while (!varCopia.pasarItem.Equals(atrItems[prmIndice - 1]) && prueba == false)
                            {
                                if (varCopia.GetAtrSiguiente != null)
                                {
                                    varCopia = varCopia.GetAtrSiguiente;
                                }
                            }
                            varCopia.GetAtrSiguiente = varActual;
                            atrPrimero.GetAtrSiguiente = varCopia;
                            varActual = atrPrimero;
                            for (int i = 0; i < atrItems.Length; i++)
                            {
                                atrItems[i] = varActual.pasarItem;
                                varActual = varActual.GetAtrSiguiente;
                            }
                        }
                    }
                }
                else
                {
                    varComprobante = false;
                }
            }
            return varComprobante;
        }
        #endregion
        #region Modificación
        public override bool reversar()
        {
            if (atrItems == null)
            {
                return false;
            }
            else
            {
                clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
                varCopia = atrPrimero;
                while (atrPrimero != null)
                {
                    atrPrimero = atrPrimero.GetAtrSiguiente;
                }
                atrUltimo = atrPrimero;
                while (varCopia != null)
                {
                    clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
                    varActual.pasarItem = varCopia.pasarItem;
                    if (atrPrimero == null)
                    {
                        atrPrimero = varActual;
                        atrUltimo = atrPrimero;
                    }
                    else
                    {
                        varActual.GetAtrSiguiente = atrPrimero;
                        atrPrimero = varActual;
                    }
                    varCopia = varCopia.GetAtrSiguiente;
                }
                varCopia = atrPrimero;
                for (int i = 0; i < atrItems.Length; i++)
                {
                    atrItems[i] = varCopia.pasarItem;
                    varCopia = varCopia.GetAtrSiguiente;
                }
                return true;
            }
        }
        #endregion
        #region Consulta
        public override bool contiene(Tipo prmItem)
        {
            bool varComprobante = true;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            if (atrItems == null)
            {
                varComprobante = false;
            }
            else
            {
                varActual.pasarItem = prmItem;
                varCopia = atrPrimero;
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (varCopia.pasarItem.Equals(varActual.pasarItem))
                    {
                        varComprobante = true;
                    }
                    else
                    {
                        varComprobante = false;
                    }
                    varCopia = varCopia.GetAtrSiguiente;
                }
            }
            return varComprobante;
        }
        public override int encontrar(Tipo prmItem)
        {
            int varEncontrar = 0;
            int varContador = 0;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            varActual.pasarItem = prmItem;
            varCopia = atrPrimero;
            if (atrItems != null)
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (varCopia.pasarItem.Equals(varActual.pasarItem))
                    {
                        varEncontrar = i + varContador;
                    }
                    else
                    {
                        varEncontrar = -1;
                    }
                    if (varCopia.GetAtrSiguiente != null)
                    {
                        if (varActual.pasarItem.Equals(varCopia.pasarItem))
                        {
                            varContador--;
                        }
                    }
                    varCopia = varCopia.GetAtrSiguiente;
                }
            }
            else
            {
                varEncontrar--;

            }
            return varEncontrar;
        }
        #endregion
        #endregion
        #region Patrón Iterador
        #region Operaciones
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrNodoActual;
        #endregion
        #region Mutadores
        public override void ponerItemActual(Tipo prmItem)
        {
            atrItemActual = prmItem;
            atrNodoActual.ponerItem(atrItemActual);
        }
        #endregion
        #region Posicionadores
        public override bool irPrimero()
        {
            if (!estaVacia())
            {
                atrNodoActual = atrPrimero;
                atrItemActual = atrNodoActual.pasarItem;
                atrIndiceActual = 0;
                return true;
            }
            atrNodoActual = null;
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        public override bool irUltimo()
        {
            if (!estaVacia())
            {
                atrNodoActual = atrUltimo;
                atrItemActual = atrNodoActual.pasarItem;
                atrIndiceActual = atrLongitud - 1;
                return true;
            }
            atrNodoActual = null;
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        protected override bool avanzarItem()
        {
            atrNodoActual = atrNodoActual.GetAtrSiguiente;
            atrItemActual = atrNodoActual.pasarItem;
            atrIndiceActual++;
            return true;
        }
        protected override bool retrocederItem()
        {
            atrNodoActual = atrNodoActual.GetAtrAnterior;
            atrItemActual = atrNodoActual.pasarItem;
            atrIndiceActual--;
            return true;
        }
        #endregion
        #endregion
        #endregion
        #endregion
        #endregion
    }
}
