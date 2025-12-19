using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAST_HMI
{
    internal class typeMotionSide
    {
    bool RequestCoil;		//TRUE if the coil to advance the motion has been switched on
	bool Depth;  			//TRUE if the motion is complete
	bool Prompt;           //TRUE if the motion is OK to move (or to the next step)
	bool InterlockOK;		//TRUE if the interlock is satisified for the motion
	bool NumberOrder;       //number of the motion to take

    System.UInt32 TimeTaken;		//Time Taken for the motion to complete
	
	int valCoil;		
	int valDepth;
	
	bool bHideCoil;		//TRUE to hide the coil
	bool bHideDepth;		//TRUE to hide the depth
	bool bHideInterlock;	//TRUE to hide the interlock
	bool bHidePrompt;		//TRUE to hide the prompt
	bool bHideTime;		//TRUE to hide the time
	bool bHideButton;       //TRUE to hide the button

    System.UInt32 FdbkColour; //sensor feedback colour
    System.UInt32 CoilColour; //coil feedback colour

    }
}
