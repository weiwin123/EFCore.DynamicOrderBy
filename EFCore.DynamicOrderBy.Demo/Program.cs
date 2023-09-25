using EFCore.DynamicOrderBy.Demo.Models;
using EFCore.DynamicOrderBy;
namespace EFCore.DynamicOrderBy.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using testOrderByContext ctx = new testOrderByContext();
            //List<TTest> list = new List<TTest>(); 
            //for(var i = 0; i < 50; i++ )
            //{
            //    TTest t = new TTest();
            //    t.SortIndex = i;
            //    t.CreateTime = DateTime.Now;
            //    if(i%5==0)
            //    {
            //        t.Abc = "a";
            //    }
            //    else if (i % 7 == 0){
            //        t.Abc = "b";
            //    }
            //    else
            //    {
            //        t.Abc = "c";
            //    }
            //    list.Add(t);

            //}
            //ctx.TTest.AddRange(list);
            //ctx.SaveChanges();
            var querys= ctx.TTest.Where(t=>t.Abc=="a"||t.Abc=="b").DynamicOrderBy(new List<DynamicOrderByPredicate>() { 
            new DynamicOrderByPredicate() {FieldName="SortIndex",IsDesc=true},
              new DynamicOrderByPredicate() {FieldName="CreateTime",IsDesc=true},
            }).ToList();
        }
    }
}