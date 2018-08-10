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
}