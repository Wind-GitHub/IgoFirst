using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgoFirst
{
    public class Node
    {
        List<Branch> _BranchList;
        public List<Branch> BranchList
        {
            get
            {
                if (_BranchList == null)
                {
                    _BranchList = new List<Branch>();
                }
                return _BranchList;
            }
        }
    }
}
