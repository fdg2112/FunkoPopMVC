using System.Configuration;


namespace Data
{
    public class Connection
    {
        public static string cn = ConfigurationManager.ConnectionStrings["string"].ToString();
    }
}
