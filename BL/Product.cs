namespace bb.BL
{
    class Product : Brandname
    {
        protected string productname;
        protected string quantity;
        protected string color;
        protected string size;
        protected string priceproduct;
        protected string path;
        protected string productname1;

        public Product(string brandName) : base(brandName)
        {

        }

        public Product(string brandName, string productname1) : base(brandName)
        {
            this.productname1 = productname1;
        }
        public Product(string brandName, string productname, string quantity, string color, string size, string priceproduct) : base(brandName)
        {

            this.productname = productname;
            this.quantity = quantity;
            this.color = color;
            this.size = size;
            this.priceproduct = priceproduct;

        }
        public Product(string brandName, string quantity, string color, string size, string priceproduct) : base(brandName)
        {

            this.brandname = brandName;
            this.quantity = quantity;
            this.color = color;
            this.size = size;
            this.priceproduct = priceproduct;

        }
        public Product(string brandName, string productname, string price) : base(brandName)
        {

            this.productname = productname;

            this.priceproduct = price;

        }
        public string getbrand()
        {
            return brandname;
        }
        public void setbrandname(string brandname)
        {
            this.brandname = brandname;
        }
        public string getproductname()
        {
            return productname;
        }
        public void setprooductname(string productname)
        {
            this.productname = productname;
        }
        public string getcolor()
        {
            return color;
        }
        public void setcolor(string color)
        {
            this.color = color;
        }
        public string getsize()
        {
            return size;
        }
        public void setsize(string size)
        {
            this.size = size;
        }
        public string getproductname1()
        {
            return productname1;
        }
        public void setproductname1(string prooductname1)
        {
            this.productname1 = prooductname1;
        }
        public string getquantity()
        {
            return quantity;
        }
        public void setquantity(string quantity)
        {
            this.quantity = quantity;
        }
        public string getprice()
        {
            return priceproduct;
        }
        public void setprice(string priceproduct)
        {
            this.priceproduct = priceproduct;
        }



    }
}
