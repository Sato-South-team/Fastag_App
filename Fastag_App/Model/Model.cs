using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fatag_App
{
    #region Group Master
    public class Group : Common
    {
        public string GroupName { get; set; }
    }
    #endregion

    #region Group Rights
    public class GroupRights : Common
    {
        public string GroupName { get; set; }
        public string ModuleId { get; set; }
    }
    #endregion

    #region User Master
    public class User : Common
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string Group { get; set; }
    }
    #endregion

    #region User Master
    public class TagDetails : Common
    {
        public string SrNo { get; set; }
        public string VehicleClass { get; set; }
        public string Barcodedata { get; set; }
        public string TagID { get; set; }
        public string EPCID { get; set; }
        public string VRC { get; set; }
        public string Usermemory { get; set; }
        public string EPCMemory { get; set; }
        public string OrderID { get; set; }
    }
    #endregion

    #region Machine Master
    public class Machine : Common
    {
        public string MachineNo { get; set; }
        public string Description { get; set; }
    }
    #endregion

    #region Trolley Master
    public class Trolley : Common
    {
        public string TrolleyNo { get; set; }
        public int PackSize { get; set; }
        public string Description { get; set; }
        public bool IsReturnAble { get; set; }
    }
    #endregion

    #region Line Master
    public class Line : Common
    {
        public string LineNo { get; set; }
        public string Description { get; set; }
        public string BackNo { get; set; }
    }
    #endregion

    #region Customer Master
    public class Customer : Common
    {
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public bool IsCustomerEnable { get; set; }
        public List<string> ListBackNo { get; set; }
    }
    #endregion

    #region Part Master

    public class Part : Common
    {
        public string BackNo { get; set; }
        public string Description { get; set; }
        public int StandardBinQty { get; set; }
        public string PartNo { get; set; }
        public string CustomerPartNo { get; set; }
        public bool IsBarcodeAvailable { get; set; }
    }
    #endregion

    #region Location Master

    public class Location : Common
    {
        public string LocationCode { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public List<string> ListBackNo { get; set; }
    }
    #endregion

    #region Shift Master
    public class Shift : Common
    {
        public string ShiftName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
    #endregion

    #region Production Plan Cutting
    public class ProductionPlan : Common
    {
        public string ProductionPlanId { get; set; }
        public string Month { get; set; }
        public int MonthNo { get; set; }
        public int Year { get; set; }
        public int OrderNo { get; set; }
        public string ModelNo { get; set; }
        public string Remarks { get; set; }
        public int Qty { get; set; }
    }
    #endregion

    #region Cutting
    public class Cutting : Common
    {
        public string LineNo { get; set; }
        public string ProductionPlanId { get; set; }
        public string ShiftName { get; set; }
        public string ModelNo { get; set; }
        public int ChargeNo { get; set; }
        public int PalletNo { get; set; }
        public string LotNo { get; set; }
        public string LotNoDate { get; set; }
        public int TotalQty { get; set; }
        public int OkQty { get; set; }
        public int NgQty { get; set; }
        public string Operators { get; set; }
        public string Leaders { get; set; }
        public string TrolleyCard { get; set; }
        public int Status { get; set; }
        public bool IsMixedTrolley { get; set; }
        //Defect
        public int InnerCavity { get; set; }
        public int OuterCavity { get; set; }
        public int PenetrationPorosity { get; set; }
        public int Slag { get; set; }
        public int Dent { get; set; }
        public int Spine { get; set; }
        public int ForeignSubstance { get; set; }
        public int Crack { get; set; }
        public int MaterialLD { get; set; }
        public int OD { get; set; }
        public int Cuttings { get; set; }
        public int Other { get; set; }
        public int DTBQty { get; set; }
        public int Sample { get; set; }
        public int PowerCut { get; set; }
        public int Length { get; set; }
        public int ExtraParam5 { get; set; }
    }

    #endregion

    #region QA

    public class QA : Common
    {
        public string TrolleyCard { get; set; }
        public string Shift { get; set; }
        public int Status { get; set; }
        public int PickedQty { get; set; }
        public int PartialNgQty { get; set; }
        public string PartialNgReason { get; set; }
        public string LotNo { get; set; }
        public bool IsOnHold { get; set; }
    }

    #endregion

    #region Cutting TrolleyUpdate

    public class CuttingTrolleyUpdate:Common
    {
        public string Id { get; set; }
        public string LotNo { get; set; }
        public string LotNoDate { get; set; }
        public bool IsValueChange { get; set; }
    }

    #endregion

    #region Dispatch Order

    public class DispatchOrder : Common
    {
        public string DispatchOrderNo { get; set; }
        public int SrNo { get; set; }
        public string Shift { get; set; }
        public string DispatchDate { get; set; }
        public string ModelNo { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Qty { get; set; }
        public int OldQty { get; set; }
        public int DispatchQty { get; set; }
    }

    #endregion

    #region Color Master
    public class Colors : Common
    {
        public long  RowId { get; set; }
        public string ColorName { get; set; }
    }
    #endregion
}
