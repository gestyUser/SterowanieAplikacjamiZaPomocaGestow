//Author: Dawid Sklorz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    public class GesturesManager
    {
        private string gestureFlag = "";
        private bool recogtationGestureFlag = false;
        private bool activeFlagAd = false;
        private bool activeFlagPp = false;
        private bool activeFlagGs = false;
        private bool activeFlagGt = false;
        private bool startActionFlagAd = false;
        private bool startActionFlagPp = false;
        private bool startActionFlagGs = false;
        private bool startActionFlagGt = false;
        private int currentZoom = 0;
        public int exitCounter = 0;
        public int isPointerSet = 0;
        public ProgramsController program = new ProgramsController();

        public void setGestureFlag(string gesture)
        {
            this.gestureFlag = gesture;
        }

        public void setrecogtationGestureFlag(bool var)
        {
            this.recogtationGestureFlag = var;
        }

        public string getGestureFlag()
        {
            return this.gestureFlag;
        }

        public bool getrecogtationGestureFlag()
        {
            return this.recogtationGestureFlag;
        }

        public void setActiveFlagAd(bool var)
        {
            this.activeFlagAd = var;
        }

        public bool getActiveFlagAd()
        {
            return this.activeFlagAd;
        }

        public void setActiveFlagPp(bool var)
        {
            this.activeFlagPp = var;
        }

        public bool getActiveFlagPp()
        {
            return this.activeFlagPp;
        }

        public void setStartActionFlagAd(bool var)
        {
            this.startActionFlagAd = var;
        }

        public bool getStartActionFlagAd()
        {
            return this.startActionFlagAd;
        }

        public void setStartActionFlagPp(bool var)
        {
            this.startActionFlagPp = var;
        }

        public bool getStartActionFlagPp()
        {
            return this.startActionFlagPp;
        }

        public void setStartActionFlagGs(bool var)
        {
            this.startActionFlagGs = var;
        }

        public bool getStartActionFlagGs()
        {
            return this.startActionFlagGs;
        }

        public void setStartActionFlagGt(bool var)
        {
            this.startActionFlagGt = var;
        }

        public bool getStartActionFlagGt()
        {
            return this.startActionFlagGt;
        }

        public void setActiveFlagGs(bool var)
        {
            this.activeFlagGs = var;
        }

        public bool getActiveFlagGs()
        {
            return this.activeFlagGs;
        }

        public void setActiveFlagGt(bool var)
        {
            this.activeFlagGt = var;
        }

        public bool getActiveFlagGt()
        {
            return this.activeFlagGt;
        }

        public void setPointerMouse()
        {
            if (program.getCurrentProgram() == "Gs")
            {
                if(this.isPointerSet == 0 && program.yesPointerProgram == 1)
                {
                    program.pointer_Mouse(this, null);
                    this.isPointerSet = 1;
                }
            }
        }

        public void doAction(string gesture)
        {
            if (gesture == "start")
            {
                if ((getActiveFlagAd() == false) && (program.getCurrentProgram() == "Ad"))
                {
                    if (getStartActionFlagAd() == false)
                    {
                        program.start_Click(this, null);
                        setStartActionFlagAd(true);
                    }
                    setActiveFlagAd(true);
                }
                else if ((getActiveFlagPp() == false) && (program.getCurrentProgram() == "Pp"))
                {
                    if (getStartActionFlagPp() == false)
                    {
                        program.start_Click(this, null);
                        setStartActionFlagPp(true);
                    }
                    setActiveFlagPp(true);
                }
                else if ((getActiveFlagGs() == false) && (program.getCurrentProgram() == "Gs"))
                {
                    if (getStartActionFlagGs() == false)
                    {
                        program.start_Click(this, null);
                        setStartActionFlagGs(true);
                    }
                    setActiveFlagGs(true);
                }
                else if ((getActiveFlagGt() == false) && (program.getCurrentProgram() == "Gt"))
                {
                    if (getStartActionFlagGt() == false)
                    {
                        program.start_Click(this, null);
                        setStartActionFlagGt(true);
                    }
                    setActiveFlagGt(true);
                }
            }
            else if (gesture == "next")
            {
                program.next_Click(this, null);
            }
            else if (gesture == "previous")
            {
                program.previous_Click(this, null);
            }
            else if (gesture == "zoom_in")
            {
                if (program.getCurrentProgram() == "Pp")
                {
                    if (this.currentZoom < 3)
                    {
                        this.currentZoom++;
                        program.zIn_Click(this, null);
                    }
                }
                else
                {
                    program.zIn_Click(this, null);
                }

            }
            else if (gesture == "zoom_out")
            {
                if (program.getCurrentProgram() == "Pp")
                {
                    if (this.currentZoom > 0)
                    {
                        this.currentZoom--;
                        program.zOut_Click(this, null);
                    }
                }
                else
                {
                    program.zOut_Click(this, null);
                }
            }
            else if (gesture == "right")
            {
                program.right_Click(this, null);
            }
            else if (gesture == "left")
            {
                program.left_Click(this, null);
            }
            else if (gesture == "scroll_up")
            {
                program.scroll_up_Click(this, null);
            }
            else if (gesture == "scroll_down")
            {
                program.scroll_down_Click(this, null);
            }
        }
    }
}
