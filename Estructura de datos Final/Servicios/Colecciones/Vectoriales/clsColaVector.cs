using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.TAD;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsColaVector<Tipo>: clsTADVectorial<Tipo>, iCola<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #endregion
        #region Métodos
        #region Accesores
        #endregion
        #region Mutadores
        #endregion
        #region Constructores
        public clsColaVector()
        {
            constructorSinParametros();
        }
        public clsColaVector(int prmCapacidad)
        {
            constructorConCapacidad(prmCapacidad);
        }
        public clsColaVector(int prmCapacidad, bool prmDinamica)
        {
            constructorCapacidadFlexible(prmCapacidad, prmDinamica);
        }
        public clsColaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            constructorCapacidadFactorCrecimiento(prmCapacidad, prmFactorCrecimiento);
        }
        #endregion
        #region CRUDs
        public bool encolar(Tipo prmItem)
        {           
            return insertarUltimo(prmItem);
        }
        public bool desencolar(ref Tipo prmItem)
        {
            return extraerPrimero(ref prmItem);
        }
        public bool revisar(ref Tipo prmItem)
        {
            return recuperarPrimero(ref prmItem);
        }
        #endregion
        #endregion
    }
}