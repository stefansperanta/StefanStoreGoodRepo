
namespace StefanStoreDTO.ProductDto
{
    public class ProductServiceListProductsRequest
    {
        private string _category;
        private int _pageSize;
        private int _pageNumber = 1;

        public ProductServiceListProductsRequest(string category, int pageSize, int pageNumber)
        {
            Category = category;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }
    }
}
