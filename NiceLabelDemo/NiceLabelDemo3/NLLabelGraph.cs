using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLLabelGraph : PXGraph<NLLabelGraph, NLLabelList>
  {
    
    public SelectFrom<NLLabelList>.View labels;
    
    #region Event Handlers
    public void assign(NLLabelList order)
        {



            NLLabelList labellist = new NLLabelList();
            labellist.Nlid = order.Nlid;
            labellist.LabelName = order.LabelName;
            labellist.LabelPath = order.LabelPath;
          
           
            labels.Insert(labellist);

            // Trigger the Save action to save the changes to the database
            Actions.PressSave();
        }
    
    #endregion
  }
}