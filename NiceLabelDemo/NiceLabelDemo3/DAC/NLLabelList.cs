using System;

using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Data.ReferentialIntegrity.Attributes;

using PX.TM;
using PX.Objects.Common;
using PX.Objects.Common.Extensions;
using PX.Objects.GL;
using PX.Objects.CS;
using PX.Objects.TX;
using PX.Objects.EP;
using PX.Objects.DR;
using PX.Objects.CR;

namespace NiceLabelDemo
{
 // [Serializable]
  [PXCacheName("NLLabelList")]
  public class NLLabelList : IBqlTable
  {
    public class PK : PrimaryKeyOf<NLLabelList>.By<labelID>
    {
      public static NLLabelList Find(PXGraph graph, int? labelID) => FindBy(graph, labelID);
    
    }
    
    
    #region LabelID
    [PXDBIdentity(IsKey = true)]
    public virtual int? LabelID { get; set; }
    public abstract class labelID : PX.Data.BQL.BqlInt.Field<labelID> { }
    #endregion

    #region Nlid
    [PXDBInt()]
    [PXUIField(DisplayName = "Nlid")]
    public virtual int? Nlid { get; set; }
    public abstract class nlid : PX.Data.BQL.BqlInt.Field<nlid> { }
    #endregion

    #region LabelName
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Label Name")]
    public virtual string LabelName { get; set; }
    public abstract class labelName : PX.Data.BQL.BqlString.Field<labelName> { }
    #endregion

    #region LabelPath
    [PXDBString(100, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Label Path")]
    public virtual string LabelPath { get; set; }
    public abstract class labelPath : PX.Data.BQL.BqlString.Field<labelPath> { }
    #endregion

    #region VersionNbr
    [PXDBInt()]
    [PXUIField(DisplayName = "Version Nbr")]
    public virtual int? VersionNbr { get; set; }
    public abstract class versionNbr : PX.Data.BQL.BqlInt.Field<versionNbr> { }
    #endregion

    #region IsActive
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Active")]
    public virtual bool? IsActive { get; set; }
    public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
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