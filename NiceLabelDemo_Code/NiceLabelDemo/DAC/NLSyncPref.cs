using System;
using PX.Data;

namespace NiceLabelDemo
{
 
  [PXHidden]
  public class NLSyncPref : IBqlTable
  {
		public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
		[PXString(50, IsUnicode = true, IsKey = true)]
		[PXUIField(DisplayName = "Description")]
        public virtual String Description { get; set; }

        #region Selected
        public abstract class selected : PX.Data.BQL.BqlBool.Field<selected> { }
        [PXBool]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? Selected { get; set; }
            #endregion
    }
}