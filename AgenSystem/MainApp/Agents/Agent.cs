using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainApp.Helpers;
using static MainApp.Helpers.Enums;

namespace MainApp.Agents
{
    public abstract class Agent : Panel
    {
        public readonly SlotState Type;

        protected Position Position;

        protected Agent(Control parent, Position initPosition, SlotState type)
        {
            Parent = parent;
            Position = initPosition;
            Type = type;
            AgentsManager.Slot(Position) = this;
            SetLayout();
            UpdateAgent();

            Console.WriteLine($"Created Agent on : {Position.X},{Position.Y}");
        }

        private void SetLayout()
        {
            var label = new Label {Parent = this, Anchor = AnchorStyles.Left};
            Anchor = AnchorStyles.Left;
            Size = new Size(AgentsManager.CellSize, AgentsManager.CellSize);
            switch (Type)
            {
                case SlotState.AgentA:
                    BackColor = AgentsManager.AgentAColor;
                    label.Text = "A";
                    break;
                case SlotState.AgentB:
                    BackColor = AgentsManager.AgentBColor;
                    label.Text = "B";
                    break;
            }
        }

        public bool MoveAgent(int deltaX, int deltaY)
        {
            if (AgentsManager.GetSlotState(Position) != SlotState.Empty) return false;
            AgentsManager.Slot(Position) = null;
            Position.X += deltaX;
            Position.Y += deltaY;
            AgentsManager.Slot(Position) = this;
            return true;
        }

        public virtual void UpdateAgent()
        {
            ProcessMovement();
            Location = new System.Drawing.Point(Position.WorldX, Position.WorldY);
            Update();
            Parent.Update();
        }

        protected abstract void ProcessMovement();
    }
}
