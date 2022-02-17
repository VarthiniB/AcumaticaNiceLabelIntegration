using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo1
{
  public class NLSubKeyGraph : PXGraph<NLSubKeyGraph, NLSubscriptionKey>
  {
    public SelectFrom<NLSubscriptionKey>.View subskey;
  
    public PXSave<NLSubscriptionKey> Save;
    public PXCancel<NLSubscriptionKey> Cancel;
    
    
    #region Event Handlers
    
    
    #endregion
  }
}