using NIRS.Grid.Cell;
using NIRS.Grid.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid
{
    class SpaceGrid
    {
        private double _n;
        private GridType gridType;
        private List<DynamicCharacteristicsFlowCell> coordinateDynamics;
        private List<MixtureStateParametersCell> coordinateMixtureState;

        public SpaceGrid(double n)
        {
            _n = n;
            gridType = n.SetGridType();
            sn = new ShellParametersCell(gridType);
        }

        public ParametersCell this[double k]
        {
            get
            {
                switch (gridType)
                {
                    case GridType.dynamic:
                        {
                            if (IsInt(k)) return coordinateDynamics[(int)k];
                            else throw new Exception($"значение k не целое и равно {k}");
                        }
                        
                    case GridType.mixtureState:
                        {
                            if (IsHalfInt(k)) return coordinateMixtureState[(int)(k - 0.5)];
                            else throw new Exception($"значение k не половина целого и равно {k}");
                        }
                }
                throw new Exception($"неизвестная ячейка {_n} {k}");
            }
            set
            {
                switch (gridType)
                {
                    case GridType.dynamic:
                        {
                            if (IsInt(k)) coordinateDynamics[(int)k] = (DynamicCharacteristicsFlowCell)value;
                            else throw new Exception($"значение k не целое и равно {k}");
                            break;
                        }

                    case GridType.mixtureState:
                        {
                            if (IsHalfInt(k)) coordinateMixtureState[(int)(k - 0.5)] = (MixtureStateParametersCell)value;
                            else throw new Exception($"значение k не половина целого и равно {k}");
                            break;
                        }
                }
                throw new Exception($"неизвестная ячейка {_n} {k}");
            }
        }


        public ShellParametersCell sn { get; set; }
        private bool IsInt(double x)=> x - (int)x == 0;
        private bool IsHalfInt(double x) => x - (int)x == 0.5;
    }
        

}

