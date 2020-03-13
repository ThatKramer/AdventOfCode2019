using System;
using System.Collections.Generic;
using System.Text;

namespace DayThree
{
    class Line
    {
        public Point start { get; set; }
        public Point end { get; set; }

        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
