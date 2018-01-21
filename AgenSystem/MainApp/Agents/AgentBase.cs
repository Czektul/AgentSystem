using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp.Agents
{
    public abstract class AgentBase : Panel
    {
        private Position _position;
        
        public AgentBase(Control parent, Position initPosition)
        {
            this.Parent = parent;
            _position = initPosition;
        }

        public void MoveAgent(int x, int y)
        {
            
            _position.PositionX += x;
            _position.PositionY += y;


        }

        public virtual void UpdateAgent()
        {
            ProcessMovement();
            this.Location = new System.Drawing.Point(_position.WorldX, _position.WorldY);
            Update();
        }

        protected abstract void ProcessMovement();

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
