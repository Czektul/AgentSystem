using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Agents
{
    public struct Position
    {
        public int WorldX { get => PositionX * AgentManager.PositionSize;}
        public int WorldY { get => PositionY * AgentManager.PositionSize;}

        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
