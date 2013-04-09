using System;
using Lassalle.Flow;
using System.Drawing;
using System.Drawing.Drawing2D;

using CaseTool.Flow;

namespace CaseTool.CaseObjects
{
    public class CaseNodes
    {

        public static Node CreateNode(CaseFlow caseFlow, Point pt, Conatants.NodeTag tag)
        {
            switch (tag)
            {
                case Conatants.NodeTag.GOAL:
                    return CreateGoalNode(caseFlow,pt);
                case Conatants.NodeTag.CONTEXT:
                    return CreateContextNode(caseFlow,pt);
                case Conatants.NodeTag.STRATEGY:
                    return CreateStrategyNode(caseFlow,pt);
                case Conatants.NodeTag.ASSUMPTION:
                    return CreateAssumptionNode(caseFlow,pt);
                case Conatants.NodeTag.SOLUTION:
                    return CreateSolutionNode(caseFlow,pt);
                case Conatants.NodeTag.JUSTIFICATION:
                    return CreateJustificationNode(caseFlow,pt);
                case Conatants.NodeTag.M_AWAY_GOAL:
                    return CreateAwayGoalNode(caseFlow,pt);
                case Conatants.NodeTag.M_MODULE:
                    return CreateModuleNode(caseFlow, pt);
                case Conatants.NodeTag.M_CONTRACT:
                    return CreateContractNode(caseFlow, pt);
                case Conatants.NodeTag.M_AWAY_CONTEXT:
                    return CreateAwayContextNode(caseFlow, pt);
                case Conatants.NodeTag.M_AWAY_SOLUTION:
                    return CreateAwaySolutionNode(caseFlow, pt);
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
            node.Tag = Conatants.NodeTag.GOAL;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateSolutionNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 60, 40, "Solution");
            node.Shape.Style = ShapeStyle.Ellipse;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.SOLUTION;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateStrategyNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 80, 30, "Strategy");
            node.Shape.Style = ShapeStyle.Data;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.STRATEGY;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateJustificationNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 88, 40, "Justification");
            node.Shape.Style = ShapeStyle.Ellipse;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.JUSTIFICATION;
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
            node.Tag = Conatants.NodeTag.CONTEXT;
            caseFlow.Nodes.Add(node);
            return node;
        }

        private static Node CreateAssumptionNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 60, 40, "Assumption");
            node.Shape.Style = ShapeStyle.Termination;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.ASSUMPTION;
            caseFlow.Nodes.Add(node);
            return node;
        }

        #endregion

        #region ModulerNode

        private static Node CreateAwayGoalNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 120, 60, Conatants.M_AWAY_GOAL);
            node.Alignment = Alignment.LeftJustifyTOP;
            node.Shape.Style = ShapeStyle.Rectangle;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.M_AWAY_GOAL;
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
            Node node = new Node(pt.X, pt.Y, 100, 40, Conatants.M_MODULE);
            node.Shape.Style = ShapeStyle.Rectangle;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.M_MODULE;
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
            Node node = new Node(pt.X, pt.Y, 100, 40, Conatants.M_CONTRACT);
            node.Shape.Style = ShapeStyle.Rectangle;
            //node.Shadow.Style = ShadowStyle.None;
            node.Tag = Conatants.NodeTag.M_CONTRACT;
            caseFlow.Nodes.Add(node);

            Node subnode = new Node(pt.X, pt.Y - node.Size.Height / 3, node.Size.Width / 3, node.Size.Height / 3);
            caseFlow.Nodes.Add(subnode);
            subnode.Shape.Style = ShapeStyle.Rectangle;
            subnode.Tag = Conatants.Location.NORTH_WEST;
            subnode.Selectable = false;
            subnode.Parent = node;

            Node subnode2 = new Node(pt.X+node.Size.Width * 2 /3, pt.Y + node.Size.Height, node.Size.Width / 3, node.Size.Height / 3);
            caseFlow.Nodes.Add(subnode2);
            subnode2.Shape.Style = ShapeStyle.Rectangle;
            subnode2.Tag = Conatants.Location.SOUTH_EAST;
            subnode2.Selectable = false;
            subnode2.Parent = node;

            return node;
        }

        private static Node CreateAwayContextNode(CaseFlow caseFlow, Point pt)
        {
            Node node = new Node(pt.X, pt.Y, 120, 90, Conatants.M_AWAY_CONTEXT);
            node.Shape.Style = ShapeStyle.Delay;
            node.Shape.Orientation = ShapeOrientation.so_90;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.M_AWAY_CONTEXT;
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
            path.AddArc(0, 0, 100, 40, 180, 0);//弧
            path.CloseFigure();
            path.FillMode = FillMode.Alternate;

            Node node = new Node(pt.X,pt.Y,100,40);
            node.Text = Conatants.M_AWAY_SOLUTION;
            node.Shape.GraphicsPath = path;
            node.Shadow.Style = ShadowStyle.RightBottom;
            node.Tag = Conatants.NodeTag.M_AWAY_SOLUTION;
            caseFlow.Nodes.Add(node);

            return node;

        }

        #endregion

    }

}
