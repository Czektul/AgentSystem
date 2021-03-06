﻿using MainApp.Agents;

namespace MainApp
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.AgentsSandbox = new System.Windows.Forms.Panel();
            this.updateAgentsTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // AgentsSandbox
            // 
            this.AgentsSandbox.BackColor = System.Drawing.SystemColors.InfoText;
            this.AgentsSandbox.Location = new System.Drawing.Point(2, 0);
            this.AgentsSandbox.Name = "AgentsSandbox";
            this.AgentsSandbox.Size = new System.Drawing.Size(346, 249);
            this.AgentsSandbox.TabIndex = 0;
            // 
            // updateAgentsTimer
            // 
            this.updateAgentsTimer.Interval = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(855, 498);
            this.Controls.Add(this.AgentsSandbox);
            this.Name = "MainWindow";
            this.Text = "AgentSystem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel AgentsSandbox;
        private System.Windows.Forms.Timer updateAgentsTimer;
    }
}

