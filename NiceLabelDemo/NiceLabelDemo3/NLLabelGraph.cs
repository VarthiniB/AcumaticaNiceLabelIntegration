using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLLabelGraph : PXGraph<NLLabelGraph, NLLabel>
  {
    
    public SelectFrom<NLLabel>.View labels;
    
    #region Event Handlers
    public void assign(NLLabel order)
        {
            NLLabel labellist = new NLLabel();
            labellist.Nlid = order.Nlid;
            labellist.LabelName = order.LabelName;
            labellist.LabelPath = order.LabelPath;
                    
            labels.Insert(labellist);
            Actions.PressSave();
        }
    
    #endregion
  }
}