using NIRS.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid
{
    class SpaceTimeGrid
    {
        private readonly int _k;
        private readonly int _n;
        private List<List<DynamicCharacteristicsFlowCell>> dynamicsGrid;
        private List<List<MixtureStateParametersCell>> mixtureStateGrid;

        public SpaceTimeGrid(int k, int n)
        {
            _k = k;
            _n = n;
        }
        public ParametersCell this[double i, double j]
        {
            get
            {
                if (IsDynamicCell(i,j)) return dynamicsGrid[(int)i][(int)(j - 0.5)];
                if (IsMixtureStateCell(i,j)) return mixtureStateGrid[(int)(i - 0.5)][(int)j];
                throw new Exception("неизвестная ячейка");
            }
            set
            {
                if (IsDynamicCell(i, j))
                    if (value is DynamicCharacteristicsFlowCell dynamicCell)
                    {
                        dynamicsGrid[(int)i][(int)(j - 0.5)] = dynamicCell;
                        return;
                    }
                    else throw new Exception("задается ячейка не динамических параметров"); 


                if (IsMixtureStateCell(i, j)) 
                    if (value is MixtureStateParametersCell MixtureStateCell)
                    {      
                        mixtureStateGrid[(int)(i - 0.5)][(int)j] = MixtureStateCell;
                        return;
                    }
                    else throw new Exception("задается ячейка не состояния смеси");

                throw new Exception("неизвестная ячейка");
            }

        }
        private bool IsDynamicCell(double i, double j) => i - (int)i == 0 && j - (int)j == 0.5;
        private bool IsMixtureStateCell(double i, double j) => i - (int)i == 0.5 && j - (int)j == 0;
    }
}
