using FileHelpers;
namespace DataCrunching
{
    [DelimitedRecord("\t")]
    [IgnoreFirst]
    public class Idip
    {
        public string id { get; set; }
        public string ip_address { get; set; }
    }
    [DelimitedRecord("\t")]
    [IgnoreFirst]
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string hash_password { get; set; }
    }
    [DelimitedRecord("\t")]
    [IgnoreEmptyLines]
    public class Password
    {
        public string Email { get; set; }
        public string Plain_text { get; set; }
    }
    [DelimitedRecord("\t")]
    [IgnoreEmptyLines]
    public class Credetianls
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string IP { get; set; }
    }
    [DelimitedRecord("\t")]
    public class Email
    {
        public string email { get; set; }
    }
}