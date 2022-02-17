using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo1
{
  public class NLPrefMaint : PXGraph<NLPrefMaint, NLClassLabelPref>
  {

    public PXSave<NLClassLabelPref> Save;
    public PXCancel<NLClassLabelPref> Cancel;

   
    
    public SelectFrom<NLClassLabelPref>.View ClassLabelPref;
   // public PXSelect<NLSubscriptionKey> SubscriptionKey;
    
    
    
    public PXAction<NLClassLabelPref> AddSubscriptionKey;
    [PXButton(CommitChanges = true)]
    [PXUIField(DisplayName = "Add Subscription Key", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
    protected void addSubscriptionKey()
    {

            try
            {
                NLSubKeyGraph keygraph = PXGraph.CreateInstance<NLSubKeyGraph>();
                NLSubscriptionKey key = new NLSubscriptionKey();
                key.SubscriptionKey = this.ClassLabelPref.Current.SubscriptionKey;

                keygraph.subskey.Insert(key);
                keygraph.Save.Press();
            }
            catch(Exception e)
            {
                
            }


  

    }

    


  }
}