using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Lassalle.XMLFlow;
using Lassalle.Flow;
using CaseTool.CaseForm;
using CaseTool.Flow;
using CaseTool.CaseObjects;
using WeifenLuo.WinFormsUI.Docking;

namespace CaseTool.CaseForm
{
    public partial class MainForm : Form
    {
        private ToolboxForm toolbox;
        private WelcomeForm welcomePage;
        private InformationForm info;
        private SolutionExplorerForm solutionExplorer;
        private PropertyForm property;
        private List<WorkspaceForm> workspaceList = new List<WorkspaceForm>();

        #region getter && setter
        public ToolboxForm Toolbox
        {
            get { return this.toolbox; }
            set { this.toolbox = value; }
        }

        public WelcomeForm WelcomePage
        {
            get { return this.welcomePage; }
            set { this.welcomePage = value; }
        }

        public InformationForm Info
        {
            get { return this.info; }
            set { this.info = value; }
        }

        public SolutionExplorerForm SolutionExplorer
        {
            get { return this.solutionExplorer; }
            set { this.solutionExplorer = value; }
        }

        public PropertyForm Property
        {
            get { return this.property; }
            set { this.property = value; }
        }
        #endregion


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            dockPanel.Dock = DockStyle.Fill;
            dockPanel.BackColor = Color.Beige;
            dockPanel.BringToFront();

            toolbox = new ToolboxForm();
            toolbox.Show(dockPanel,DockState.DockLeft);

            welcomePage = new WelcomeForm();
            welcomePage.Show(dockPanel, DockState.Document);

            info = new InformationForm();
            //info.Show(dockPanel,DockState.Document);
            info.Show(dockPanel, DockState.DockBottomAutoHide);

            //WorkspaceForm ws = new WorkspaceForm();
            //ws.Show(dockPanel, DockState.Document);
            //ws.DockTo(dockPanel, DockStyle.Fill);

            solutionExplorer = new SolutionExplorerForm();
            solutionExplorer.Show(dockPanel, DockState.DockRight);

            property = new PropertyForm();
            property.Show(dockPanel, DockState.DockRight);
            
            toolbox.DockPanel.DockLeftPortion = 1 / 6.0;
            property.DockPanel.DockRightPortion = 1 / 6.0;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkspaceForm ws = new WorkspaceForm();
            workspaceList.Add(ws);
            ws.Show(dockPanel, DockState.Document);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            String filename = String.Empty;
            foreach (WorkspaceForm wf in workspaceList)
            {
                if (wf.IsActivated)
                {
                    filename = wf.Text;
                    if (filename.Length > 1)
                        sfd.FileName = filename;
                    else
                        sfd.FileName = "*.xml";
                }
            }
            
            sfd.Filter = "Case Diagrams(*.xml)|*.xml|All Files(*.*)|*.*";
            sfd.InitialDirectory = Application.StartupPath;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFile(sfd.FileName);
            }
        }

        void SaveFile(String filename)
        {
            foreach (WorkspaceForm wf in workspaceList)
            {
                if (wf.IsActivated)
                {
                    XmlTextWriter writer = new XmlTextWriter(filename, null);
                    writer.Formatting = Formatting.Indented;
                    wf.WorkspaceCaseFlow.WriteXml(writer);
                    writer.Close();
                    wf.WorkspaceCaseFlow.SetChangedFlag(false);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "Case Diagrams(*.xml)|*.xml|All Files(*.*)|*.*";
            ofd.FileName = "*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadFile(ofd.FileName);
        }

        void LoadFile(string strFileName)
        {
            WorkspaceForm ws = new WorkspaceForm();
            workspaceList.Add(ws);
            ws.Show(dockPanel, DockState.Document);

            ws.WorkspaceCaseFlow.ResetUndoRedo();
            ws.WorkspaceCaseFlow.Nodes.Clear();
            XmlTextReader reader = new XmlTextReader(strFileName);
            reader.WhitespaceHandling = System.Xml.WhitespaceHandling.None;
            ws.WorkspaceCaseFlow.ReadXml(reader);
            reader.Close();
            ws.WorkspaceCaseFlow.SetChangedFlag(false);

        }

    }
}
