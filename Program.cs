using System;
using System.Collections.Generic;
using System.Linq;
using FileHelpers;
using System.Collections;
using System.IO;

namespace DataCrunching
{
    class Program
    {
        static void Main(string[] args)
        {
            ////ID and IP
            var engine = new FileHelperEngine<Idip>();
            var Idips = engine.ReadFile("files/ip_1m.tsv");
            SortedDictionary<int, string> sortDict = new SortedDictionary<int, string>();

            foreach (var idip in Idips)
            {
                int result = 0;
                if (Int32.TryParse(idip.id, out result))
                    sortDict.Add(result, idip.ip_address);
            }
            ICollection keys = sortDict.Keys;
            using (StreamWriter sw = new StreamWriter("Output.tsv"))
            {
                foreach (var key in keys)
                    sw.WriteLine(key + "\t" + sortDict[(int)key] + "\t");
            }
            Console.WriteLine(sortDict.Count());
            var engineUser = new FileHelperEngine<User>();

        }
    }
}