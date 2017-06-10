using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Managers
{
    public class NotificationManager
    {
        DataBaseCTX db = new DataBaseCTX();

        #region
        // Student Notification 
        #endregion
#region
        // OnConnected Override !

        public void ListConnectedEmployee(int Type_Id , EmployeeConnectionId IcId)
        {
            if (Type_Id == 0)
            {
                bool Persisted = db.EmployeeConnectionIds.Where(x => x.Emp_Id == IcId.Emp_Id).Any();
                if (Persisted != true)
                {
                    db.EmployeeConnectionIds.Add(IcId);
                    db.SaveChanges();
                }
            }
            else if (Type_Id == 1)
            {
                var ins = new InstructorsConnectionId()
                {
                    Ins_Id = IcId.Emp_Id,
                    Connection_Ids = IcId.Connection_Ids
                };
                bool Persisted = db.InstructorsConnectionIds.Where(x => x.Ins_Id == ins.Ins_Id).Any();
                if (Persisted != true)
                {
                    db.InstructorsConnectionIds.Add(ins);
                    db.SaveChanges();
                }
            }
        }

        // OnDisconnected Override !
        public void UnListConnectedEmployee(int Type_Id , EmployeeConnectionId IcId)
        {
            if(Type_Id == 0)
            {
                db.EmployeeConnectionIds.Remove(IcId);
                db.SaveChanges();
            }
            else if (Type_Id == 1)
            {
                InstructorsConnectionId obj = db.InstructorsConnectionIds.Where(E => E.Ins_Id == IcId.Emp_Id).SingleOrDefault();
                db.InstructorsConnectionIds.Remove(obj);
                db.SaveChanges();
            }
        }

        #endregion

#region
        //Student OnConnected 
        public bool ListConnectedStudents(StudentsConnectionId ScId)
        {
            bool RetVal = false;
            bool Persisted = db.StudentsConnectionIds.Where(w => w.Std_Id == ScId.Std_Id).Any();
            if (Persisted != true)
            {
                db.StudentsConnectionIds.Add(ScId);
            }
            else
                return RetVal;

            return RetVal;
        }

        //Student OnDisconnected 
        public void UnListConnectedStudents(StudentsConnectionId ScId)
        {
            StudentsConnectionId obj = db.StudentsConnectionIds.Where(R => R.Std_Id == ScId.Std_Id).SingleOrDefault();
            db.SaveChanges();
        }
        #endregion


        #region


        // Register Notification!
        public void RegisterNotification(int Id,string Message_body,int Type)
        {
            var NewMessage = new Notification()
            {
                Notification_Text = Message_body,
                Creation_Time = DateTime.Now,
                Is_Read = false
            };
            db.Notifications.Add(NewMessage);
            db.SaveChanges();

            int Issued_id = NewMessage.Notification_Id;
            if (Type == 0)
            {
                var EmployeeNotification = new EmployeeNotification()
                {
                    Emp_Id = Id,
                    Notification_Id = Issued_id,
                    Notify_Id = 1
                };
                db.EmployeeNotifications.Add(EmployeeNotification);
                db.SaveChanges();
            }
            else if (Type == 1)
            {
                var InstructorNotification = new InstructorNotification()
                {
                    Ins_Id = Id,
                    Notification_Id = Issued_id,
                    Notify_Id = 1
                };
                db.InstructorNotifications.Add(InstructorNotification);
                db.SaveChanges();
            }
        }


        // Get ConnectioId 
        public ConnectionState ConnectionIdData(int Id , int Type)
        {
            ConnectionState _CS;
            if(Type == 0)
            {
                var Target = db.EmployeeConnectionIds.Where(e => e.Emp_Id == Id).Single();
                if (Target != null)
                {
                    _CS = new ConnectionState()
                    {
                        ConnectionId = Target.Connection_Ids
                    };
                    return _CS;
                }
                else
                {
                    _CS = new ConnectionState()
                    {
                        ConnectionId = null
                    };
                    return _CS;
                }
            }
            else 
            {
                var Target = db.InstructorsConnectionIds.Where(e => e.Ins_Id == Id).Single();
                if(Target != null)
                {
                    _CS = new ConnectionState()
                    {
                        ConnectionId = Target.Connection_Ids
                    };
                    return _CS;
                }
                else
                {
                    _CS = new ConnectionState()
                    {
                        ConnectionId = null
                    };
                    return _CS;
                }
            }
        }
#endregion
    }

    public class ConnectionState
    {
        public Guid? ConnectionId { get; set; }
    }
}
