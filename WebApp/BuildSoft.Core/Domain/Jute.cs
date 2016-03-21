using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSoft.Core.Domain
{
    public class Jute : Person
    {
        public override float Height
        {
            get
            {
                return ((Age * 1.6f) / 2);
            }
        }
    }
}
