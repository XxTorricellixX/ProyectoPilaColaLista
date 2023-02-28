using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.TAD;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : clsTADVectorial<Tipo>, iPila<Tipo>, iTAD<Tipo> where Tipo : IComparable<Tipo> // El : quiere decir que implementará los métodos públicos de la interfaz iPila.
    {
        #region Atributos
        #endregion
        #region Métodos
        #region Accesores
        #endregion
        #region Mutadores
        #endregion
        #region Constructores
        public clsPilaVector()
        {
            constructorSinParametros();
        }
        public clsPilaVector(int prmCapacidad)
        {
            constructorConCapacidad(prmCapacidad);
        }
        public clsPilaVector(int prmCapacidad, bool prmDinamica)
        {
            constructorCapacidadFlexible(prmCapacidad, prmDinamica);
        }
        public clsPilaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            constructorCapacidadFactorCrecimiento(prmCapacidad, prmFactorCrecimiento);
        }
        #endregion
        #region CRUDs
        public bool apilar(Tipo prmItem)
        {
            return insertarPrimero(prmItem);
        }
        public bool desapilar(ref Tipo prmItem)
        {
            return extraerPrimero(ref prmItem);
        }
        public bool revisar(ref Tipo prmItem)
        {
            return recuperarPrimero(ref prmItem);
        }
        #endregion
        #region Ordenamientos
        public void OrdenarBurbujaSimple(bool prmValor)
        {
            Tipo varAux;
            if (prmValor == false) //Ordenar en forma ascendente
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    for (int j = 0; j < atrLongitud; j++)
                    {
                        if (atrItems[i].CompareTo(atrItems[j])<0)
                        {
                            varAux = atrItems[i];
                            atrItems[i] = atrItems[j];
                            atrItems[j] = varAux;
                        }
                    }
                }
            }
            else  //Ordenar en forma descendente
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    for (int j = 0; j < atrLongitud; j++)
                    {
                        if (atrItems[i].CompareTo(atrItems[j]) > 0)
                        {
                            varAux = atrItems[i];
                            atrItems[i] = atrItems[j];
                            atrItems[j] = varAux;
                        }
                    }
                }
            }
        }
        public void OrdenarBurbujaMejorado(bool prmValor)
        {
            Tipo varAux;
            bool bandera = true;
            int cont1 = 0;
            int cont2 = 0;
            if (prmValor == false) //Ordenar en forma ascendente
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (bandera == false)
                    {
                        break;
                    }
                    bandera = false;
                    for (int j = 0; j < atrLongitud; j++)
                    {
                        if (!(j + 1).Equals(atrLongitud))
                        {

                            if (!atrItems[j + 1].Equals(0))
                                {
                                if (atrItems[j].CompareTo(atrItems[j + 1]) > 0)
                            {
                                bandera= true;  
                                varAux = atrItems[j];
                                atrItems[j] = atrItems[j + 1];
                                atrItems[j + 1] = varAux;
                                cont1++;
                            }
                        }
                        } 
                    }
                    cont2++;
                }
            }
            else  //Ordenar en forma descendente
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (bandera == false) {
                        break;
                    }
                    bandera = false; 
                    for (int j = 0; j < atrLongitud; j++)
                    {
                        if (!(j + 1).Equals(atrLongitud)) {

                            if (!atrItems[j+1].Equals(0))
                            {
                            if (atrItems[j].CompareTo(atrItems[j + 1]) < 0)
                            {
                                bandera = true; 
                                varAux = atrItems[j];
                                atrItems[j] = atrItems[j + 1];
                                atrItems[j + 1] = varAux;
                                cont1++;
                            }
                            }
                        } 
                    }
                }
                cont2++;
            }
        }
        public void OrdenarBurbujaBiDireccional(bool prmValor)
        {
            int izquierda = 0;
            int derecha = atrLongitud;
            Tipo varAux;
            int Ultimo = atrLongitud;
            bool bandera = true;

            if (prmValor == false) //Ordenar en forma ascendente
            {
                do
                {
                    for (int i = izquierda; i < derecha; i++)
                    {
                        //if (bandera == false)
                        //{
                        //    break;
                        //}
                        //bandera = false;

                        if (!(i + 1).Equals(atrLongitud))
                        {
                            if (!atrItems[i + 1].Equals(0))
                            {
                                if (atrItems[i].CompareTo(atrItems[i + 1]) > 0)
                                {
                                    varAux = atrItems[i];
                                    atrItems[i] = atrItems[i + 1];
                                    atrItems[i + 1] = varAux;
                                    Ultimo = i;
                                }
                            }
                        }
                    }
                    derecha = Ultimo;

                    for (int j = derecha; j > izquierda; j--)
                    {
                        if (!(j).Equals(atrLongitud)) { 
                            if (!atrItems[j].Equals(0))
                        {
                            if (atrItems[j - 1].CompareTo(atrItems[j]) > 0)
                        {
                            varAux = atrItems[j];
                            atrItems[j] = atrItems[j - 1];
                            atrItems[j - 1] = varAux;
                            Ultimo = j;
                        }
                    }
                    }
                    }
                    izquierda = Ultimo;

                } while (izquierda < derecha);
            }
            else  //Ordenar en forma descendente
            {
                do
                {
                    for (int i = izquierda; i < derecha; i++)
                    {
                        if (!(i + 1).Equals(atrLongitud))
                        {
                            if (!atrItems[i + 1].Equals(0))
                            {
                                if (atrItems[i].CompareTo(atrItems[i + 1]) < 0)
                                {
                                    varAux = atrItems[i];
                                    atrItems[i] = atrItems[i + 1];
                                    atrItems[i + 1] = varAux;
                                    Ultimo = i;
                                }
                            }
                        }
                    }
                    derecha = Ultimo;

                    for (int j = derecha; j > izquierda; j--)
                    {
                        if (!(j).Equals(atrLongitud))
                        {
                            if (atrItems[j - 1].CompareTo(atrItems[j]) < 0)
                        {
                            varAux = atrItems[j];
                            atrItems[j] = atrItems[j - 1];
                            atrItems[j - 1] = varAux;
                            Ultimo = j;
                        }
                    }
                    }
                    izquierda = Ultimo;
                } while (izquierda < derecha);

            }

        }
        public void OrdenarInsercion(bool prmValor)
        {
            int posicion;
            Tipo varAux;
            if (prmValor == false) //Ordenar en forma ascendente
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    posicion = i;
                    varAux = atrItems[i];

                    while ((posicion > 0) && (atrItems[posicion - 1].CompareTo(varAux) > 0))
                    {

                        atrItems[posicion] = atrItems[posicion - 1];
                        posicion--;
                    }
                    atrItems[posicion] = varAux;
                }
            }
            else
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    posicion = i;
                    varAux = atrItems[i];

                    while ((posicion > 0) && (atrItems[posicion - 1].CompareTo(varAux) < 0))
                    {

                        atrItems[posicion] = atrItems[posicion - 1];
                        posicion--;
                    }
                    atrItems[posicion] = varAux;
                }
            }

        }
        public void OrdenarSeleccion(bool prmValor)
        {
            int minimo;
            Tipo varAux;
            if (prmValor == false) //Ordenar en forma ascendente
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    minimo = i;
                    for (int j = i + 1; j < atrLongitud; j++)
                    {
                        if (atrItems[j].CompareTo(atrItems[minimo]) < 0)
                        {
                            minimo = j;
                        }
                    }
                    varAux=atrItems[i];
                    atrItems[i] = atrItems[minimo]; 
                    atrItems[minimo]=varAux;
                }
            }
            else
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    minimo = i;
                    for (int j = i + 1; j < atrLongitud; j++)
                    {
                        if (atrItems[j].CompareTo(atrItems[minimo]) > 0)
                        {
                            minimo = j;
                        }
                    }
                    varAux = atrItems[i];
                    atrItems[i] = atrItems[minimo];
                    atrItems[minimo] = varAux;
                }
            }
        }
        public void OrdenarQuickSort(bool prmValor)
        {
            if (prmValor == false) //Ordenar en forma ascendente
            {
                Particionar(atrItems,0,atrLongitud-1);
                //int izquierda = 0;
                //int derecha = atrLongitud-1;
                //bool repetir=false;

                //do
                //{
                //    Tipo Puntero = atrItems[izquierda];
                //    int i = izquierda;
                //    int j = derecha;
                //    Tipo varAux;


                //    while (i < j)
                //    {
                //        while (atrItems[i].CompareTo(Puntero) <= 0 && i < j)
                //        {
                //            i++;
                //        }
                //        while (atrItems[j].CompareTo(Puntero) > 0)
                //        {
                //            j--;
                //        }
                //        if (i < j)
                //        {
                //            varAux = atrItems[i];
                //            atrItems[i] = atrItems[j];
                //            atrItems[j] = varAux;
                //        }

                //    }
                //    atrItems[izquierda] = atrItems[j];
                //    atrItems[j] = Puntero;

                //    repetir = false;


                //    if (izquierda < j - 1)
                //    {
                //        derecha = j - 1;
                //        repetir = true; 
                //    }
                //    if (j + 1 < derecha)
                //    {
                //        izquierda = j + 1;
                //        repetir=true;
                //    }
                //} while (repetir);

            }
            else
            {
                int izquierda = 0;
                int derecha = atrLongitud - 1;
                bool repetir = false;

                do
                {
                    Tipo Puntero = atrItems[izquierda];
                    int i = izquierda;
                    int j = derecha;
                    Tipo varAux;


                    while (i < j)
                    {
                        while (atrItems[i].CompareTo(Puntero) >= 0 && i < j)
                        {
                            i++;
                        }
                        while (atrItems[j].CompareTo(Puntero) < 0)
                        {
                            j--;
                        }
                        if (i < j)
                        {
                            varAux = atrItems[i];
                            atrItems[i] = atrItems[j];
                            atrItems[j] = varAux;
                        }

                    }
                    atrItems[izquierda] = atrItems[j];
                    atrItems[j] = Puntero;
                    repetir = false;

                    if (izquierda < j - 1)
                    {
                        derecha = j - 1;
                        repetir = true;
                    }
                    if (j + 1 < derecha)
                    {
                        izquierda = j + 1;
                        repetir = true;
                    }
                } while (repetir);
            }



        }
        static void Particionar(Tipo[] lista, int izquierda, int derecha)
        {
            Tipo Puntero = lista[izquierda];
            int i = izquierda;
            int j = derecha;
            Tipo varAux;

            while (i < j)
            {
                while (lista[i].CompareTo(Puntero) <= 0 && i < j)
                {
                    i++;
                }
                while (lista[i].CompareTo(Puntero) > 0)
                {
                    j--;
                }
                if (i < j)
                {
                    varAux = lista[i];
                    lista[i] = lista[j];
                    lista[j] = varAux;
                }

            }
            lista[izquierda] = lista[j];
            lista[j] = Puntero;

            if (izquierda < j - 1)
            {
                Particionar(lista,izquierda, j - 1);
            }
            if (j + 1 < derecha)
            {
                Particionar(lista,j + 1, derecha);
            }

        }
        #endregion
        #endregion
    }
}