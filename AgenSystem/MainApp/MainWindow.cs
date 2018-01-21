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

namespace MainApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {

            InitializeComponent();

            AgentsManager.Initialize(ref AgentsSandbox, 75, 50, 20, 50, 100);

            updateAgentsTimer.Tick += (sender, args) => AgentsManager.UpdateAllAgents();
            updateAgentsTimer.Start();


        }

    }
}
