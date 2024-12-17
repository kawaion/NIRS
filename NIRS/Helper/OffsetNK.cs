using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Helper
{
    static class OffsetNK
    {
        public static (double n, double k) Offset(this OffsetNode node, double newN, double newK)
        {
            return (2 * node.N - newN, 2 * node.K - newK);
        }
        public static OffsetNode Appoint(double n, double k)
        {
            return new OffsetNode(n, k);
        }
    }
    class OffsetNode
    {
        public double N { get; }
        public double K { get; }
        public OffsetNode(double n, double k)
        {
            N = n;
            K = k;
        }
    }
}
