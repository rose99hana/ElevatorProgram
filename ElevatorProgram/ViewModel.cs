using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElevatorProgram
{
    public class ViewModel : NotifyUIBase
    {

        public ViewModel()
        {
            Elevators.Add(new Elevator(0));
            Elevators.Add(new Elevator(1));
            Elevators.Add(new Elevator(2));
            Task.Factory.StartNew(Operator);
        }

        public ObservableCollection<Elevator> Elevators { get; set; } = new ObservableCollection<Elevator>();
        public BlockingCollection<object> TargetsQueue = new BlockingCollection<object>();
        public BlockingCollection<Action> ActionsQueue = new BlockingCollection<Action>();

        private void Operator()
        {
            Task[] tasks = new Task[3];

            while (true)
            {
                char[] str;
                int targetFloor = 0;
                int elevatorIndex = 0;
                int activeElevatorIndex = 0;
                string direction = "";

                object target;

                Action aa = () =>
                {
                    ActivateElevator(targetFloor, elevatorIndex, direction, activeElevatorIndex);
                };
                
                target = TargetsQueue.Take();


                str = target.ToString().ToArray();

                targetFloor = Int32.Parse(str[0].ToString());
                elevatorIndex = Int32.Parse(str[1].ToString());
                direction = str[2].ToString();

                if (direction == "U")
                {
                    direction = "Up";
                }
                else
                {
                    direction = "Down";
                }

                activeElevatorIndex = SetActiveElevator(targetFloor);

                ActionsQueue.Add(aa);

                while(ActionsQueue.Count > 0)
                {
                    switch (activeElevatorIndex)
                    {
                        case 0:
                            if (tasks[0] == null || tasks[0].Status != TaskStatus.Running)
                            {
                                tasks[0] = Task.Factory.StartNew(ActionsQueue.Take());
                            }
                            break;
                        case 1:
                            if (tasks[1] == null || tasks[1].Status != TaskStatus.Running)
                            {
                                tasks[1] = Task.Factory.StartNew(ActionsQueue.Take());
                            }
                            break;
                        case 2:
                            if (tasks[2] == null || tasks[2].Status != TaskStatus.Running)
                            {
                                tasks[2] = Task.Factory.StartNew(ActionsQueue.Take());
                            }
                            break;
                        case 3:
                            {
                                activeElevatorIndex = SetActiveMovingElevator(targetFloor);
                                switch (activeElevatorIndex)
                                {
                                    case 0:
                                        {
                                            tasks[0].Wait();
                                            tasks[0] = Task.Factory.StartNew(ActionsQueue.Take());
                                        }
                                        break;
                                    case 1:
                                        {
                                            tasks[1].Wait();
                                            tasks[1] = Task.Factory.StartNew(ActionsQueue.Take());
                                        }
                                        break;
                                    case 2:
                                        {
                                            tasks[2].Wait();
                                            tasks[2] = Task.Factory.StartNew(ActionsQueue.Take());
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        public void ActivateElevator(int target, int elevatorindex, string buttonDirection, int activeElevatorIndex)
        {
            Elevators[activeElevatorIndex].IsMoving = true;   
            Elevators[activeElevatorIndex].Move(target);

            if (buttonDirection == "Down")   //after finished moving to target, enable clicked button!!
            {
                Elevators[elevatorindex].Floors[target].ButtonDownIsEnable = true;
            }
            else
            {
                Elevators[elevatorindex].Floors[target].ButtonUpIsEnable = true;
            }
            System.Threading.Thread.Sleep(1000);
            Elevators[activeElevatorIndex].IsMoving = false;
            Elevators[activeElevatorIndex].Target = null;
        }

        public int SetActiveElevator(int target)
        {
            int Id = 0;
            int Min = 10;
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                int distance = Math.Abs(target - Elevators[i].FloorIndex);  //get distance between target and elevators position
                if (Elevators[i].IsMoving == true)
                {
                    count++;
                    continue;
                }
                if (distance < Min)    // set active to elevator which have min distance
                {
                    Min = distance;
                    Id = i;
                }
                else if (distance == Min && Elevators[i].FloorIndex < target)
                {
                    Min = distance;
                    Id = i;
                }
            }

            if (count == 3)   //if all the elevators are working, set ActiveElevator = 3
            {
                Id = 3;
            }

            return Id;
        }

        public int SetActiveMovingElevator(int target)
        {
            int Id = 0;
            int Min = 10;
            int distance;

            for (int i = 0; i < 3; i++)
            {
                 //get distance between new target and Target of Elevators
                if (Elevators[i].Target == null)
                {
                    distance = Math.Abs(target - Elevators[i].FloorIndex);
                }
                else
                {
                    distance = Math.Abs(target - (int)Elevators[i].Target);

                    if (distance < Min)    // set active to elevator which have min distance
                    {
                        Min = distance;
                        Id = i;
                    }
                    else if (distance == Min && Elevators[i].FloorIndex < target)
                    {
                        Min = distance;
                        Id = i;
                    }
                }
            }

            return Id;
        }



        public void ElevatorUp(object target)
        {
            char[] str = target.ToString().ToArray();
            int floorindex, elevatorindex;
            floorindex = Int32.Parse(str[0].ToString());
            elevatorindex = Int32.Parse(str[1].ToString());

            Elevators[elevatorindex].Floors[floorindex].ButtonUpIsEnable = false;

            TargetsQueue.Add(target);

        }

        public void ElevatorDown(object target)
        {
            char[] str = target.ToString().ToArray();
            int floorindex, elevatorindex;
            floorindex = Int32.Parse(str[0].ToString());
            elevatorindex = Int32.Parse(str[1].ToString());

            Elevators[elevatorindex].Floors[floorindex].ButtonDownIsEnable = false;

            TargetsQueue.Add(target);

        }       
    }
}
