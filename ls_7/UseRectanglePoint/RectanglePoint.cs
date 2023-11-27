using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ls_6;

namespace UseRectanglePoint
{
    internal class RectanglePoint
    {
		private Point topLeft = new Point();

		public Point TopLeft
        {
			get { return topLeft; }
			set { topLeft = value; }
		}

		private Point bottomRight = new Point();

		public Point BottomRight
        {
			get { return bottomRight; }
			set { bottomRight = value; }
		}
		public RectanglePoint() : this(new Point(0, 0), new Point(1, 1)) {}

		public RectanglePoint(Point topLeft, Point bottomRight) 
		{
			TopLeft = topLeft;
			this.BottomRight = bottomRight;
		}

		public RectanglePoint(RectanglePoint obj)
		{
			// это копия ссылок, неверно
			//TopLeft = obj.TopLeft;
			//BottomRight = obj.BottomRight;

			// Верно
			topLeft = new Point(obj.topLeft.X, obj.topLeft.Y);
			BottomRight = new Point(obj.bottomRight.X, obj.bottomRight.Y);
		}

        public override string ToString()
        {
            //return $"{topLeft}{bottomRight}";
			return $"TopLeft: {topLeft.X};{topLeft.X} BottomRight: {bottomRight.X};{bottomRight.Y}";
        }


    }
}
