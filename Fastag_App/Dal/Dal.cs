using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fatag_App
{
    public class Dal
    {
        StringBuilder _SbQry;

        #region GroupMaster

        public DataSet GetGroup(Group group)
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("Exec Prc_GroupMaster '" + group.DbType + "','" + group.GroupName + "'");
                oDb.Connect();
                return oDb.GetDataSet(_SbQry.ToString());
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        public void SaveGroup(Group group, DataGridView dgv)
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("Exec Prc_GroupMaster '" + EnumDbType.INSERT + "','" + group.GroupName + "','','" + group.CreatedBy + "'");
                oDb.Connect();
                oDb.BeginTran();
                //First Insert Group Name 
                oDb.GetDataTable(_SbQry.ToString());
                //Now Insert Group Rights
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["HasRight"].Value) == true)
                    {
                        _SbQry.Length = 0;
                        _SbQry.AppendLine("Exec Prc_GroupMaster 'INSERT_GROUP_RIGHT','" + group.GroupName + "','" + row.Cells["ModuleId"].Value.ToString() + "','" + group.CreatedBy + "'");
                        oDb.GetDataTable(_SbQry.ToString());
                    }
                }
                oDb.CommitTran();
            }
            catch (Exception ex) { oDb.RollBackTran(); throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        public void UpdateGroup(Group group, DataGridView dgv)
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("Exec Prc_GroupMaster 'DELETE_GROUP_RIGHT','" + group.GroupName + "','','" + group.CreatedBy + "'");
                oDb.Connect();
                oDb.BeginTran();
                //First Insert Group Name 
                oDb.GetDataTable(_SbQry.ToString());
                //Now Insert Group Rights
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["HasRight"].Value) == true)
                    {
                        _SbQry.Length = 0;
                        _SbQry.AppendLine("Exec Prc_GroupMaster 'INSERT_GROUP_RIGHT','" + group.GroupName + "','" + row.Cells["ModuleId"].Value.ToString() + "','" + group.CreatedBy + "'");
                        oDb.GetDataTable(_SbQry.ToString());
                    }
                }
                oDb.CommitTran();
            }
            catch (Exception ex) { oDb.RollBackTran(); throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        #endregion

        #region User Master

        public DataTable GetGroupName()
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("SELECT GroupName FROM GROUPMASTER Order By GroupName");
                oDb.Connect();
                return oDb.GetDataTable(_SbQry.ToString());
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        public DataTable ManageUser(User user)
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("Exec Prc_UserMaster '" + user.DbType + "','" + user.UserId + "','" + user.Name + "'");
                _SbQry.AppendLine(",'" + user.Password + "','" + user.Group + "','" + user.CreatedBy + "','" + user.NewPassword + "'");
                oDb.Connect();
                return oDb.GetDataTable(_SbQry.ToString());
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }


        public DataTable ManageUser(TagDetails OTag)
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("Exec Prc_TagInsert '" + OTag.DbType + "','" + OTag.SrNo + "','" + OTag.Barcodedata + "'");
                _SbQry.AppendLine(",'" + OTag.VehicleClass + "','" + OTag.Usermemory + "','" + OTag.EPCMemory + "','" + OTag.EPCID  + "','" + OTag.TagID  + "','" + OTag.VRC  + "','" + OTag.OrderID + "'");
                oDb.Connect();
                return oDb.GetDataTable(_SbQry.ToString());
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        #endregion

        #region Menu

        public DataTable GetUserRight(string UserGroup)
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("SELECT ModuleId FROM GroupRight Where GroupName = '" + UserGroup + "'");
                oDb.Connect();
                return oDb.GetDataTable(_SbQry.ToString());
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        public DataTable GetShift()
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("Exec [Prc_GetShift]");
                oDb.Connect();
                return oDb.GetDataTable(_SbQry.ToString());
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        public DataTable GetTimerTime(string Type = "")
        {
            clsDB oDb = new clsDB();
            try
            {
                _SbQry = new StringBuilder("Exec [Prc_GetTimerTime] '" + Type + "'");
                oDb.Connect();
                return oDb.GetDataTable(_SbQry.ToString());
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                oDb.DisConnect();
                oDb = null;
            }
        }

        #endregion
    }
}
