using System;
using PX.Data;

namespace NiceLabelDemo
{
 
  [PXCacheName("NLSyncPref")]
  public class NLSyncPref : IBqlTable
  {
   

    #region Description
   /* [PXUIField(DisplayName = "Description")]
    public virtual string Description { get; set; }
    public abstract class description : PX.Data.BQL.BqlString.Field<description> { } */
        #endregion

        [PXString(5, IsUnicode = true, InputMask = ">LLLLL")]
        public virtual String Description { get; set; }


        #region Selected
        public abstract class selected : PX.Data.BQL.BqlBool.Field<selected> { }
    [PXBool]
    [PXUIField(DisplayName = "Selected")]
    public virtual bool? Selected { get; set; }
    #endregion  
   
  }
}