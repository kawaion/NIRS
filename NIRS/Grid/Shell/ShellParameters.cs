using NIRS.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid.Shell
{
    class ShellParameters
    {
        List<ShellParametersCell> shellParametersCells;
        public ShellParametersCell this[double n]
        {
            get
            {
                return shellParametersCells[(int)(n * 2)];
            }
            set
            {
                while (shellParametersCells.Count < (int)(n * 2))
                    shellParametersCells.Add(null);
                shellParametersCells[(int)(n * 2)] = value;
            }
        }
    }
}
