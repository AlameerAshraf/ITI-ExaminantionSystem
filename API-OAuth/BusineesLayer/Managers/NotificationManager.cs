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
        // Employee Notification 

        public bool ListConnectedEmployee(int Type_Id , EmployeeConnectionId IcId)
        {
            bool RetVal = false;
            if (Type_Id == 0)
            {
                db.EmployeeConnectionIds.Add(IcId);
                if (db.SaveChanges() > 0)
                {
                    RetVal = true;
                    return RetVal;
                }
            }
            else if (Type_Id == 1)
            {
                var ins = new InstructorsConnectionId();
                ins.Ins_Id = IcId.Emp_Id;
                ins.Connection_Ids = IcId.Connection_Ids;
                db.InstructorsConnectionIds.Add(ins);
                if (db.SaveChanges() > 0)
                {
                    RetVal = true;
                    return RetVal;
                }
            }
            return RetVal; 
        }
#endregion
    }
}
