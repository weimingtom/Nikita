﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Nikita.Base.Define;
using Nikita.Base.ConnectionManager;
using Nikita.DataAccess.Expression2Sql;

namespace Nikita.DataAccess.PerformanceTest
{
    public static class MappingSpeedTest
    {
        static int takeCount = 50 * 10000;
        public static readonly string ConnectionString = ConfigConnection.ORMPerformanceTestConnection;
        public static void SpeedTest()
        {
            long useTime = 0;

            //预热
            QueryTest(1);


            useTime = SW.Do(() =>
            {
                QueryTest2(takeCount);
            });

            Console.WriteLine("QueryTest2 一次查询{0}条数据总用时：{1}ms", takeCount, useTime);
            GC.Collect();


            useTime = SW.Do(() =>
            {
                QueryTest(takeCount);
            });

            Console.WriteLine("QueryTest 一次查询{0}条数据总用时：{1}ms", takeCount, useTime);
            GC.Collect();



            //useTime = SW.Do(() =>
            //{
            //    SqlQueryTest(takeCount);
            //});

            //Console.WriteLine("SqlQueryTest 一次查询{0}条数据总用时：{1}ms", takeCount, useTime);
            //GC.Collect();


            Console.WriteLine("GAME OVER");
            Console.ReadKey();
        }
        static void QueryTest(int takeCount)
        {
            DbContext context = new DbContext(SqlType.SqlServer, ConnectionString);
            var aa = new UserInfo { Name = "11", Sex = 1, Email = "123456@qq.com" };
            var aaResult2 = context.ExpressionToSql.Update<UserInfo>(aa);
            var aaResult = context.ExpressionToSql.Insert<UserInfo>(aa);
            //var result6 = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > TestStatic.takeCount2(10)).Take(t => 5);
            //var result5 = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > 1 && t.F_String.Equals("Chloe5"));
            //var result4 = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > 1 && t.F_String.EndsWith("Chloe5")).ToList();
            var result = context.ExpressionToSql.Select<TestEntity>().Take(takeCount).ToList();
            //var result7 = context.ExpressionToSql.Select<TestEntity>().Take(takeCount).ToList2();
            //var result2 = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > takeCount + 1 && t.Id < takeCount + 100).ToList(); 
        }
        static void QueryTest2(int takeCount)
        {
            DbContext context = new DbContext(SqlType.SqlServer, ConnectionString);
            var result7 = context.ExpressionToSql.Select<TestEntity>().Take(takeCount).ToList2();
        }
        //public static int takeCount2(int takeCount)
        //{
        //    return takeCount + 10;
        //}
    }
}
