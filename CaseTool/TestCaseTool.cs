using System;
using System.Drawing;
using System.Windows.Forms;

using Lassalle.Flow;
using CaseTool.Flow;
using CaseTool.CaseObjects;

public class Minimal : Form
{
    //[STAThread]
    //public static void Main()
    //{
    //    Application.Run(new Minimal());
    //}
    //public Minimal()
    //{
    //    Text = "Minimal AddFlow";
    //    Size = new Size(500, 300);

    //    // Create the AddFlow control 
    //    //AddFlow addflow = new AddFlow();
    //    CaseFlow cf = new CaseFlow();
    //    cf.Parent = this;
    //    cf.Dock = DockStyle.Fill;
    //    cf.AutoScroll = true;
    //    cf.BackColor = SystemColors.Window;

    //    // Create a diagram 
    //    CreateDiagram(cf);
    //}

    //void CreateDiagram(CaseFlow cf)
    //{
    //    Node node0 = new Node(5, 5, 40, 40, "First node");
    //    cf.Nodes.Add(node0);

    //    //GoalNode gn = new GoalNode(new Node(40, 40, 40, 40, "test goal"));

        
    //    Node node1 = CaseNodes.CreateGoalNode(new Point(20, 30));
    //    cf.Nodes.Add(node1);
    //    Node node2 = CaseNodes.CreateSolutionNode(new Point(60, 50));
    //    cf.Nodes.Add(node2);
    //    Node node3 = CaseNodes.CreateStrategyNode(new Point(100, 70));
    //    cf.Nodes.Add(node3);
    //    node2.OutLinks.Add(CaseLinks.CreateInContextOfLink(), node0);
    //    node1.OutLinks.Add(CaseLinks.CreateSupportByLink(), node0);

    //    Link link = new Link("123");
    //    //link.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
    //    //link.ConnectionStyleDst = ConnectionStyle.EveryWhere;
    //    link.ArrowDst.Angle = ArrowAngle.deg30;
    //    link.ArrowDst.Filled = true;

    //    node3.OutLinks.Add(link, node2);

    //    cf.Nodes.Add(CaseNodes.CreateContextNode(new Point(200, 90)));

    //    Node justfication = CaseNodes.CreateJustificationNode(new Point(140, 90));
    //    cf.Nodes.Add(justfication);
    //    Node label = CaseNodes.CreateJustificationLabelNode(new Point(220, 100));
    //    cf.Nodes.Add(label);
    //    label.Parent = justfication;
 
    //}

    void CreateDiagram0(AddFlow addflow)
    {
        // Create 3 nodes 
        Node node1 = new Node(5, 5, 40, 40, "First node");
        Node node2 = new Node(120, 70, 50, 40, "Second node");
        Node node3 = new Node(5, 100, 40, 40, "Third node");
        RectangleF rec = new RectangleF(200, 200, 50, 50);
        Node node4 = new Node(rec);
        node4.Text = "dede";

        // Create 3 links 
        Link link1 = new Link("link 1");
        Link link2 = new Link("link 2");
        Link link3 = new Link("link 3");

        // Add the nodes and the links to the diagram 
        addflow.Nodes.Add(node1);
        addflow.Nodes.Add(node2);
        addflow.Nodes.Add(node3);
        node1.OutLinks.Add(link1, node2);
        node2.OutLinks.Add(link2, node2);
        node2.OutLinks.Add(link3, node3);
        Link link4 = new Link("link 4");
        node2.InLinks.Add(link4, node3);
        Link link5 = new Link("link 5");
        node2.InLinks.Add(link5, node4);
        addflow.Nodes.Add(node4);
    }

    void CreateDiagram1(AddFlow addflow)
    {
        // Create 3 nodes and add them to the diagram 
        Node node1 = addflow.Nodes.Add(5, 5, 40, 40, "First node");
        Node node2 = addflow.Nodes.Add(120, 70, 50, 40, "Second node");
        Node node3 = addflow.Nodes.Add(5, 100, 40, 40, "Third node");

        // Create 3 links and add them to the diagram 
        Link link1 = node1.OutLinks.Add(node2, "link 1");
        Link link2 = node2.OutLinks.Add(node2, "link 2");
        Link link3 = node2.OutLinks.Add(node3, "link 3");
    }

    void CreateDiagram3(AddFlow addflow)
    {
        // Create 3 yellow nodes with a shadow. 
        // The second node is rectangular
        // and the third one has a Document shape style. 
        Node node1 = new Node(5, 5, 40, 40, "First node");
        node1.FillColor = Color.LightYellow;
        node1.Shadow.Style = ShadowStyle.RightBottom;

        Node node2 = new Node(120, 70, 50, 40, "Second node");
        node2.FillColor = Color.LightYellow;
        node2.Shadow.Style = ShadowStyle.RightBottom;
        node2.Shape.Style = ShapeStyle.Rectangle;

        Node node3 = new Node(5, 100, 40, 40, "Third node");
        node3.FillColor = Color.LightYellow;
        node3.Shadow.Style = ShadowStyle.RightBottom;
        node3.Shape.Style = ShapeStyle.Document;
        // Create 3 links. 
        // Each link is blue and its BackMode property set to Opaque. 
        // The second link has a Bezier style, color of its text is red, and 
        // its destination arrow head angle is 30°. 
        // The third link has a "HVH" style. 
        Link link1 = new Link("link 1");
        link1.DrawColor = Color.Blue;
        link1.BackMode = BackMode.Opaque;

        Link link2 = new Link("link 2");
        link2.DrawColor = Color.Blue;
        link2.BackMode = BackMode.Opaque;
        link2.Line.Style = LineStyle.Bezier;
        link2.TextColor = Color.Red;
        link2.ArrowDst.Angle = ArrowAngle.deg30;
        Link link3 = new Link("link 3");
        link3.DrawColor = Color.Blue;
        link3.BackMode = BackMode.Opaque;
        link3.Line.Style = LineStyle.HVH;

        Link link4 = new Link("link4");
        link4.DrawColor = Color.Aqua;
        link4.BackMode = BackMode.Transparent;
        link4.Line.Style = LineStyle.Bezier;


        // Add the nodes and the links to the diagram 
        addflow.Nodes.Add(node1);
        addflow.Nodes.Add(node2);
        addflow.Nodes.Add(node3);
        node1.OutLinks.Add(link1, node2);
        node2.OutLinks.Add(link2, node2);
        node2.OutLinks.Add(link3, node3);
        node1.InLinks.Add(link4, node3);
    }

    void CreateDiagram4(AddFlow addflow)
    {
        // Default property values for nodes 
        addflow.DefNodeProp.FillColor = Color.LightYellow;
        addflow.DefNodeProp.Shadow.Style = ShadowStyle.RightBottom;

        // Default property values for links 
        addflow.DefLinkProp.DrawColor = Color.Blue;
        addflow.DefLinkProp.BackMode = BackMode.Opaque;

        // Create 3 nodes and assign them some property values 
        Node node1 = new Node(5, 5, 40, 40, "First node", addflow.DefNodeProp);
        Node node2 = new Node(120, 70, 50, 40, "Second node", addflow.DefNodeProp);
        node2.Shape.Style = ShapeStyle.Rectangle;

        Node node3 = new Node(5, 100, 40, 40, "Third node", addflow.DefNodeProp);
        node3.Shape.Style = ShapeStyle.Document;
        // Create 3 links 
        Link link1 = new Link("link 1", addflow.DefLinkProp);

        Link link2 = new Link("link 2", addflow.DefLinkProp);
        link2.ArrowDst.Angle = ArrowAngle.deg30;
        link2.Line.Style = LineStyle.Bezier;
        link2.TextColor = Color.Red;

        Link link3 = new Link("link 3", addflow.DefLinkProp);
        link3.Line.Style = LineStyle.HVH;
        // Add the nodes and the links to the diagram 
        addflow.Nodes.Add(node1);
        addflow.Nodes.Add(node2);
        addflow.Nodes.Add(node3);
        node1.OutLinks.Add(link1, node2);
        node2.OutLinks.Add(link2, node2);
        node2.OutLinks.Add(link3, node3);
    }

    void CreateDiagram6(AddFlow addflow)
    {
        Node dn = (Node)addflow.DefNodeProp.Clone();
        Link dl = (Link)addflow.DefLinkProp.Clone();

        // Default property values for nodes created programmatically 
        dn.FillColor = Color.LightYellow;
        dn.Shadow.Style = ShadowStyle.RightBottom;

        // Default property values for links created programmatically 
        dl.DrawColor = Color.Blue;
        dl.BackMode = BackMode.Opaque;

        // Create 3 nodes and assign them some property values 
        Node node1 = new Node(5, 5, 40, 40, "First node", dn);
        node1.Shape.Style = ShapeStyle.Card;

        Node node2 = new Node(120, 70, 50, 40, "Second node", dn);
        node2.Shape.Style = ShapeStyle.Rectangle;

        Node node3 = new Node(5, 100, 40, 40, "Third node", dn);
        node3.Shape.Style = ShapeStyle.Document;

        // Create 3 links 
        Link link1 = new Link("link 1", dl);

        Link link2 = new Link("link 2", dl);
        link2.ArrowDst.Angle = ArrowAngle.deg30;
        link2.Line.Style = LineStyle.Bezier;
        link2.TextColor = Color.Red;

        Link link3 = new Link("link 3", dl);
        link3.Line.Style = LineStyle.HVH;

        // Add the nodes and the links to the diagram 
        addflow.Nodes.Add(node1);
        addflow.Nodes.Add(node2);
        addflow.Nodes.Add(node3);
        node1.OutLinks.Add(link1, node2);
        node2.OutLinks.Add(link2, node2);
        node2.OutLinks.Add(link3, node3);

        Node node_1 = new Node(150, 100, 50, 50, "node_1");
        node_1.Shape.Style = ShapeStyle.TriangleRectangle;
        Node node_2 = new Node(150, 180, 50, 50, "node_2");
        node_2.Shape.Style = ShapeStyle.Triangle;
        addflow.Nodes.Add(node_1);
        addflow.Nodes.Add(node_2);

    }

}