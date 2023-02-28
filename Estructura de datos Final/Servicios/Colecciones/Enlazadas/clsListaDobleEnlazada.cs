using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.TAD;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>, iLista<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        #endregion
        #region Accesores
        #endregion
        #endregion
        #region Accesores
        #endregion
        #region Mutadores
        #endregion
        #region Constructores
        #endregion
        #region CRUDs
        public bool agregar(Tipo prmItem)
        {
            return insertarUltimo(prmItem);
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        {
            return insertarEn(prmIndice, prmItem);
        }
        public bool extraer(int prmIndice, ref Tipo prmItem)
        {
            return extraerEn(prmIndice, ref prmItem);
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
    }
}
