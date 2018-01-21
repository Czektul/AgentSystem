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

        private Label letterLabel;

        protected Agent(Control parent, Position initPosition, SlotState type)
        {
            Parent = parent;
            Position = initPosition;
            Type = type;
            AgentsManager.Slot(Position) = this;
            SetLayout();
            ReDraw();
            Console.WriteLine($"Created Agent on : {Position.X},{Position.Y}");
        }

        private void SetLayout()
        {
            letterLabel = new Label
            {
                Parent = this,
                Anchor = AnchorStyles.Left,
                ForeColor = SimulationConfiguration.FontColor,
                Location = new Point(0,0)
            };
            BorderStyle = BorderStyle.Fixed3D;
            Anchor = AnchorStyles.Left;
            letterLabel.Size = Size = new Size(AgentsManager.CellSize, AgentsManager.CellSize);
            switch (Type)
            {
                case SlotState.AgentA:
                    BackColor = SimulationConfiguration.AgentAColor;
                    letterLabel.Text = "A";
                    break;
                case SlotState.AgentB:
                    BackColor = SimulationConfiguration.AgentBColor;
                    letterLabel.Text = "B";
                    break;
            }
            letterLabel.BringToFront();
            letterLabel.Update();
        }

        public bool MoveAgent(int deltaX, int deltaY)
        {
            var newPos = new Position() { X = Position.X + deltaX, Y = Position.Y + deltaY };

            if (AgentsManager.GetSlotState(newPos) != SlotState.Empty)
                return false;
            if (!AgentsManager.IsSlotInside(newPos))
                return false;

            AgentsManager.Slot(Position) = null;
            this.Position = newPos;
            AgentsManager.Slot(newPos) = this;
            return true;
        }

        public void ReDraw()
        {
            Location = new System.Drawing.Point(Position.WorldX, Position.WorldY);
            letterLabel.BringToFront();
            letterLabel.BringToFront();
            letterLabel.Update();
            Update();
        }

        public abstract void ProcessMovement();
    }
}
