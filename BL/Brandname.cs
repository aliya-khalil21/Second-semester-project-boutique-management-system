namespace bb.BL
{
    class Brandname
    {
        protected string brandname;
        public Brandname(string barndname)
        {
            this.brandname = brandname;
        }
        public string getBrandName()
        {
            return brandname;
        }
        public void setBrandName(string brandname)
        {
            this.brandname = brandname;
        }
    }
}
