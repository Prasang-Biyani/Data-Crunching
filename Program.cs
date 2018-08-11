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
            var idipEngine = new FileHelperEngine<Idip>();
            var idipsList = idipEngine.ReadFile("Files/ip_1m.tsv").ToList();

            var userEngine = new FileHelperEngine<User>();
            var usersList = userEngine.ReadFile("Files/user_email_hash.1m.tsv").ToList();

            //var engine3 = new FileHelperEngine<Password>();
            //var passwordList = engine3.ReadFile("Files/plain_32m.tsv").ToList();

            using (StreamWriter sw = new StreamWriter("Output.tsv"))
            using (StreamWriter sw1 = new StreamWriter("Email.tsv"))
            {
                using (var e1 = idipsList.GetEnumerator())
                using (var e2 = usersList.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        sw.Write(e1.Current.id + "\t" + e2.Current.username + "\t" + e2.Current.email + "\t" +
                            e2.Current.hash_password + "\t" + e1.Current.ip_address + "\n");
                        sw1.WriteLine(e2.Current.email);
                    }
                }
            }
            
            //var credEngine = new FileHelperEngine<Credetianls>();
            //var credsList = credEngine.ReadFile("Output.tsv").ToList();
            //Console.WriteLine("Done 'Output.tsv'");
            //var passEngine = new FileHelperEngine<Password>();
            //var passList = passEngine.ReadFile("Files/plain_32m.tsv");
            //Console.WriteLine("Read 'plain_32m.tsv'");
            //Dictionary<string, string> emailPass = new Dictionary<string, string>();
            //foreach(var pass in passList)
            //    emailPass.Add(pass.email, pass.plain_text);
            //foreach(var cred in credsList)
            //{
            //    if (!emailPass.ContainsKey(cred.Email))
            //        emailPass.Remove(cred.Email);
            //}
            //Console.WriteLine(emailPass.Count());
           
        }
    }
}