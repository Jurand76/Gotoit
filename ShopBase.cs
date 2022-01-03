namespace shops
{
    public abstract class ShopBase : NamedObject, IShop
    {
        public ShopBase (string name, string city) : base (name, city)
        {

        }

        public abstract event GradeAddedDelegate GradeAdded;
        
        public abstract event GradeAddedDelegate3 GradeAdded3;

        public abstract void AddGrade(double grade);

        public abstract Statistic GetStatistics();
       
    }

}