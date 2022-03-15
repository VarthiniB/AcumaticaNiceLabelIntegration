using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLSetupMaint : PXGraph<NLSetupMaint>
  {

    public PXSave<NLSubscriptionKey> Save;
    public PXCancel<NLSubscriptionKey> Cancel;


    public SelectFrom<NLSubscriptionKey>.View Setup;

    }
}