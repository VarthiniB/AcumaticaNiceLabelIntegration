using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLPrefMaint : PXGraph<NLPrefMaint>
  {

    public PXSave<NLClassLabelPref> Save;
    public PXCancel<NLClassLabelPref> Cancel;

        public PXSetup<NLSubscriptionKey> AutoNumSetup;

        public SelectFrom<NLClassLabelPref>.View ClassLabelPref;

        public NLPrefMaint()
        {
            NLSubscriptionKey setup = AutoNumSetup.Current;
          //  Subkey = setup.SubscriptionKey;
        }


    }
}