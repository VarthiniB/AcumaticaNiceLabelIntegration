using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLSubKeyGraph : PXGraph<NLSubKeyGraph>
  {
    public SelectFrom<NLSubscriptionKey>.View subskey;
  
    public PXSave<NLSubscriptionKey> Save;
    public PXCancel<NLSubscriptionKey> Cancel;
    
    
    #region Event Handlers
    
    
    #endregion
  }
}