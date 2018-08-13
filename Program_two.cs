using System.Collections.Generic;
using System.Linq;
using FileHelpers;
using System.IO;
using System;

namespace DataCrunching
{
    class Program_two
    {
        static void Main(string[] args)
        {
            var emailEngine = new FileHelperEngine<Email>();
            var emailsList = emailEngine.ReadFile("Email.tsv").ToList();

            Dictionary<string, string> emailDict = new Dictionary<string, string>();
            foreach(var email in emailsList)
            {
                if (!emailDict.ContainsKey(email.email))
                {
                    emailDict.Add(email.email, "false");
                }
            }
            Console.WriteLine("Done adding EmailDict");
            using(StreamReader sr = new StreamReader(@"Files/plain_32m.tsv"))
            {
               
                string line;
                while((line = sr.ReadLine()) != null)
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
            Console.WriteLine("Done Reading 32M and Updating Dictionary ...");

            using(StreamWriter sw = new StreamWriter("Email_pass.tsv"))
            {
                foreach(var email in emailDict)
                {
                    sw.WriteLine(email.Key + "\t" + email.Value);
                }
            }
            Console.WriteLine("Done");
      
        }
    }
}