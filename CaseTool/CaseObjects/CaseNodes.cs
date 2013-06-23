using System;
using Lassalle.Flow;
using System.Drawing;
using System.Drawing.Drawing2D;

using CaseTool.Flow;

namespace CaseTool.CaseObjects
{
    public class CaseNodes
    {

        public static Node CreateNode(CaseFlow caseFlow, Point pt, Constants.NodeTag tag)
        {
            switch (tag)
            {
                case Constants.NodeTag.GOAL:
                    return CreateGoalNode(caseFlow,pt);
                case Constants.NodeTag.CONTEXT:
                    return CreateContextNode(caseFlow,pt);
                case Constants.NodeTag.STRATEGY:
                    return CreateStrategyNode(caseFlow,pt);
                case Constants.NodeTag.ASSUMPTION:
                    return CreateAssumptionNode(caseFlow,pt);
                case Constants.NodeTag.SOLUTION:
                    return CreateSolutionNode(caseFlow,pt);
                case Constants.NodeTag.JUSTIFICATION:
                    return CreateJustificationNode(caseFlow,pt);
                case Constants.NodeTag.M_AWAY_GOAL:
                    return CreateAwayGoalNode(caseFlow,pt);
                case Constants.NodeTag.M_MODULE:
                    return CreateModuleNode(caseFlow, pt);
                case Constants.NodeTag.M_CONTRACT:
                    return CreateContractNode(caseFlow, pt);
                case Constants.NodeTag.M_AWAY_CONTEXT:
                    return CreateAwayContextNode(caseFlow, pt);
                case Constants.NodeTag.M_AWAY_SOLUTION:
                    return CreateAwaySolutionNode(caseFlow, pt);
                case Constants.NodeTag.P_OPTIONAL:
                    return CreateOptionalNode(caseFlow, pt);
                case Constants.NodeTag.P_UNDEVELOPED:
                    return CreateUndevelopedNode(caseFlow, pt);
                case Constants.NodeTag.P_UNINSTANTIATED:
                    return CreateUninstantiatedNode(caseFlow, pt);
                case Constants.NodeTag.P_UNDEVELOPEDANDUNINSTANTIATED:
                    return CreateUndevelopedAndUninstantiatedNode(caseFlow, pt);
                default:
                    return null;
            }
        }

        #region BaseNode
        private static Node CreateGoalNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 60, 30, "Goal");
            node.Shape.Style = ShapeStyle.RoundRect;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.GOAL;
            node.Tooltip = Constants.GOAL;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateSolutionNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 60, 40, "Solution");
            node.Shape.Style = ShapeStyle.Ellipse;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.SOLUTION;
            node.Tooltip = Constants.SOLUTION;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateStrategyNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 80, 30, "Strategy");
            node.Shape.Style = ShapeStyle.Data;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.STRATEGY;
            node.Tooltip = Constants.STRATEGY;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateJustificationNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 88, 40, "Justification");
            node.Shape.Style = ShapeStyle.Ellipse;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.JUSTIFICATION;
            node.Tooltip = Constants.JUSTIFICATION;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateJustificationLabelNode(CaseFlow caseFlow, Point pt)
        {
            Node label = new Node(pt.X,pt.Y,30,10,"J");
            label.Shape.Style = ShapeStyle.Rectangle;
            label.DrawColor = Color.Transparent;
            label.TextColor = Color.Red;
            label.Transparent = true;
            label.Logical = false;
            label.Selectable = false;
            label.AutoSize = Lassalle.Flow.AutoSize.NodeToText;
            label.AttachmentStyle = AttachmentStyle.Item;

            return label;
        }

        private static Node CreateContextNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 60, 40, "Context");
            node.Shape.Style = ShapeStyle.Termination;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.CONTEXT;
            node.Tooltip = Constants.CONTEXT;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateAssumptionNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 60, 40, "Assumption");
            node.Shape.Style = ShapeStyle.Termination;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.ASSUMPTION;
            node.Tooltip = Constants.ASSUMPTION;
            caseFlow.Nodes.Add(node);
            return node;
        }

        #endregion

        #region ModulerNode

        private static Node CreateAwayGoalNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 120, 60, Constants.M_AWAY_GOAL);
            node.Alignment = Alignment.LeftJustifyTOP;
            node.Shape.Style = ShapeStyle.Rectangle;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.M_AWAY_GOAL;
            node.Tooltip = Constants.M_AWAY_GOAL;
            caseFlow.Nodes.Add(node);

            Node subnode = new Node(pt.X, pt.Y + node.Size.Height * 3 / 5, node.Size.Width, node.Size.Height * 2 / 5);
            caseFlow.Nodes.Add(subnode);
            subnode.Shape.Style = ShapeStyle.Rectangle;
            subnode.XMoveable = false;
            subnode.YMoveable = false;
            subnode.XSizeable = false;
            subnode.YSizeable = false;
            subnode.LabelEdit = true;
            subnode.Parent = node;
            subnode.Text = "Module identifier";
            
            return node;
        }

        private static Node CreateModuleNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 100, 40, Constants.M_MODULE);
            node.Shape.Style = ShapeStyle.Rectangle;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.M_MODULE;
            node.Tooltip = Constants.M_MODULE;
            caseFlow.Nodes.Add(node);

            Node subnode = new Node(pt.X, pt.Y - node.Size.Height / 3, node.Size.Width/3, node.Size.Height/3);
            caseFlow.Nodes.Add(subnode);
            subnode.Shape.Style = ShapeStyle.Rectangle;
            subnode.XMoveable = false;
            subnode.YMoveable = false;
            subnode.XSizeable = false;
            subnode.YSizeable = false;
            subnode.LabelEdit = true;
            subnode.Parent = node;

            return node;
        }

        private static Node CreateContractNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 100, 40, Constants.M_CONTRACT);
            node.Shape.Style = ShapeStyle.Rectangle;
            //node.Shadow.Style = ShadowStyle.None;
            node.Tag = Constants.NodeTag.M_CONTRACT;
            node.Tooltip = Constants.M_CONTRACT;
            caseFlow.Nodes.Add(node);

            Node subnode = new Node(pt.X, pt.Y - node.Size.Height / 3, node.Size.Width / 3, node.Size.Height / 3);
            caseFlow.Nodes.Add(subnode);
            subnode.Shape.Style = ShapeStyle.Rectangle;
            subnode.Tag = Constants.Location.NORTH_WEST;
            subnode.Selectable = false;
            subnode.Parent = node;

            Node subnode2 = new Node(pt.X+node.Size.Width * 2 /3, pt.Y + node.Size.Height, node.Size.Width / 3, node.Size.Height / 3);
            caseFlow.Nodes.Add(subnode2);
            subnode2.Shape.Style = ShapeStyle.Rectangle;
            subnode2.Tag = Constants.Location.SOUTH_EAST;
            subnode2.Selectable = false;
            subnode2.Parent = node;

            return node;
        }

        private static Node CreateAwayContextNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 120, 90, Constants.M_AWAY_CONTEXT);
            node.Shape.Style = ShapeStyle.Delay;
            node.Shape.Orientation = ShapeOrientation.so_90;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Constants.NodeTag.M_AWAY_CONTEXT;
            node.Tooltip = Constants.M_AWAY_CONTEXT;
            caseFlow.Nodes.Add(node);

            Node subnode = new Node(pt.X, pt.Y + node.Size.Height* 2 / 3, node.Size.Width , node.Size.Height / 3);
            caseFlow.Nodes.Add(subnode);
            subnode.Shape.Style = ShapeStyle.Rectangle;
            subnode.Shadow.Style = ShadowStyle.RightBottom;
            subnode.XMoveable = false;
            subnode.YMoveable = false;
            subnode.XSizeable = false;
            subnode.YSizeable = false;
            subnode.Text = "Module identifier";
            subnode.Parent = node;

            return node;
        }

        private static Node CreateAwaySolutionNode(CaseFlow caseFlow, Point pt)
        {
            GraphicsPath path = new GraphicsPath();//节点上半部分半圆形形状
            path.AddPie(0, 0, 60, 60, 0, 180);//弧
            path.CloseFigure();
            path.FillMode = FillMode.Alternate;

            Node node = new Node(pt.X,pt.Y,100,100);
            node.Text = Constants.M_AWAY_SOLUTION;
            node.Alignment = Alignment.CenterTOP;
            node.Shape.Style = ShapeStyle.Custom;
            node.Shape.GraphicsPath = path;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Shape.Orientation = ShapeOrientation.so_180;
            node.Tag = Constants.NodeTag.M_AWAY_SOLUTION;
            node.Tooltip = Constants.M_AWAY_SOLUTION;
            caseFlow.Nodes.Add(node);


            Node subnode = new Node(pt.X, pt.Y + node.Size.Height / 2, node.Size.Width, node.Size.Height / 3);
            caseFlow.Nodes.Add(subnode);
            subnode.Shape.Style = ShapeStyle.Rectangle;
            subnode.Shadow.Style = ShadowStyle.RightBottom;
            subnode.XMoveable = false;
            subnode.YMoveable = false;
            subnode.XSizeable = false;
            subnode.YSizeable = false;
            subnode.Text = "Module identifier";
            subnode.Parent = node;
            return node;

        }

        #endregion

         #region patten
        private static Node CreateOptionalNode(CaseFlow caseFlow, Point pt) 
        {
            Node node = new Node(pt.X, pt.Y, 40, 40);
            node.Tooltip = Constants.P_OPTIONAL;
            node.Shape.Style = ShapeStyle.Decision;
            node.FillColor = Color.Black;
            node.Tag = Constants.NodeTag.P_OPTIONAL;
            caseFlow.Nodes.Add(node);

            return node;
        }

        private static Node CreateUndevelopedAndUninstantiatedNode(CaseFlow caseFlow, Point pt)
        {

            Node node = new Node(pt.X, pt.Y, 15, 15);
            node.Tooltip = Constants.P_UNDEVELOPEDANDUNINSTANTIATED;
            node.Shape.Style = ShapeStyle.Sort;
            node.Tag = Constants.NodeTag.P_UNDEVELOPEDANDUNINSTANTIATED;
            caseFlow.Nodes.Add(node);

            return node;
        }

        private static Node CreateUndevelopedNode(CaseFlow caseFlow, Point pt)
        {

            Node node = new Node(pt.X, pt.Y, 15, 15);
            node.Tooltip = Constants.P_UNDEVELOPED;
            node.Shape.Style = ShapeStyle.Decision;
            node.Tag = Constants.NodeTag.P_UNDEVELOPED;
            caseFlow.Nodes.Add(node);

            return node;
        }

        private static Node CreateUninstantiatedNode(CaseFlow caseFlow, Point pt)
        {

            Node node = new Node(pt.X, pt.Y, 15, 15);
            node.Tooltip = Constants.P_UNINSTANTIATED;
            node.Shape.Style = ShapeStyle.Extract;
            node.Tag = Constants.NodeTag.P_UNINSTANTIATED;
            caseFlow.Nodes.Add(node);

            return node;
        }

        #endregion
    }

}
