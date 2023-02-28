using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.TAD
{
    public class clsTADEnlazado<Tipo> : clsTAD<Tipo>, iTADEnlazada<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        protected clsNodoEnlazado<Tipo> atrPrimero;
        protected clsNodoEnlazado<Tipo> atrUltimo;
        protected Tipo[] atrItems;
        #endregion
        #region Métodos
        #region Implementados
        public clsNodoEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }
        public clsNodoEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
        #endregion
        #region Operaciones
        #region Accesores
        public override Tipo[] darItems()
        {
            return atrItems;
        }
        #endregion
        #region Mutadores
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
            else if (prmVector.Length >= int.MaxValue / 16 + 1)
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
                    clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
                    varActual.pasarItem = atrItems[i];
                    if (atrPrimero == null)
                    {
                        atrPrimero = varActual;
                        atrUltimo = atrPrimero;
                    }
                    else
                    {
                        atrUltimo.GetAtrSiguiente = varActual;
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
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            Tipo[] varVectorClonado;
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
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            int i = 0;
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
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            clsNodoEnlazado<Tipo> varCopia = new clsNodoEnlazado<Tipo>();
            bool prueba = false;
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
                    else if (prmIndice > atrLongitud)
                    {
                        varComprobante = false;
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
                                atrPrimero = varActual;
                            }
                        }
                        else if (prmIndice == atrItems.Length - 1)
                        {
                            atrUltimo.GetAtrSiguiente = varActual;
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
                            while (!varCopia.pasarItem.Equals(atrItems[prmIndice - 1]) && prueba == false)
                            {
                                if (varCopia.GetAtrSiguiente != null)
                                {
                                    varCopia = varCopia.GetAtrSiguiente;
                                }
                                else
                                {
                                    prueba = true;
                                }
                            }
                            varCopia.GetAtrSiguiente = varActual;
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
            int i = 0;
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
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
                    atrUltimo = atrPrimero.GetAtrSiguiente;
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
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            clsNodoEnlazado<Tipo> varCopia = new clsNodoEnlazado<Tipo>();
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
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            clsNodoEnlazado<Tipo> varCopia = new clsNodoEnlazado<Tipo>();
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
                            //if (prmIndice == 0)
                            //{
                            //    prmItem = atrPrimero.pasarItem;
                            //    atrPrimero = atrPrimero.GetAtrSiguiente;
                            //    atrLongitud--;
                            //    atrItems = new Tipo[atrLongitud];
                            //}
                            //else if (prmIndice == atrItems.Length - 1)
                            //{
                            //    varActual = atrPrimero;
                            //    varCopia = atrPrimero;
                            //    while (varActual.GetAtrSiguiente != null)
                            //    {
                            //        varCopia = varActual;
                            //        varActual = varActual.GetAtrSiguiente;
                            //    }
                            //    prmItem = varCopia.GetAtrSiguiente.pasarItem;
                            //    varCopia.GetAtrSiguiente = null;
                            //    atrUltimo = varCopia;
                            //    atrPrimero.GetAtrSiguiente = varCopia;
                            //    atrLongitud--;
                            //    atrItems = new Tipo[atrLongitud];
                            //}
                            //else
                            //{
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

                            //}
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
                clsNodoEnlazado<Tipo> varCopia = new clsNodoEnlazado<Tipo>();
                varCopia = atrPrimero;
                while (atrPrimero != null)
                {
                    atrPrimero = atrPrimero.GetAtrSiguiente;
                }
                atrUltimo = atrPrimero;
                while (varCopia != null)
                {
                    clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
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
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            clsNodoEnlazado<Tipo> varCopia = new clsNodoEnlazado<Tipo>();
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
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            clsNodoEnlazado<Tipo> varCopia = new clsNodoEnlazado<Tipo>();
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
        #region Atributos
        private clsNodoEnlazado<Tipo> atrNodoActual;
        #endregion
        #region Operaciones
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
        #endregion
        #endregion
        #endregion
        #endregion
        #endregion
    }
}
