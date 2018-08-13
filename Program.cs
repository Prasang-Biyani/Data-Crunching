using System.Collections.Generic;
using System.Linq;
using FileHelpers;
using System.IO;
using System;
namespace DataCrunching
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read ID and IP
            var idipEngine = new FileHelperEngine<Idip>();
            var idipsList = idipEngine.ReadFile("Files/ip_1m.tsv").ToList();

            //Read ID, USERNAME, EMAIL, HASH_PASSWORD
            var userEngine = new FileHelperEngine<User>();
            var usersList = userEngine.ReadFile("Files/user_email_hash.1m.tsv").ToList();
            //var engine3 = new FileHelperEngine<Password>();
            //var passwordList = engine3.ReadFile("Files/plain_32m.tsv").ToList();

            //using (StreamWriter sw = new StreamWriter("Output.tsv"))
            //using (StreamWriter sw1 = new StreamWriter("Email.tsv"))
            //{
            //    using (var e1 = idipsList.GetEnumerator())
            //    using (var e2 = usersList.GetEnumerator())
            //    {
            //        while (e1.MoveNext() && e2.MoveNext())
            //        {
            //            sw.Write(e1.Current.id + "\t" + e2.Current.username + "\t" + e2.Current.email + "\t" +
            //                e2.Current.hash_password + "\t" + e1.Current.ip_address + "\n");
            //            sw1.WriteLine(e2.Current.email);
            //        }
            //    }
            //}

            //Create Email List
            var emailList = new List<string>();
            using(var e1 = usersList.GetEnumerator())
            {
                while (e1.MoveNext())
                    emailList.Add(e1.Current.email);
            }
            //var emailEngine = new FileHelperEngine<Email>();
            //var emailsList = emailEngine.ReadFile("Email.tsv").ToList();

            //Dictionary containing Email(Key), Empty String(Value) 
            Dictionary<string, string> emailDict = new Dictionary<string, string>();
            foreach (var email in emailList)
            {
                if (!emailDict.ContainsKey(email))
                    emailDict.Add(email, "");
            }
            Console.WriteLine("Done adding EmailDict");

            //Read 32M File
            using (StreamReader sr = new StreamReader(@"Files/plain_32m.tsv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tsv = line.Split(new char[] { '\t' }).ToArray();
                    //foreach (var email in emailDict)
                    //{
                    //    if (email.Key == tsv[0])
                    //        emailDict[email.Key] = tsv[1];
                    //}
                    if (emailDict.ContainsKey(tsv[0]))
                        emailDict[tsv[0]] = tsv[1];
                }
            }
            //Console.WriteLine("Done Reading 32M and Updating Dictionary ...");
            using (StreamWriter sw = new StreamWriter("Output.tsv"))
            {
                using (var e1 = idipsList.GetEnumerator())
                using (var e2 = usersList.GetEnumerator())
                using (var e3 = emailDict.GetEnumerator())
                {
                    while(e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    {
                        sw.WriteLine(e1.Current.id + "\t" + e2.Current.username + "\t" + e3.Current.Key + 
                            "\t" + e2.Current.hash_password +"\t" +  e3.Current.Value + "\t" + e1.Current.ip_address);
                    }
                }
            }
        }
    }
}