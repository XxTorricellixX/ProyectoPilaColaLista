using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.TAD;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsListaVector<Tipo> : clsTADVectorial<Tipo>, iLista<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #endregion
        #region Métodos
        #region Accesores
        #endregion
        #region Mutadores
        #endregion
        #region Constructores
        public clsListaVector()
        {
            constructorSinParametros();
        }
        public clsListaVector(int prmCapacidad)
        {
            constructorConCapacidad(prmCapacidad);
        }
        public clsListaVector(int prmCapacidad, bool prmDinamica)
        {
            constructorCapacidadFlexible(prmCapacidad, prmDinamica);
        }
        public clsListaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            constructorCapacidadFactorCrecimiento(prmCapacidad, prmFactorCrecimiento);
        }
        #endregion
        #region CRUDs
        public bool agregar(Tipo prmItem)
        {
            return insertarUltimo(prmItem);
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        {
            return insertarEnMedio(prmIndice, prmItem);
        }
        public bool extraer(int prmIndice, ref Tipo prmItem)
        {
            return extraerEnMedio(prmIndice, ref prmItem);
        }
        public bool modificar(int prmIndice, Tipo prmItem)
        {
            return modificarEn(prmIndice, prmItem);
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            return recuperarEn(prmIndice, ref prmItem);
        }
        #endregion
        #endregion
    }
}
