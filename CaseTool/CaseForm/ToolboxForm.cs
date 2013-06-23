using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace CaseTool.CaseForm
{
    public partial class ToolboxForm : DockContent
    {
        public ToolboxForm()
        {
            InitializeComponent();
            this.Text = "工具箱";
        }

        private void ToolboxForm_Load(object sender, EventArgs e)
        {
            
            TreeNode baseNode = new TreeNode("基本图符");

            TreeNode goal = new TreeNode("Goal");
            goal.Tag = Conatants.NodeTag.GOAL;

            TreeNode context = new TreeNode("Context");
            context.Tag = Conatants.NodeTag.CONTEXT;

            TreeNode strategy = new TreeNode("Stragety");
            strategy.Tag = Conatants.NodeTag.STRATEGY;

            TreeNode solution = new TreeNode("Solution");
            solution.Tag = Conatants.NodeTag.SOLUTION;

            TreeNode assumption = new TreeNode("Assumption");
            assumption.Tag = Conatants.NodeTag.ASSUMPTION;

            TreeNode justification = new TreeNode("Justification");
            justification.Tag = Conatants.NodeTag.JUSTIFICATION;

            baseNode.Nodes.Add(goal);
            baseNode.Nodes.Add(context);
            baseNode.Nodes.Add(strategy);
            baseNode.Nodes.Add(solution);
            baseNode.Nodes.Add(assumption);
            baseNode.Nodes.Add(justification);
            baseNode.ExpandAll();

            //TreeNode baseLink = new TreeNode();
            //baseLink.Text = "基本连线";
            //TreeNode hollowArrow = new TreeNode();
            //hollowArrow.Text = "空心箭头";
            //TreeNode filledArrow = new TreeNode();
            //filledArrow.Text = "实心箭头";
            //baseLink.Nodes.Add(hollowArrow);
            //baseLink.Nodes.Add(filledArrow);
            //baseLink.ExpandAll();

            TreeNode moduleNode = new TreeNode("模块化符号");

            TreeNode awayGoal = new TreeNode(Conatants.M_AWAY_GOAL);
            awayGoal.Tag = Conatants.NodeTag.M_AWAY_GOAL;

            TreeNode module = new TreeNode(Conatants.M_MODULE);
            module.Tag = Conatants.NodeTag.M_MODULE;

            TreeNode contract = new TreeNode(Conatants.M_CONTRACT);
            contract.Tag = Conatants.NodeTag.M_CONTRACT;

            TreeNode awayContext = new TreeNode(Conatants.M_AWAY_CONTEXT);
            awayContext.Tag = Conatants.NodeTag.M_AWAY_CONTEXT;

            TreeNode awaySolution = new TreeNode(Conatants.M_AWAY_SOLUTION);
            awaySolution.Tag = Conatants.NodeTag.M_AWAY_SOLUTION;

            moduleNode.Nodes.Add(awayGoal);
            moduleNode.Nodes.Add(module);
            moduleNode.Nodes.Add(contract);
            moduleNode.Nodes.Add(awayContext);
            moduleNode.Nodes.Add(awaySolution);
            moduleNode.ExpandAll();

            TreeNode pattenNode = new TreeNode("模式符号");

            TreeNode optional = new TreeNode(Conatants.P_OPTIONAL);
            optional.Tag = Conatants.NodeTag.P_OPTIONAL;

            TreeNode undeveloped = new TreeNode(Conatants.P_UNDEVELOPED);
            undeveloped.Tag = Conatants.NodeTag.P_UNDEVELOPED;

            TreeNode uninstantiated = new TreeNode(Conatants.P_UNINSTANTIATED);
            uninstantiated.Tag = Conatants.NodeTag.P_UNINSTANTIATED;

            TreeNode undevelopedAndUninstantiated = new TreeNode(Conatants.P_UNDEVELOPEDANDUNINSTANTIATED);
            undevelopedAndUninstantiated.Tag = Conatants.NodeTag.P_UNDEVELOPEDANDUNINSTANTIATED;

            pattenNode.Nodes.Add(optional);
            pattenNode.Nodes.Add(undeveloped);
            pattenNode.Nodes.Add(uninstantiated);
            pattenNode.Nodes.Add(undevelopedAndUninstantiated);
            pattenNode.ExpandAll();


            this.toolboxTreeView.Nodes.Add(baseNode);
            this.toolboxTreeView.Nodes.Add(moduleNode);
            this.toolboxTreeView.Nodes.Add(pattenNode);
            //this.toolboxTreeView.Nodes.Add(baseLink);

            this.toolboxTreeView.AllowDrop = true;
            this.toolboxTreeView.ItemDrag += new ItemDragEventHandler(toolboxTreeView_ItemDrag);

        }

        void toolboxTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy);
        }


    }
}
