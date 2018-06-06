using Framework.Core;
using Global.Core;
using Global.Data;
using Global.Web.Common.Helpers;
using SubjectEngine.Core;
using Trirand.Web.Mvc;

namespace Global.Web.Models
{
    public class GridAdminViewModel
    {
        public string GridUniqueId { get; set; }
        public JQGrid GridInstance { get; set; }

        public GridAdminViewModel(GridDto gridData, string gridDataUrl, string rowEditUrl)
        {
            GridInstance = new JQGrid();
            GridInstance.DataUrl = gridDataUrl;
            GridInstance.EditUrl = rowEditUrl;
            InitGrid(gridData);
        }

        private void InitGrid(GridDto gridData)
        {
            // Create columns
            CreateColumns(gridData);
            // Set other properties
            GridUniqueId = gridData.Id.ToString();
            // Customize/change some of the default settings for this model
            // ID is a mandatory field. Must by unique if you have several grids on one page.
            GridInstance.ID = string.Format("grid{0}", GridUniqueId);
            // Setting the DataUrl to an action (method) in the controller is required.
            // This action will return the data needed by the grid
            // show the search toolbar
            //ordersGrid.ToolBarSettings.ShowSearchToolBar = true;
            //ordersGrid.Columns.Find(c => c.DataField == "OrderID").Searchable = false;
            //ordersGrid.Columns.Find(c => c.DataField == "OrderDate").Searchable = false;

            //SetUpCustomerIDSearchDropDown(ordersGrid);
            //SetUpFreightSearchDropDown(ordersGrid);
            //SetShipNameSearchDropDown(ordersGrid);

            GridInstance.AutoWidth = true;
            GridInstance.ToolBarSettings.ShowEditButton = true;
            GridInstance.ToolBarSettings.ShowAddButton = true;
            GridInstance.ToolBarSettings.ShowDeleteButton = true;

            GridInstance.EditDialogSettings.CloseAfterEditing = true;
            GridInstance.EditDialogSettings.Width = 800;

            GridInstance.AddDialogSettings.CloseAfterAdding = true;
            GridInstance.AddDialogSettings.Width = 800;

            // setup the dropdown values for the CustomerID editing dropdown
            //SetUpCustomerIDEditDropDown(ordersGrid);
        }

        private void CreateColumns(GridDto gridData)
        {
            JQGridColumn keyColumn = new JQGridColumn();
            GridInstance.Columns.Add(keyColumn);
            keyColumn.DataField = BaseDto.FLD_Id;
            keyColumn.PrimaryKey = true;
            keyColumn.Width = 40;
            keyColumn.Editable = false;
            keyColumn.Visible = true;

            foreach (GridColumnDto item in gridData.Columns)
            {
                switch (item.ColumnType)
                {
                    case DucTypes.SubTitle:
                    case DucTypes.Integer:
                    case DucTypes.Text:
                    case DucTypes.Html:
                        JQGridColumn textColumn = new JQGridColumn();
                        GridInstance.Columns.Add(textColumn);
                        textColumn.HeaderText = item.ColumnName;
                        textColumn.DataField = DucHelper.GetClientId(item.Id);
                        textColumn.Editable = true;
                        textColumn.EditType = EditType.TextBox;
                        textColumn.Width = item.ColumnWidth;
                        break;
                    case DucTypes.TextArea:
                    case DucTypes.HtmlArea:
                        JQGridColumn column = new JQGridColumn();
                        GridInstance.Columns.Add(column);
                        column.HeaderText = item.ColumnName;
                        column.DataField = DucHelper.GetClientId(item.Id);
                        column.Editable = true;
                        column.EditType = EditType.TextArea;
                        column.Width = item.ColumnWidth;
                        break;
                    case DucTypes.Image:
                        JQGridColumn imageColumn1 = new JQGridColumn();
                        GridInstance.Columns.Add(imageColumn1);
                        imageColumn1.HeaderText = string.Format(UIConst.ValueUrlKeyFormatString, item.ColumnName);
                        imageColumn1.DataField = string.Format(UIConst.ValueUrlKeyFormatString, DucHelper.GetClientId(item.Id));
                        imageColumn1.Editable = true;
                        imageColumn1.EditType = EditType.TextArea;
                        imageColumn1.Resizable = true;
                        imageColumn1.DataType = typeof(string);
                        imageColumn1.Width = item.ColumnWidth;

                        JQGridColumn imageColumn2 = new JQGridColumn();
                        GridInstance.Columns.Add(imageColumn2);
                        imageColumn2.HeaderText = string.Format(UIConst.ValueTextKeyFormatString, item.ColumnName);
                        imageColumn2.DataField = string.Format(UIConst.ValueTextKeyFormatString, DucHelper.GetClientId(item.Id));
                        imageColumn2.Editable = true;
                        imageColumn2.EditType = EditType.TextBox;
                        imageColumn2.Resizable = true;
                        imageColumn2.DataType = typeof(string);
                        imageColumn2.Width = item.ColumnWidth;

                        break;
                    case DucTypes.Hyperlink:
                        JQGridColumn linkColumn1 = new JQGridColumn();
                        GridInstance.Columns.Add(linkColumn1);
                        linkColumn1.HeaderText = string.Format(UIConst.ValueUrlKeyFormatString, item.ColumnName);
                        linkColumn1.DataField = string.Format(UIConst.ValueUrlKeyFormatString, DucHelper.GetClientId(item.Id));
                        linkColumn1.Editable = true;
                        linkColumn1.EditType = EditType.TextBox;
                        linkColumn1.Width = item.ColumnWidth;

                        JQGridColumn linkColumn2 = new JQGridColumn();
                        GridInstance.Columns.Add(linkColumn2);
                        linkColumn2.HeaderText = string.Format(UIConst.ValueTextKeyFormatString, item.ColumnName);
                        linkColumn2.DataField = string.Format(UIConst.ValueTextKeyFormatString, DucHelper.GetClientId(item.Id));
                        linkColumn2.Editable = true;
                        linkColumn2.EditType = EditType.TextBox;
                        linkColumn2.Width = item.ColumnWidth;
                        break;
                    case DucTypes.Datetime:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}