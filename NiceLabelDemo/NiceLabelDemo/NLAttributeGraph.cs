using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLAttributeGraph : PXGraph<NLAttributeGraph, NLLabelAttribute>
  {
    public SelectFrom<NLLabelAttribute>.View Att;
    #region Event Handlers
    public void assign(NLLabelAttribute order)
     {

            NLLabelAttribute atts = new NLLabelAttribute();            
            atts.NLAttributeName = order.NLAttributeName;
          
            atts.AttributeID = order.AttributeID;

            Att.Insert(atts);

            // Trigger the Save action to save the changes to the database
            Actions.PressSave();
    }
  
    #endregion
  }
}