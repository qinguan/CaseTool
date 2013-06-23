using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using Lassalle.Flow;
using CaseTool.Flow;
using CaseTool.CaseObjects;

namespace CaseTool.CaseForm
{
    public partial class WorkspaceForm : DockContent
    {
        private CaseFlow workspaceCaseFlow = new CaseFlow();

        public CaseFlow WorkspaceCaseFlow
        {
            get { return this.workspaceCaseFlow; }
            set { this.workspaceCaseFlow = value; }
        }


        public WorkspaceForm()
        {
            InitializeComponent();
            this.Text = "工作区";
        }

        private void WorkspaceForm_Load(object sender, EventArgs e)
        {
            InitWorkspace();
        }


        private void InitWorkspace()
        {
            workspaceCaseFlow.Dock = DockStyle.Fill;
            workspaceCaseFlow.AutoScroll = true;
            workspaceCaseFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            workspaceCaseFlow.BackColor = SystemColors.Window;
            workspaceCaseFlow.AllowDrop = true;

            workspaceCaseFlow.DragEnter += new DragEventHandler(workspaceCaseFlow_DragEnter);
            workspaceCaseFlow.DragDrop += new DragEventHandler(workspaceCaseFlow_DragDrop);
            workspaceCaseFlow.MouseDown += new MouseEventHandler(workspaceCaseFlow_MouseDown);
            workspaceCaseFlow.AfterResize += new AddFlow.AfterResizeEventHandler(workspaceCaseFlow_AfterResize);
            this.Controls.Add(workspaceCaseFlow);
            workspaceCaseFlow.KeyDown += new KeyEventHandler(workspaceCaseFlow_KeyDown);
        }

        void workspaceCaseFlow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
 
            }

            //全选
            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (Node node in workspaceCaseFlow.Nodes)
                {
                    node.Selected = true;
                    foreach (Link link in node.InLinks)
                    {
                        link.Selected = true;
                    }
                }
            }

            //删除
            if (e.KeyCode == Keys.Delete)
            {
                List<Node> delNode = new List<Node>();
                
                
                foreach (Node node in workspaceCaseFlow.Nodes)
                {
                    if (node.Selected == true)
                    {
                        //删除节点前，先删除该与节点相连的所有连线
                        node.Links.Clear();
                        //workspaceCaseFlow.Nodes.Remove(node);
                        delNode.Add(node);
                    }
                    else
                    {
                        //若不是该节点，则遍历节点的入线
                        foreach (Link lk in node.InLinks)
                        {
                            if (lk.Selected == true)
                            {
                                node.Links.Remove(lk);
                            }
                        }
                    }
                }

                if (delNode.Count != 0)
                {
                    foreach (Node node in delNode)
                    {
                        if (node.Tag is Constants.NodeTag)
                        {
                            workspaceCaseFlow.Nodes.Remove(node);
                        }
                    }
                }
            }
        }

        void workspaceCaseFlow_AfterResize(object sender, EventArgs e)
        {
            foreach (Node node in workspaceCaseFlow.Nodes)
            {
                if (node.Selected == true)
                {
                    switch ((Constants.NodeTag)node.Tag)
                    {
                        case Constants.NodeTag.M_AWAY_GOAL:
                            updateAwayGoal(node);
                            break;
                        case Constants.NodeTag.M_MODULE:
                            updateModule(node);
                            break;
                        case Constants.NodeTag.M_CONTRACT:
                            updateContract(node);
                            break;
                        case Constants.NodeTag.M_AWAY_CONTEXT:
                            updateAwayContext(node);
                            break;
                        case Constants.NodeTag.M_AWAY_SOLUTION:
                            updateAwaySolution(node);
                            break;
                        default:
                            break;
                    }
                    
                }
            }
        }

        #region events

        void workspaceCaseFlow_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Node node in workspaceCaseFlow.Nodes)
            {
                if (node.Selected == true)
                {
                    RefreshProperty(node);
                }
            }
            
        }

        void workspaceCaseFlow_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            pt = PointToClient(pt);//坐标系转换
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode tn = (TreeNode)e.Data.GetData(typeof(TreeNode));
                Node node = CaseNodes.CreateNode(this.workspaceCaseFlow,pt, (Constants.NodeTag)tn.Tag);
                //this.workspaceCaseFlow.Nodes.Add(node);

                RefreshProperty(node);
            }
            
        }

        void workspaceCaseFlow_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        #endregion 


        #region function
        void RefreshProperty(Object obj)
        {
            //绑定属性窗体
            ((MainForm)this.ParentForm).Property.PropertyGrid.SelectedObject = obj;
            //刷新
            ((MainForm)this.ParentForm).Property.PropertyGrid.Refresh();
        }

        void updateAwayGoal(Node node)
        {
            foreach (Node tmp in node.Children)
            {
                tmp.Size = new SizeF(node.Size.Width, node.Size.Height/3);
                tmp.Location = new PointF(node.Location.X, node.Location.Y + node.Size.Height * 2 / 3);
            }
        }

        void updateModule(Node node)
        {
            foreach (Node tmp in node.Children)
            {
                tmp.Size = new SizeF(node.Size.Width / 3, node.Size.Height / 3);
                tmp.Location = new PointF(node.Location.X, node.Location.Y - node.Size.Height / 3);
            }
        }

        void updateContract(Node node)
        {
            foreach (Node tmp in node.Children)
            {
                tmp.Size = new SizeF(node.Size.Width / 3, node.Size.Height / 3);
                if ((Constants.Location)tmp.Tag == Constants.Location.NORTH_WEST)
                {
                    tmp.Location = new PointF(node.Location.X, node.Location.Y - node.Size.Height / 3);
                }
                else if ((Constants.Location)tmp.Tag == Constants.Location.SOUTH_EAST)
                {
                    tmp.Location = new PointF(node.Location.X + node.Size.Width * 2 / 3, node.Location.Y + node.Size.Height);
                }
            }
        }

        void updateAwayContext(Node node)
        {
            foreach (Node tmp in node.Children)
            {
                tmp.Size = new SizeF(node.Size.Width, node.Size.Height / 3);
                tmp.Location = new PointF(node.Location.X, node.Location.Y + node.Size.Height * 2 / 3);
            }
        }

        void updateAwaySolution(Node node)
        {
            foreach (Node tmp in node.Children)
            {
                tmp.Size = new SizeF(node.Size.Width, node.Size.Height / 3);
                tmp.Location = new PointF(node.Location.X, node.Location.Y + node.Size.Height / 2);
            }
        }

        #endregion

    }
}
