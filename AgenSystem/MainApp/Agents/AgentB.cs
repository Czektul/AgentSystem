using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp.Agents
{
    public class AgentB : AgentBase
    {
        public AgentB(Control parent, Position initPosition) : base(parent, initPosition)
        {

        }

        protected override void ProcessMovement()
        {
            throw new NotImplementedException();
        }
    }
}
