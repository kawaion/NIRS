﻿using NIRS.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid
{
    class TimeSpaceGrid
    {
        private readonly int _n;
        private readonly int _k;

        private List<List<DynamicCharacteristicsFlowCell>> dynamicsGrid;
        private List<List<MixtureStateParametersCell>> mixtureStateGrid;

        public TimeSpaceGrid(int n, int k)
        {
            _n = n;            
            _k = k;
        }
        public ParametersCell this[double n, double k]
        {
            get
            {
                if (IsDynamicCell(n,k)) return dynamicsGrid[(int)(n - 0.5)][(int)k];
                if (IsMixtureStateCell(n,k)) return mixtureStateGrid[(int)n][(int)(k - 0.5)];
                throw new Exception($"неизвестная ячейка {n} {k}");
            }
            set
            {
                if (IsDynamicCell(n, k))
                    if (value is DynamicCharacteristicsFlowCell dynamicCell)
                    {
                        dynamicsGrid [(int)(n - 0.5)] [(int)k] = dynamicCell;
                        return;
                    }
                    else throw new Exception($"задается ячейка не динамических параметров {n} {k}"); 


                if (IsMixtureStateCell(n, k)) 
                    if (value is MixtureStateParametersCell MixtureStateCell)
                    {      
                        mixtureStateGrid [(int)n] [(int)(k-0.5)] = MixtureStateCell;
                        return;
                    }
                    else throw new Exception($"задается ячейка не состояния смеси {n} {k}");

                throw new Exception($"неизвестная ячейка {n} {k}");
            }

        }
        private bool IsDynamicCell(double n, double k) => n - (int)n == 0.5 && k - (int)k == 0;
        private bool IsMixtureStateCell(double n, double k) => n - (int)n == 0 && k - (int)k == 0.5;
    }
}