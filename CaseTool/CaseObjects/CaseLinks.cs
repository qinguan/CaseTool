using System;
using Lassalle.Flow;
using System.Drawing;

namespace CaseTool.CaseObjects
{
    public class CaseLinks
    {
        #region Link
        public static Link CreateSupportByLink()
        {
            Link link = new Link();
            link.ArrowDst.Angle = ArrowAngle.deg30;
            link.ArrowDst.Filled = true;

            return link;
        }

        public static Link CreateInContextOfLink()
        {
            Link link = new Link();
            link.ArrowDst.Angle = ArrowAngle.deg30;

            return link;
        }

        #endregion

    }
}
