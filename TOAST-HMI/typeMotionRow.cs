using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAST_HMI
{
    public record typeMotionRow
    {
        public required typeMotionSide Advance;
        public required typeMotionSide Return;

        public string strPosn; //formatted position, in string form

        public int IndexLocation; //index value

        public bool bHidePosn; //TRUE to hide the posn
        public bool bHideName; //TRUE to hide the name
	
	    public bool bIsAbsSymSwitch; //TRUE to switch between abs/symb
    }
}
