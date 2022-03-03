using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLAttributeGraph : PXGraph<NLAttributeGraph, NLLabelAttributes>
  {
    public SelectFrom<NLLabelAttributes>.View att;
    #region Event Handlers
    public void assign(NLLabelAttributes order)
     {
            //Modify the number of assigned orders for the employee.
            NLLabelAttributes atts = new NLLabelAttributes();            
            atts.NLAttributeName = order.NLAttributeName;
          
            atts.AttributeID = order.AttributeID;

            att.Insert(atts);

            // Trigger the Save action to save the changes to the database
            Actions.PressSave();
    }
  
    #endregion
  }
}