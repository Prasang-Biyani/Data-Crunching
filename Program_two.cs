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
            //Console.WriteLine("Done 'Output.tsv'");
            //var passEngine = new FileHelperEngine<Password>();
            //var passList = passEngine.ReadFile("Files/plain_32m.tsv");
            //Console.WriteLine("Read 'plain_32m.tsv'");
            //Dictionary<string, string> emailPass = new Dictionary<string, string>();
            //foreach (var pass in passList)
            //    emailPass.Add(pass.email, pass.plain_text);
            //foreach (var cred in credsList)
            //{
            //    if (!emailPass.ContainsKey(cred.Email))
            //        emailPass.Remove(cred.Email);
            //}
            //Console.WriteLine(emailPass.Count());
            Dictionary<string, string> passDict = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader("Files/plain_32m - Copy.tsv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split('\t');
                    foreach(var cred in emailsList)
                    {
                        if (!passDict.ContainsKey(cred.email))
                            passDict.Add(cred.email, temp[1]);
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("Updated List.tsv"))
            {
                foreach (var pass in passDict)
                    sw.WriteLine(pass.Key + "\t" + pass.Value);
            }
        }
    }
}
