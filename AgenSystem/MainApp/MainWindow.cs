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

            AgentsManager.Initialize(ref AgentsSandbox, 100, 100, 10, 50, 100);

            

        }

    }
}
