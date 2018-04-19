using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram
{
    public class Elevator : NotifyUIBase
    {
        public Elevator(int id)
        {
            for (int i = 10; i > 0; i--)
            {
                Floors.Add(new ElevatorControlUnit(i, id));
            }

            Id = id;
            FloorIndex = 9;  //Create first position of elevator
        }

        public ObservableCollection<ElevatorControlUnit> Floors { get; set; } = new ObservableCollection<ElevatorControlUnit>();

        private int _floorIndex;
        public int FloorIndex
        {
            get
            {
                return _floorIndex;
            }
            set
            {
                Floors[_floorIndex].PositionIsEnable = false;  //Position Image is disable and enable when FloorIndex changed
                _floorIndex = value;
                OnpropertyChanged("FloorIndex");
                Floors[_floorIndex].PositionIsEnable = true;
            }
        }

        
        public int Id { get; set; }
        public int? Target { get; set; }

        private bool _isMoving;
        public bool IsMoving
        {
            get
            {
                return _isMoving;
            }
            set
            {
                _isMoving = value;
            }
        }

        public void Move(int target)
        {
            Target = target;
            int temp = target - FloorIndex;
            if (temp > 0)
            {
                MoveUp(target);
            }
            else
            {
                MoveDown(target);
            }
        }

        public bool ReachTarget(int target)
        {
            if (FloorIndex == target)
            {
                return true;
            }
            return false;
        }

        public void MoveUp(int target)
        {
            while (!ReachTarget(target))
            {
                System.Threading.Thread.Sleep(500);
                FloorIndex++;
            }
            return;
        }

        public void MoveDown(int target)
        {
            while (!ReachTarget(target))
            {
                System.Threading.Thread.Sleep(500);
                FloorIndex--;
            }
            return;
        }


    }
}
