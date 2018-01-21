using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp.Agents
{
    public class AgentA : AgentBase
    {
        public AgentA(Control parent, Position initPosition) : base(parent, initPosition)
        {

        }

        protected override void ProcessMovement()
        {
            throw new NotImplementedException();
        }
    }
}
