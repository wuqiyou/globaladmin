using System.Collections.Generic;
using Trirand.Web.Mvc;

namespace Global.Web.Models
{
    public class SampleViewModel : AdminBaseViewModel
    {
        public string GridId { get; set; }
        public JQGrid GridInstance { get; set; }
        public string Grid2Id { get; set; }
        public JQGrid Grid2Instance { get; set; }

        public SampleViewModel()
        {
            GridId = "grid1";
            GridInstance =
                new JQGrid
                {
                    Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "OrderID", 
                                                        // always set PrimaryKey for Add,Edit,Delete operations
                                                        // if not set, the first column will be assumed as primary key
                                                        Editable = false,
                                                        Width = 50 },
                                     new JQGridColumn { DataField = "OrderDate", 
                                                        Editable = true,
                                                        Width = 100, 
                                                        DataFormatString = "{0:d}" },
                                     new JQGridColumn { DataField = "CustomerID", 
                                                        Editable = true,
                                                        Width = 100 },
                                     new JQGridColumn { DataField = "Freight", 
                                                        Editable = true,
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "ShipName",
                                                        Editable =  true
                                                      }                                     
                                 }
                };

            Grid2Id = "grid2";
            Grid2Instance =
                new JQGrid
                {
                    Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "RowId", 
                                                        // always set PrimaryKey for Add,Edit,Delete operations
                                                        // if not set, the first column will be assumed as primary key
                                                        PrimaryKey = true,
                                                        Editable = false,
                                                        Width = 50 },
                                     new JQGridColumn { DataField = "Title", 
                                                        Editable = true,
                                                        Width = 100 },
                                     new JQGridColumn { DataField = "Description", 
                                                        Editable = true,
                                                        Width = 100 }
                                 }
                };
        }
    }
}