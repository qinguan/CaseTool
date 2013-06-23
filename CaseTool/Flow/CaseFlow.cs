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
            Constants.NodeTag start;
            Constants.NodeTag end;
            try
            {
                start = (Constants.NodeTag)e.Link.Org.Tag;
                end = (Constants.NodeTag)e.Link.Dst.Tag;
            }
            catch (Exception ex)
            {
                this.Undo();
                return;
            }

            if (start == Constants.NodeTag.GOAL && end == Constants.NodeTag.GOAL ||
                start == Constants.NodeTag.GOAL && end == Constants.NodeTag.STRATEGY ||
                start == Constants.NodeTag.GOAL && end == Constants.NodeTag.SOLUTION ||

                start == Constants.NodeTag.P_OPTIONAL)
            {
                e.Link.ArrowDst.Filled = true;
                return;
            }

            if (start == Constants.NodeTag.GOAL && end == Constants.NodeTag.CONTEXT ||
                start == Constants.NodeTag.GOAL && end == Constants.NodeTag.ASSUMPTION ||
                start == Constants.NodeTag.GOAL && end == Constants.NodeTag.JUSTIFICATION ||
                start == Constants.NodeTag.STRATEGY && end == Constants.NodeTag.CONTEXT ||
                start == Constants.NodeTag.STRATEGY && end == Constants.NodeTag.ASSUMPTION ||
                start == Constants.NodeTag.STRATEGY && end == Constants.NodeTag.JUSTIFICATION)
            {
                e.Link.ArrowDst.Filled = false;
                return;
            }

            if (end == Constants.NodeTag.P_OPTIONAL)
            {
                e.Link.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            }
            //this.Undo();
            
        }
    }
}
