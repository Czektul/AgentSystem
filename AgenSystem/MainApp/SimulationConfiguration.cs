using System.Drawing;

namespace MainApp
{
    public static class SimulationConfiguration
    {
        public const int WidthOfSpace = 150;
        public const int HeightOfSpace = 100;

        public const int CellSize = 10;

        /// <summary>
        /// In miliseconds
        /// </summary>
        public const int StepCalculatingInterval = 25;

        public const int CountOfAgentsA = 50;
        public const int CountOfAgentsB = 100;

        public static readonly Color AgentAColor = Color.Red;
        public static readonly Color AgentBColor = Color.Green;
        public static readonly Color BackgroundColor = Color.Black;
        public static readonly Color FontColor = Color.Wheat;
    }
}
