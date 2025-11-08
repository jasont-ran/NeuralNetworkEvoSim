using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Entities
{
    public abstract class Entity
    {
        public Brush Color { get; set; } = Brushes.White;
        public int Width { get; set; }
        public int Height { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; } 

    }

}
