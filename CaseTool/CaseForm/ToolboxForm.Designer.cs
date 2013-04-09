namespace CaseTool.CaseForm
{
    partial class ToolboxForm
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
            this.toolboxTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // toolboxTreeView
            // 
            this.toolboxTreeView.AllowDrop = true;
            this.toolboxTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolboxTreeView.Location = new System.Drawing.Point(0, 0);
            this.toolboxTreeView.Name = "toolboxTreeView";
            this.toolboxTreeView.Size = new System.Drawing.Size(164, 390);
            this.toolboxTreeView.TabIndex = 0;
            // 
            // ToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 390);
            this.Controls.Add(this.toolboxTreeView);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Name = "ToolboxForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "Toolbox";
            this.Load += new System.EventHandler(this.ToolboxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView toolboxTreeView;



    }
}