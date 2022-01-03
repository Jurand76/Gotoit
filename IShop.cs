namespace shops
{
    public interface IShop
    {
        void AddGrade(double grade);
        Statistic GetStatistics();
        string Name {get;}
        string City {get;}
        event GradeAddedDelegate GradeAdded;
        event GradeAddedDelegate3 GradeAdded3;
    }

}