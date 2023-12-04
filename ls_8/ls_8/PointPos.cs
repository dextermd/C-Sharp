using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ls_8
{
    internal class PointPos
    {
		private int x;
        private int y;

        public int X
		{
			get { return x; }
			set 
			{
                x = value;
                if (value < 0)
                    throw new PointExc("X", X, Y);
			}
		}

		public int Y
		{
			get 
			{ 
				return y;
			}
			set 
			{
                y = value;
                if (value < 0)
					throw new PointExc("Y", X, Y);
			}
		}

		public PointPos() : this(1, 1) { }
		public PointPos(int x, int y)
		{
			//X = x;
			//Y = y;

			if (x > 0 && y > 0)
			{
				this.x = x;
				this.y = y;
			}else throw new PointExc("value", x , y);
		}


	}
}
