using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainApp.Agents;
using static MainApp.SimulationConfiguration;

namespace MainApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            
            AgentsManager.Initialize(ref AgentsSandbox,
                ref updateAgentsTimer,
                WidthOfSpace,
                HeightOfSpace,
                CellSize,
                CountOfAgentsA,
                CountOfAgentsB);
        }
    }
}
