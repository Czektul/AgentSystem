using MainApp.Agents;

namespace MainApp.Helpers
{
    public struct Position
    {

        public int WorldX => X * AgentsManager.CellSize;
        public int WorldY => Y * AgentsManager.CellSize;

        public int X { get; set; }
        public int Y { get; set; }
    }
}
