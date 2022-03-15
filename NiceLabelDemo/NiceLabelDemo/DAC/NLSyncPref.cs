using System;
using PX.Data;

namespace NiceLabelDemo
{
 
  [PXCacheName("NLSyncPref")]
  public class NLSyncPref : IBqlTable
  {
       
    [PXString(50, IsUnicode = true, IsKey = true)]
    public virtual String Description { get; set; }


    #region Selected
    public abstract class selected : PX.Data.BQL.BqlBool.Field<selected> { }
    [PXBool]
    [PXUIField(DisplayName = "Selected")]
    public virtual bool? Selected { get; set; }
    #endregion  
   
  }
}