using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace NiceLabelDemo
{
  public class NLPrinterGraph : PXGraph<NLPrinterGraph, NLPrinter>
  {
    
    public SelectFrom<NLPrinter>.View Ptr;
  
    #region Event Handlers
    public void assign(NLPrinter order)
        {
            
            NLPrinter ptrs = new NLPrinter();
            ptrs.PrinterName = order.PrinterName;
            ptrs.IsActive = true;
           
            Ptr.Insert(ptrs);

            // Trigger the Save action to save the changes to the database
            Actions.PressSave();
        }
    #endregion
  }
}