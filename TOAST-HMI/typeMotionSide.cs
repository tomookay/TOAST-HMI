using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAST_HMI
{
    public record typeMotionSide
    {
		public bool RequestCoil;		//TRUE if the coil to advance the motion has been switched on
		public bool Depth;  			//TRUE if the motion is complete
		public bool Prompt;           //TRUE if the motion is OK to move (or to the next step)
		public bool InterlockOK;		//TRUE if the interlock is satisified for the motion
		public System.UInt32 NumberOrder;       //number of the motion to take

		public System.UInt32 TimeTaken;		//Time Taken for the motion to complete
	
		public int valCoil;		
		public int valDepth;
	
		public bool bHideCoil;		//TRUE to hide the coil
		public bool bHideDepth;		//TRUE to hide the depth
		public bool bHideInterlock;	//TRUE to hide the interlock
		public bool bHidePrompt;		//TRUE to hide the prompt
		public bool bHideTime;		//TRUE to hide the time
		public bool bHideButton;       //TRUE to hide the button

		public System.UInt32 FdbkColour; //sensor feedback colour
		public System.UInt32 CoilColour; //coil feedback colour
    }
}
