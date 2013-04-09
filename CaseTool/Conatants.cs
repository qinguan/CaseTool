﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseTool
{
    public class Conatants
    {
        public enum NodeTag 
        {
            /* base node */
            GOAL,
            SOLUTION,
            STRATEGY,
            JUSTIFICATION,
            CONTEXT,
            ASSUMPTION,
            /* moduler node*/
            M_AWAY_GOAL,
            M_MODULE,
            M_CONTRACT,
            M_AWAY_SOLUTION,
            M_AWAY_CONTEXT,
            M_PUBLIC_INDICATOR_SYMBOL

        }

        public enum LineTag
        {
            SUPPORTEDBY,
            INCONTEXTOF
        }

        public enum Location
        {
            EAST,
            WEST,
            NORTH,
            SOUTH,
            NORTH_EAST,
            SOUTH_EAST,
            NORTH_WEST,
            SOUTH_WEST
        }

        public static readonly String M_AWAY_GOAL = "AwayGoal";
        public static readonly String M_MODULE = "Module";
        public static readonly String M_CONTRACT = "Contract";
        public static readonly String M_AWAY_SOLUTION = "AwaySolution";
        public static readonly String M_AWAY_CONTEXT = "AwayContext";
        public static readonly String M_PUBLIC_INDICATOR_SYMBOL = "PublicIndicatorSymbol";
    }
}
