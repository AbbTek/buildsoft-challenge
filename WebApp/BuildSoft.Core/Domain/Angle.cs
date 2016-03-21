using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSoft.Core.Domain
{
    public class Angle : Person
    {
        public override float Height
        {
            get
            {
                return (1.5f + (Age * 0.45f));
            }
        }
    }
}
