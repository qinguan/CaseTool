using System;
using System.Drawing;
using Lassalle.Flow;
using System.Windows.Forms;

namespace CaseTool.Flow
{
    public class CaseFlow : AddFlow
    {
        public CaseFlow()
        {
            this.AllowDrop = true;
            this.BackColor = Color.Gray;
            this.Grid.Draw = true;
            this.Grid.Style = GridStyle.DottedLines;
            this.Grid.Snap = true;
            this.Grid.Color = Color.Gray;
            this.OwnerDraw = false;

            this.CanDrawNode = false;
            this.LinkCreationMode = LinkCreationMode.AllNodeArea;//.MiddleHandle;
            this.LinkHandleSize = HandleSize.Large;

            this.AfterAddLink += new AfterAddLinkEventHandler(CaseFlow_AfterAddLink);
            //this.CanDragScroll = false;
            //this.PageUnit = GraphicsUnit.Point;
            //this.DefNodeProp.Gradient = true;
            //this.DefNodeProp.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
        }

        void CaseFlow_AfterAddLink(object sender, AfterAddLinkEventArgs e)
        {
            Conatants.NodeTag start;
            Conatants.NodeTag end;
            try
            {
                start = (Conatants.NodeTag)e.Link.Org.Tag;
                end = (Conatants.NodeTag)e.Link.Dst.Tag;
            }
            catch (Exception ex)
            {
                this.Undo();
                return;
            }

            if (start == Conatants.NodeTag.GOAL && end == Conatants.NodeTag.GOAL ||
                start == Conatants.NodeTag.GOAL && end == Conatants.NodeTag.STRATEGY ||
                start == Conatants.NodeTag.GOAL && end == Conatants.NodeTag.SOLUTION)
            {
                e.Link.ArrowDst.Filled = true;
                return;
            }

            if (start == Conatants.NodeTag.GOAL && end == Conatants.NodeTag.CONTEXT ||
                start == Conatants.NodeTag.GOAL && end == Conatants.NodeTag.ASSUMPTION ||
                start == Conatants.NodeTag.GOAL && end == Conatants.NodeTag.JUSTIFICATION ||
                start == Conatants.NodeTag.STRATEGY && end == Conatants.NodeTag.CONTEXT ||
                start == Conatants.NodeTag.STRATEGY && end == Conatants.NodeTag.ASSUMPTION ||
                start == Conatants.NodeTag.STRATEGY && end == Conatants.NodeTag.JUSTIFICATION)
            {
                e.Link.ArrowDst.Filled = false;
                return;
            }

            //this.Undo();
            
        }
    }
}
