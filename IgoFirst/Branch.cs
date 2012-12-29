using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgoFirst
{
    public class Branch
    {
        List<Node> _Nodes = new List<Node>();
        public List<Node> Nodes
        {
            get
            {
                return _Nodes;
            }
        }
        public Branch(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            _Nodes.Add(node);
        }
    }
}
