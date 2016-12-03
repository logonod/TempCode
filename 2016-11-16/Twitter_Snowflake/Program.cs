﻿#region Test1
//using System;

//namespace Twitter_Snowflake
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            for (int i = 0; i < 1000; i++)
//            {
//                Console.WriteLine($"开始执行 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffffff")}------{Snowflake.Instance().GetId()} \n");
//            }
//            Console.ReadKey();
//        }
//    }
//} 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Twitter_Snowflake
{
    class Program
    {
        /// <summary>
        /// Task完成总数
        /// </summary>
        private static int taskCount = 0;
        private static List<long> list = new List<long>();

        static void Main(string[] args)
        {
            Task.Run(() => GetUid());
            Task.Run(() => GetUid());
            Task.Run(() => GetUid());

            Task.Run(() => Printf());
            Console.ReadKey();
        }

        private static void GetUid()
        {
            for (int i = 0; i < 10000; i++)
            {
                var id = Snowflake.Instance().GetId();
                //Console.WriteLine($"开始执行 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffffff")}------{id} \n");
                list.Add(id);
            }
            taskCount++;
        }

        private static void Printf()
        {
            while (taskCount != 3)
            {
                Thread.Sleep(1000);
                Console.WriteLine("-----------");
            }
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Distinct().Count());
        }
    }
}
