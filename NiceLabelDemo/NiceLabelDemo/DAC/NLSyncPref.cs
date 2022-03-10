using System;
using PX.Data;

namespace NiceLabelDemo
{
 
  [PXCacheName("NLSyncPref")]
  public class NLSyncPref : IBqlTable
  {
   

    #region Description
    [PXUIField(DisplayName = "Description")]
    public virtual string Description { get; set; }
    public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
    #endregion

    #region IsActive
    [PXUIField(DisplayName = "Is Active")]
    public virtual bool? IsActive { get; set; }
    public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
    #endregion

    #region Selected
    public abstract class selected : PX.Data.BQL.BqlBool.Field<selected> { }
    [PXBool]
    [PXUIField(DisplayName = "Selected")]
    public virtual bool? Selected { get; set; }
    #endregion  
   
  }
}