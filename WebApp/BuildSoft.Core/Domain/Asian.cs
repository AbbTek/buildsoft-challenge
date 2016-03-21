using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSoft.Core.Domain
{
    public class Asian : Person
    {
        public override float Height
        {
            get
            {
                return (1.7f + ((Age + 2) * 0.23f));
            }
        }
    }
}