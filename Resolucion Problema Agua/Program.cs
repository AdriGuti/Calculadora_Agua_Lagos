using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolucion_Problema_Agua
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dist = {1000,1000,10000,0,9};
            Console.WriteLine(AguaAtrapada(dist));
            int AguaAtrapada(int[] DistribucionBloques)
            {
                bool ProblemaSolucionado = false;
                bool[] PosicionesComprovadas = new bool[DistribucionBloques.Length];
                for (int i = 0; i < DistribucionBloques.Length; i++) PosicionesComprovadas[i] = false;
                int AguaTotal = 0;
                bool primerMax = true;
                while (!ProblemaSolucionado)
                {
                    int max = 0;
                    int posicionUltimoValorMaximo = -1;
                    for(int i = 0; i < DistribucionBloques.Length; i++)
                    {
                        if (max <= DistribucionBloques[i]&&!PosicionesComprovadas[i])
                        {
                            max = DistribucionBloques[i];
                            posicionUltimoValorMaximo = i;
                        }
                    }
                    if (primerMax)
                    {
                        PosicionesComprovadas[posicionUltimoValorMaximo] = true;
                        primerMax = false;
                    }
                    else
                    {
                        if (posicionUltimoValorMaximo != 0)
                        {
                            int i = posicionUltimoValorMaximo - 1;
                            bool esTrobatEsquerra = false;
                            while (!esTrobatEsquerra)
                            {
                                if (DistribucionBloques[i] >= DistribucionBloques[posicionUltimoValorMaximo])
                                {
                                    esTrobatEsquerra = true;
                                }
                                else if (i == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                            if (esTrobatEsquerra)
                            {
                                int BloquesEnZona = 0;
                                for (int j = i + 1; j < posicionUltimoValorMaximo; j++)
                                {
                                    BloquesEnZona += DistribucionBloques[j];
                                }
                                AguaTotal += (posicionUltimoValorMaximo - i - 1) * DistribucionBloques[posicionUltimoValorMaximo] - BloquesEnZona;
                                for (int l = i; l <= posicionUltimoValorMaximo; l++)
                                {
                                    PosicionesComprovadas[l] = true;
                                }
                            }
                        }
                        if (posicionUltimoValorMaximo != DistribucionBloques.Length-1)
                        {
                            int k = posicionUltimoValorMaximo + 1;
                            bool esTrobatDreta = false;
                            while (!esTrobatDreta)
                            {
                                if (DistribucionBloques[k] >= DistribucionBloques[posicionUltimoValorMaximo])
                                {
                                    esTrobatDreta = true;
                                }
                                else if (k == DistribucionBloques.Length - 1)
                                {
                                    break;
                                }
                                else
                                {
                                    k++;
                                }
                            }
                            if (esTrobatDreta)
                            {
                                int BloquesEnZona = 0;
                                for (int l = posicionUltimoValorMaximo + 1; l < k; l++)
                                {
                                    BloquesEnZona += DistribucionBloques[l];
                                }
                                AguaTotal += (k - posicionUltimoValorMaximo - 1) * DistribucionBloques[posicionUltimoValorMaximo] - BloquesEnZona;
                                for (int l = posicionUltimoValorMaximo; l <= k; l++)
                                {
                                    PosicionesComprovadas[l] = true;
                                }
                            }
                        }
                    }
                    bool NotSolucionat = false;
                    for(int i = 0; i < DistribucionBloques.Length && !NotSolucionat; i++)
                    {
                        if (!PosicionesComprovadas[i])
                        {
                            NotSolucionat = true;
                        }
                    }
                    if (!NotSolucionat)
                    {
                        ProblemaSolucionado = true;
                    }
                }
                return AguaTotal;
            }
        }
    }
}
