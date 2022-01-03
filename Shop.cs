using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.IO;
using System.Numerics;

namespace shops
{
    public delegate void GradeAddedDelegate (object sender, EventArgs args);
    public delegate void GradeAddedDelegate3 (object sender, EventArgs args);
    
    public class NamedObject
    {
        public NamedObject(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }
        public string Name {get; set;}
        public string City {get; set;}
    }
    public class SavedShop : ShopBase
    {
        public SavedShop(string name, string city) : base (name, city)
        {
            
        }
        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedDelegate3 GradeAdded3;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}_{City}.txt"))
            { 
                if (grade<0 || grade>5)
                {
                    Console.WriteLine("Only 0-5 grades or q are allowed");
                    return;
                }
              
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                    if (grade<3)
                    {
                        GradeAdded3(this, new EventArgs());
                    }
                }
            }
        }

        public override Statistic GetStatistics()
        {
            var result = new Statistic();
            using(var reader = File.OpenText($"{Name}_{City}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }

}