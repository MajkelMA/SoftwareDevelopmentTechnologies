using System.Collections.Generic;

namespace LINQ.MyProduct
{
    public class MyProductRepository
    {
        private iMyProductDataContext<MyProduct> myProductDataContext { get; }

        public MyProductRepository(iMyProductDataContext<MyProduct> myProductDataContext)
        {
            this.myProductDataContext = myProductDataContext;
        }


    }
}
