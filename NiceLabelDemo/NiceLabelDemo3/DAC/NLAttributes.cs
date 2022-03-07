using System;
using PX.Data;

namespace NiceLabelDemo
{
  [Serializable]
  [PXCacheName("NLLabelAttributes")]
  public class NLAttributes : IBqlTable
  {
    #region AttributeID
    [PXDBIdentity(IsKey = true)]
    public virtual int? AttributeID { get; set; }
    public abstract class attributeID : PX.Data.BQL.BqlInt.Field<attributeID> { }
    #endregion

    #region LabelID
    [PXDBInt()]
    [PXUIField(DisplayName = "Label ID")]
    public virtual int? LabelID { get; set; }
    public abstract class labelID : PX.Data.BQL.BqlInt.Field<labelID> { }
    #endregion

    #region LabelName
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Label Name")]
    public virtual string LabelName { get; set; }
    public abstract class labelName : PX.Data.BQL.BqlString.Field<labelName> { }
    #endregion

    #region NLAttributeName
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "NLAttribute Name")]
    public virtual string NLAttributeName { get; set; }
    public abstract class nLAttributeName : PX.Data.BQL.BqlString.Field<nLAttributeName> { }
    #endregion

    #region AcuAttributeName
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Acu Attribute Name")]
    public virtual string AcuAttributeName { get; set; }
    public abstract class acuAttributeName : PX.Data.BQL.BqlString.Field<acuAttributeName> { }
    #endregion

    #region Description
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Description")]
    public virtual string Description { get; set; }
    public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
    #endregion

    #region DefaultValue
    [PXDBString(10, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Default Value")]
    public virtual string DefaultValue { get; set; }
    public abstract class defaultValue : PX.Data.BQL.BqlString.Field<defaultValue> { }
    #endregion

    #region Format
    [PXDBString(10, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Format")]
    public virtual string Format { get; set; }
    public abstract class format : PX.Data.BQL.BqlString.Field<format> { }
    #endregion

    #region IsPrompted
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Prompted")]
    public virtual bool? IsPrompted { get; set; }
    public abstract class isPrompted : PX.Data.BQL.BqlBool.Field<isPrompted> { }
    #endregion

    #region PromptText
    [PXDBString(10, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Prompt Text")]
    public virtual string PromptText { get; set; }
    public abstract class promptText : PX.Data.BQL.BqlString.Field<promptText> { }
    #endregion

    #region CurrentValue
    [PXDBString(10, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Current Value")]
    public virtual string CurrentValue { get; set; }
    public abstract class currentValue : PX.Data.BQL.BqlString.Field<currentValue> { }
    #endregion

    #region IncrementType
    [PXDBString(10, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Increment Type")]
    public virtual string IncrementType { get; set; }
    public abstract class incrementType : PX.Data.BQL.BqlString.Field<incrementType> { }
    #endregion

    #region IncrementStep
    [PXDBInt()]
    [PXUIField(DisplayName = "Increment Step")]
    public virtual int? IncrementStep { get; set; }
    public abstract class incrementStep : PX.Data.BQL.BqlInt.Field<incrementStep> { }
    #endregion

    #region IncrementCount
    [PXDBInt()]
    [PXUIField(DisplayName = "Increment Count")]
    public virtual int? IncrementCount { get; set; }
    public abstract class incrementCount : PX.Data.BQL.BqlInt.Field<incrementCount> { }
    #endregion

    #region Length
    [PXDBString(10, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Length")]
    public virtual string Length { get; set; }
    public abstract class length : PX.Data.BQL.BqlString.Field<length> { }
    #endregion

    #region IsPickListEnabled
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Pick List Enabled")]
    public virtual bool? IsPickListEnabled { get; set; }
    public abstract class isPickListEnabled : PX.Data.BQL.BqlBool.Field<isPickListEnabled> { }
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