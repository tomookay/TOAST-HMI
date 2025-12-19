using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAST_HMI
{
    internal class typeMotionRow
    {
    typeMotionSide Advance;
    typeMotionSide Return;
        
    string strPosn; //formatted position, in string form

	int IndexLocation; //index value
	
	bool bHidePosn; //TRUE to hide the posn
	bool bHideName; //TRUE to hide the name
	
	bool bIsAbsSymSwitch; //TRUE to switch between abs/symb
    }
}
