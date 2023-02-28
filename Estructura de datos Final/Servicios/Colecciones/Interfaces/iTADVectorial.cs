using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTADVectorial<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Métodos
        #region Getters
        int darCapacidad();
        int darFactorCrecimiento();
        #endregion
        #region Setters
        bool ponerItems(Tipo[] prmVector);
        bool ponerCapacidad(int prmValor);
        bool ajustarFactorCrecimiento(int prmValor);
        bool ajustarFlexibilidad(bool prmValor);
        #endregion
        #region Query
        bool esFlexible();
        #endregion
        #endregion
    }
}
