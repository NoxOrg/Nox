namespace Cryptocash.Ui.Generated.Data.ApiSetting
{
    /// <summary>
    /// Setting class to define Pagination filter options used on returned result entities from target Api in the Ui
    /// </summary>
    public class ApiPaging
    {
        /// <summary>
        /// List of possible Page Size options for use on Datagrid in Ui
        /// </summary>
        public List<int>? PageSizeList { get; set; } 

        /// <summary>
        /// Current Page Number
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Current Page Size
        /// </summary>
        public int CurrentPageSize { get; set; }

        /// <summary>
        /// Current Total of returned entities from Api search result across pages
        /// </summary>
        public int EntityTotal { get; set; }

        /// <summary>
        /// Method to reset the current page to 1
        /// </summary>
        public void ResetPaging()
        {
            CurrentPage = 0;
        }

        /// <summary>
        /// Method to update current page to new value
        /// </summary>
        /// <param name="Page"></param>
        public void SetCurrentPage(int Page)
        {
            CurrentPage = Page;
        }

        /// <summary>
        /// Method to update PageSize to new value
        /// </summary>
        /// <param name="PageSize"></param>
        public void SetCurrentPageSize(int PageSize)
        {
            CurrentPageSize = PageSize;
        }

        /// <summary>
        /// Method to update EntityTotal to new value
        /// </summary>
        /// <param name="Total"></param>
        public void SetEntityTotal(int? Total)
        {
            if (Total != null)
            {
                EntityTotal = Convert.ToInt32(Total);
            }            
        }
    }
}