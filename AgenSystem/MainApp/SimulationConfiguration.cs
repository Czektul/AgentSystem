using System.Drawing;

namespace MainApp
{
    public static class SimulationConfiguration
    {
        public const int RandomSeed = 0;

        public const int WidthOfSpace = 100;
        public const int HeightOfSpace = 100;

        public const int CellSize = 10;

        /// <summary>
        /// In miliseconds
        /// </summary>
        public const int StepCalculatingInterval = 10;

        public const int CountOfAgentsA = 100;
        public const int CountOfAgentsB = 5;

        public static readonly Color AgentAColor = Color.Green;
        public static readonly Color AgentBColor = Color.Red;
        public static readonly Color BackgroundColor = SystemColors.ActiveCaption;
        public static readonly Color FontColor = Color.Wheat;
        
    }
}
