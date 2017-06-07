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

        public bool ListConnectedEmployee(int Type_Id , EmployeeConnectionId IcId)
        {
            bool RetVal = false;
            if (Type_Id == 0)
            {
                bool Persisted = db.EmployeeConnectionIds.Where(x => x.Emp_Id == IcId.Emp_Id).Any();
                if (Persisted != true)
                {
                    db.EmployeeConnectionIds.Add(IcId);
                    if (db.SaveChanges() > 0)
                    {
                        RetVal = true;
                        return RetVal;
                    }
                }
                else
                    return RetVal; 
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
                    if (db.SaveChanges() > 0)
                    {
                        RetVal = true;
                        return RetVal;
                    }
                }
                else
                    return RetVal;
            }
            return RetVal; 
        }

        // OnDisconnected Override !
        public void UnListConnectedEmployee(int Type_Id , EmployeeConnectionId IcId)
        {
            if(Type_Id == 0)
            {
                db.Entry(IcId).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            else if (Type_Id == 1)
            {
                InstructorsConnectionId obj = db.InstructorsConnectionIds.Find(IcId.Emp_Id);
                db.Entry(IcId).State = System.Data.Entity.EntityState.Deleted;
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
            StudentsConnectionId obj = db.StudentsConnectionIds.Find(ScId.Std_Id);
            db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
#endregion

    }
}
