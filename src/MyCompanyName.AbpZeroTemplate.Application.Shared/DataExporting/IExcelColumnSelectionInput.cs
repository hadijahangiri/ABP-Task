using System.Collections.Generic;

namespace MyCompanyName.AbpZeroTemplate.DataExporting
{
    public interface IExcelColumnSelectionInput
    {
        List<string> SelectedColumns { get; set; }
    }
}