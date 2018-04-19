using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram
{
    public class ElevatorControlUnit : NotifyUIBase
    {
        public ElevatorControlUnit(int floorIndex, int ElevatorId)
        {
            FloorName = floorIndex + "階";
            ButtonUpIsEnable = true;
            ButtonDownIsEnable = true;
            if (floorIndex == 1)
            {
                PositionIsEnable = true;
            }
            else PositionIsEnable = false;
            ButtonReference = (10-floorIndex).ToString() + ElevatorId.ToString();
        }

        private string buttonReference;
        public string ButtonReference
        {
            get
            {
                return buttonReference;
            }
            set
            {
                buttonReference = value;
                OnpropertyChanged("ButtonReference");
            }
        }

        private bool positionIsEnable;
        public bool PositionIsEnable
        {
            get
            {
                return positionIsEnable;
            }
            set
            {
                positionIsEnable = value;
                OnpropertyChanged("PositionIsEnable");
            }
        }

        private bool buttonUpIsEnable;
        public bool ButtonUpIsEnable
        {
            get
            {
                return buttonUpIsEnable;
            }
            set
            {
                buttonUpIsEnable = value;
                OnpropertyChanged("ButtonUpIsEnable");
            }
        }

        private bool buttonDownIsEnable;
        public bool ButtonDownIsEnable
        {
            get
            {
                return buttonDownIsEnable;
            }
            set
            {
                buttonDownIsEnable = value;
                OnpropertyChanged("ButtonDownIsEnable");
            }
        }

        private string floorName;
        public string FloorName
        {
            get
            {
                return floorName;
            }
            set
            {
                floorName = value;
                OnpropertyChanged("FloorName");
            }
        }
    }
}
