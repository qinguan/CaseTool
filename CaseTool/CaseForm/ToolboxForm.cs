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
            goal.Tag = Constants.NodeTag.GOAL;

            TreeNode context = new TreeNode("Context");
            context.Tag = Constants.NodeTag.CONTEXT;

            TreeNode strategy = new TreeNode("Stragety");
            strategy.Tag = Constants.NodeTag.STRATEGY;

            TreeNode solution = new TreeNode("Solution");
            solution.Tag = Constants.NodeTag.SOLUTION;

            TreeNode assumption = new TreeNode("Assumption");
            assumption.Tag = Constants.NodeTag.ASSUMPTION;

            TreeNode justification = new TreeNode("Justification");
            justification.Tag = Constants.NodeTag.JUSTIFICATION;

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

            TreeNode awayGoal = new TreeNode(Constants.M_AWAY_GOAL);
            awayGoal.Tag = Constants.NodeTag.M_AWAY_GOAL;

            TreeNode module = new TreeNode(Constants.M_MODULE);
            module.Tag = Constants.NodeTag.M_MODULE;

            TreeNode contract = new TreeNode(Constants.M_CONTRACT);
            contract.Tag = Constants.NodeTag.M_CONTRACT;

            TreeNode awayContext = new TreeNode(Constants.M_AWAY_CONTEXT);
            awayContext.Tag = Constants.NodeTag.M_AWAY_CONTEXT;

            TreeNode awaySolution = new TreeNode(Constants.M_AWAY_SOLUTION);
            awaySolution.Tag = Constants.NodeTag.M_AWAY_SOLUTION;

            moduleNode.Nodes.Add(awayGoal);
            moduleNode.Nodes.Add(module);
            moduleNode.Nodes.Add(contract);
            moduleNode.Nodes.Add(awayContext);
            moduleNode.Nodes.Add(awaySolution);
            moduleNode.ExpandAll();

            TreeNode pattenNode = new TreeNode("模式符号");

            TreeNode optional = new TreeNode(Constants.P_OPTIONAL);
            optional.Tag = Constants.NodeTag.P_OPTIONAL;

            TreeNode undeveloped = new TreeNode(Constants.P_UNDEVELOPED);
            undeveloped.Tag = Constants.NodeTag.P_UNDEVELOPED;

            TreeNode uninstantiated = new TreeNode(Constants.P_UNINSTANTIATED);
            uninstantiated.Tag = Constants.NodeTag.P_UNINSTANTIATED;

            TreeNode undevelopedAndUninstantiated = new TreeNode(Constants.P_UNDEVELOPEDANDUNINSTANTIATED);
            undevelopedAndUninstantiated.Tag = Constants.NodeTag.P_UNDEVELOPEDANDUNINSTANTIATED;

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
