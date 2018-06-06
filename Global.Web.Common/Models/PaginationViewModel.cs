using System;
using System.Web;

namespace Global.Web.Common.Models
{
    public class PaginationViewModel
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int MaxPage { get; private set; }
        public int LowerBoundary { get; set; }
        public int UpperBoundary { get; set; }
        public bool ShowTotal { get; set; }

        private int PageSize { get; set; }
        private int PagerWindowSize { get; set; }

        public PaginationViewModel(int totalItems, int currentPage, int pageSize = 10, int pagerWindowSize = 5)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            PagerWindowSize = pagerWindowSize;
            // Calculate total pages
            MaxPage = (int)((totalItems + pageSize - 1) / pageSize);
            // calculate 
            CalculateBoundaries(currentPage, MaxPage, pagerWindowSize);
        }

        public bool IsSuppressed
        {
            get { return this.MaxPage <= 1; }
        }

        public int PreviousPage
        {
            get
            {
                if (CurrentPage > 1)
                {
                    return CurrentPage - 1;
                }
                else
                {
                    return CurrentPage;
                }
            }
        }

        public int NextPage
        {
            get
            {
                if (CurrentPage < MaxPage)
                {
                    return CurrentPage + 1;
                }
                else
                {
                    return CurrentPage;
                }
            }
        }

        public string GetPageUrl(int pageNumber, Uri CurrentUri, string PagingQueryStringParameter)
        {
            var leftPart = CurrentUri.GetLeftPart(UriPartial.Query);
            leftPart = CurrentUri.AbsolutePath;

            var uriBuilder = new UriBuilder(CurrentUri);
            var qsParams = HttpUtility.ParseQueryString(uriBuilder.Query);

            qsParams.Set(PagingQueryStringParameter, (pageNumber).ToString());

            uriBuilder.Query = qsParams.ToString();
            return String.Format("{0}{1}", leftPart, uriBuilder.Query);
        }

        private void CalculateBoundaries(int currentPage, int totalPages, int pagerWindowSize)
        {
            LowerBoundary = Math.Max(1, currentPage - pagerWindowSize / 2);
            UpperBoundary = LowerBoundary + pagerWindowSize - 1;
            if (UpperBoundary > totalPages)
            {
                UpperBoundary = totalPages;
                LowerBoundary = Math.Max(1, UpperBoundary - pagerWindowSize + 1);
            }
        }
    }
}