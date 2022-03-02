using System;
using PX.Data;
using PX.Objects.AR;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  //[Serializable]
  [PXCacheName("NLClassLabelPref")]
  public class NLClassLabelPref : IBqlTable
  {

    #region ClassLabelID
    [PXDBIdentity()]
    public virtual int? ClassLabelID { get; set; }
    public abstract class classLabelID : PX.Data.BQL.BqlInt.Field<classLabelID> { }
    #endregion

    #region CustomerClassID
    [PXDBString(10, IsKey = true, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Customer Class")]
    [PXSelector(typeof(CustomerClass.customerClassID), DescriptionField = typeof(CustomerClass.descr))]
    public virtual string CustomerClassID { get; set; }
    public abstract class customerClassID : PX.Data.BQL.BqlString.Field<customerClassID> { }
    #endregion

    #region LabelID
    [PXDBInt()]
    [PXUIField(DisplayName = "Label ID")]
    public virtual int? LabelID { get; set; }
    public abstract class labelID : PX.Data.BQL.BqlInt.Field<labelID> { }
    #endregion

    #region LabelName
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Default Label")]
    [PXSelector(typeof(NLLabelList.labelName))]  
    public virtual string LabelName { get; set; }
    public abstract class labelName : PX.Data.BQL.BqlString.Field<labelName> { }
    #endregion

    #region PrinterID
    [PXDBInt()]
    [PXUIField(DisplayName = "Printer ID")]
    public virtual int? PrinterID { get; set; }
    public abstract class printerID : PX.Data.BQL.BqlInt.Field<printerID> { }
    #endregion

    #region PrinterName
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Default Printer")]
    [PXSelector(typeof(NLPrinters.printerName))]  
    public virtual string PrinterName { get; set; }
    public abstract class printerName : PX.Data.BQL.BqlString.Field<printerName> { }
    #endregion

    #region SubscriptionKeyID
    [PXDBInt()]
    [PXUIField(DisplayName = "Subscription Key ID")]
    public virtual int? SubscriptionKeyID { get; set; }
    public abstract class subscriptionKeyID : PX.Data.BQL.BqlInt.Field<subscriptionKeyID> { }
    #endregion

    #region SubscriptionKey
    [PXDBString(32, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Subscription Key")]
    public virtual string SubscriptionKey { get; set; }
    public abstract class subscriptionKey : PX.Data.BQL.BqlString.Field<subscriptionKey> { }
    #endregion

    #region CreatedDateTime
    [PXDBCreatedDateTime()]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion

    #region CreatedByID
    [PXDBCreatedByID()]
    public virtual Guid? CreatedByID { get; set; }
    public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
    #endregion

    #region CreatedByScreenID
    [PXDBCreatedByScreenID()]
    public virtual string CreatedByScreenID { get; set; }
    public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBLastModifiedDateTime()]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion

    #region LastModifiedByID
    [PXDBLastModifiedByID()]
    public virtual Guid? LastModifiedByID { get; set; }
    public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
    #endregion

    #region LastModifiedByScreenID
    [PXDBLastModifiedByScreenID()]
    public virtual string LastModifiedByScreenID { get; set; }
    public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
    #endregion

    #region Tstamp
    [PXDBTimestamp()]
    [PXUIField(DisplayName = "Tstamp")]
    public virtual byte[] Tstamp { get; set; }
    public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
    #endregion

    #region Noteid
    [PXNote()]
    public virtual Guid? Noteid { get; set; }
    public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
    #endregion
  }
}