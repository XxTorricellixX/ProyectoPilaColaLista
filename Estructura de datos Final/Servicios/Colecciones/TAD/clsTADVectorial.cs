using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.TAD
{
    public class clsTADVectorial<Tipo> : clsTAD<Tipo>, iTADVectorial<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        protected Tipo[] atrItems;
        protected int atrCapacidad;
        protected bool atrFlexible;
        protected int atrFactorCrecimiento;
        #endregion
        #region Métodos
        #region Implementados
        public bool ajustarFlexibilidad(bool prmValor)
        {
            if (atrCapacidad == int.MaxValue / 16)
            {
                prmValor = false;
            }
            else
            {
                if (atrCapacidad > 0)
                {
                    prmValor = true;
                    atrFlexible = false;
                    atrFactorCrecimiento = 0;
                }
            }
            return prmValor;
        }
        public int darCapacidad()
        {
            return atrCapacidad;
        }
        public int darFactorCrecimiento()
        {
            return atrFactorCrecimiento;
        }
        public bool esFlexible()
        {
            return atrFlexible;
        }
        public bool ajustarFactorCrecimiento(int prmValor)
        {
            bool varComprobante = true;
            atrFactorCrecimiento = prmValor;
            if (atrCapacidad > 0 && atrCapacidad < int.MaxValue / 16)
            {
                atrFlexible = true;
                atrLongitud = 0;
            }
            else
            {
                if (prmValor == int.MaxValue / 16)
                {
                    atrLongitud = 0;
                    atrFactorCrecimiento = atrLongitud;
                    varComprobante = false;
                }
            }
            return varComprobante;
        }
        public bool ponerCapacidad(int prmValor)
        {
            throw new NotImplementedException();
        }
        public override Tipo[] darItems()
        {
            return atrItems;
        }
        #endregion
        #region Constructores
        protected override void constructorSinParametros()
        {
            atrItems = new Tipo[atrCapacidad];
            atrFlexible = true;
            atrFactorCrecimiento = 1000;
        }
        protected override void constructorConCapacidad(int prmCapacidad)
        {
            if (prmCapacidad < 0 || prmCapacidad == int.MaxValue || prmCapacidad >= int.MaxValue / 16 + 1)
            {
                prmCapacidad = 0;
                atrFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmCapacidad == int.MaxValue / 16)
                {
                    atrFlexible = false;
                    atrFactorCrecimiento = 0;
                }
                else
                {
                    atrFlexible = true;
                    atrFactorCrecimiento = 1000;
                }
            }
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        protected override void constructorCapacidadFlexible(int prmCapacidad, bool prmDinamica)
        {
            if (prmCapacidad < 0 && prmDinamica == false || prmCapacidad >= int.MaxValue / 16 + 1 || prmCapacidad < 0 || prmCapacidad == 0 && prmDinamica == false)
            {
                prmCapacidad = 0;
                atrFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmCapacidad > 0 && prmDinamica == false || prmDinamica == false)
                {
                    atrFlexible = false;
                    atrFactorCrecimiento = 0;
                }
                else
                {
                    atrFlexible = true;
                    atrFactorCrecimiento = 1000;
                }
            }
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        protected override void constructorCapacidadFactorCrecimiento(int prmCapacidad, int prmFactorCrecimiento)
        {
            if (prmCapacidad < 0 || prmFactorCrecimiento < 0 || prmCapacidad == 0 && prmFactorCrecimiento == 0 || prmFactorCrecimiento == int.MaxValue / 16 + 1 || prmCapacidad == int.MaxValue / 16 && prmFactorCrecimiento > 0 || prmCapacidad == int.MaxValue || prmCapacidad == int.MaxValue / 16 + 1 && prmFactorCrecimiento >= 0)
            {
                prmCapacidad = 0;
                atrFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmFactorCrecimiento > 0)
                {
                    atrFactorCrecimiento = prmFactorCrecimiento;
                    atrFlexible = true;
                }
                if (prmCapacidad == int.MaxValue / 16 && prmFactorCrecimiento == 0)
                {
                    atrFactorCrecimiento = 0;
                    atrFlexible = false;
                }
            }
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        #endregion
        #region CRUDs
        #region Inserción
        protected override bool insertarPrimero(Tipo prmItem)
        {
            bool varComprobante = true;
            Tipo[] varVectorClonado;
            if (atrItems.Length == 0)
            {
                atrCapacidad = atrFactorCrecimiento + atrLongitud;
                atrItems = new Tipo[atrCapacidad];
            }
            else
            {
                if (atrLongitud == atrItems.Length && atrItems.Length != int.MaxValue / 16)
                {
                    atrCapacidad = atrFactorCrecimiento + atrLongitud;
                    varVectorClonado = new Tipo[atrCapacidad];
                    Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                    atrItems = varVectorClonado;
                }
                if (atrItems.Length == int.MaxValue / 16)
                {
                    varComprobante = false;
                }
            }
            for (int i = atrItems.Length - 1; i > 0; i--)
            {
                atrItems[i] = atrItems[i - 1];
            }
            atrItems[0] = prmItem;
            if (atrLongitud != int.MaxValue / 16)
            {
                atrLongitud++;
            }
            return varComprobante;
        }
        protected override bool insertarUltimo(Tipo prmItem)
        {
            bool varComprobante = true;
            Tipo[] varVectorClonado;
            if (atrItems.Length == 0)
            {
                atrCapacidad = atrFactorCrecimiento + atrLongitud;
                atrItems = new Tipo[atrCapacidad];
            }
            else
            {
                if (atrLongitud == atrItems.Length && atrItems.Length != int.MaxValue / 16)
                {
                    atrCapacidad = atrFactorCrecimiento + atrLongitud;
                    varVectorClonado = new Tipo[atrCapacidad];
                    Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                    atrItems = varVectorClonado;
                }
                if (atrItems.Length == int.MaxValue / 16)
                {
                    varComprobante = false;
                }
            }
            if (atrItems.Length < int.MaxValue / 16)
            {
                for (int i = atrLongitud; i < atrLongitud + 1; i++)
                {
                    atrItems[i] = prmItem;
                }
            }
            if (atrLongitud != int.MaxValue / 16)
            {
                atrLongitud++;
            }
            return varComprobante;
        }
        protected override bool insertarEnMedio(int prmIndice, Tipo prmItem)
        {
            bool varComprobante = true;
            Tipo[] varVectorClonado;
            if (prmIndice < 0)
            {
                varComprobante = false;
            }
            else
            {
                if (prmIndice <= atrLongitud)
                {
                    if (prmIndice >= 0)
                    {
                        if (atrItems.Length == atrLongitud && atrFlexible == true)
                        {
                            atrCapacidad = atrFactorCrecimiento + atrLongitud;
                            varVectorClonado = new Tipo[atrCapacidad];
                            Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                            atrItems = varVectorClonado;
                        }
                        else
                        {
                            if (atrItems.Length == atrLongitud && atrFlexible == false || prmIndice > atrLongitud)
                            {
                                varComprobante = false;
                            }
                        }
                        if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                        {
                            for (int i = atrItems.Length - 1; i > prmIndice; i--)
                            {
                                atrItems[i] = atrItems[i - 1];
                            }
                            atrItems[prmIndice] = prmItem;
                            atrLongitud++;
                        }
                        else
                        {
                            if (prmIndice == atrLongitud)
                            {
                                varComprobante = false;
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
        #region Setters
        public override bool ponerItems(Tipo[] prmVector)
        {
            bool varComprobante = true;
            atrItems = prmVector;
            if (prmVector.Length == int.MaxValue / 16)
            {
                atrLongitud = atrItems.Length;
                atrCapacidad = atrItems.Length;
                atrFactorCrecimiento = 0;
                atrFlexible = false;
            }
            else
            {
                if (prmVector.Length == int.MaxValue / 16 + 1)
                {
                    varComprobante = false;
                    atrCapacidad = 0;
                    atrLongitud = 0;
                    atrItems = new Tipo[0];
                }
                atrLongitud = atrItems.Length;
                atrCapacidad = atrItems.Length;
            }
            return varComprobante;
        }
        #endregion
        #region Extracción
        protected override bool extraerPrimero(ref Tipo prmItem)
        {
            bool varComprobante = true;
            if (atrItems.Length == 0)
            {
                varComprobante = false;
                prmItem = default(Tipo);
            }
            else
            {
                prmItem = atrItems[0];
                for (int i = 0; i < atrItems.Length - 1; i++)
                {
                    atrItems[i] = atrItems[i + 1];
                }
                atrLongitud--;
            }
            return varComprobante;
        }
        protected override bool extraerUltimo(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected override bool extraerEnMedio(int prmIndice, ref Tipo prmItem)
        {
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
                            prmItem = atrItems[prmIndice];
                            for (int i = prmIndice; i < atrLongitud - 1; i++)
                            {
                                atrItems[i] = atrItems[i + 1];
                            }
                            atrLongitud--;
                        }
                        else
                        {
                            if (prmIndice == atrLongitud)
                            {
                                varComprobante = false;
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
            bool varComprobante = true;
            Tipo varValor;
            if (atrLongitud == 0)
            {
                varComprobante = false;
            }
            for (int i = 0; i < atrLongitud - 2; i++)
            {
                varValor = atrItems[i];
                atrItems[i] = atrItems[atrLongitud - 1 - i];
                atrItems[atrLongitud - 1 - i] = varValor;
            }
            return varComprobante;
        }
        #endregion
        #region Consultores
        public override bool contiene(Tipo prmItem)
        {
            bool varComprobante = true;
            if (atrItems.Length == 0)
            {
                varComprobante = false;
            }
            else
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (atrItems[i].Equals(prmItem))
                    {
                        varComprobante = true;
                    }
                    else
                    {
                        varComprobante = false;
                    }
                }
            }
            return varComprobante;
        }
        public override int encontrar(Tipo prmItem)
        {
            int varEncontrar = 0;
            int varContador = 0;
            for (int i = 0; i < atrLongitud; i++)
            {
                if (atrItems[i].Equals(prmItem))
                {
                    varEncontrar = i + varContador;
                }
                else
                {
                    varEncontrar = -1;
                }
                if (atrItems[i].Equals(atrItems[i + 1]))
                {
                    varContador--;
                }
            }
            if (atrItems.Length == 0 && prmItem.Equals(atrItems.Length))
            {
                varEncontrar = atrLongitud - 1;
            }
            return varEncontrar;
        }
        #endregion
        #endregion
        #region Patrón Iterador
        #region Operaciones
        #region Mutadores
        public override void ponerItemActual(Tipo prmItem)
        {
            atrItems[atrIndiceActual] = prmItem;
        }
        #endregion
        #region Posicionadores
        public override bool irPrimero()
        {
            if (!estaVacia())
            {
                atrIndiceActual = 0;
                atrItemActual = atrItems[atrIndiceActual];
                return true;
            }
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        public override bool irUltimo()
        {
            if (!estaVacia())
            {
                atrIndiceActual = atrLongitud - 1;
                atrItemActual = atrItems[atrIndiceActual];
                return true;
            }
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        protected override bool avanzarItem()
        {
            atrIndiceActual++;
            atrItemActual = atrItems[atrIndiceActual];
            return true;
        }
        protected override bool retrocederItem()
        {
            atrIndiceActual--;
            atrItemActual = atrItems[atrIndiceActual];
            return true;
        }
        public override bool irIndice(int prmIndice)
        {
            if (esValido(prmIndice))
            {
                atrIndiceActual = prmIndice;
                atrItemActual = atrItems[atrIndiceActual];
                return true;
            }
            return false;
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}
