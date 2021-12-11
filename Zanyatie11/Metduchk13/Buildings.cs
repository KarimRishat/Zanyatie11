using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metduchk13
{
    class Buildings
    {
        private Building[] buildings;
        public Buildings()
        {
            buildings = new Building[10];
        }
        public Building this[int index]
        {
            get
            {
                return buildings[index];
            }
            set
            {
                buildings[index] = value;
            }
        }
    }
}
