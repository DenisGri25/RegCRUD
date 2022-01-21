namespace RegCRUD.Utility
{
    public static class ConnectionString
    {
        private static string cName = @"Data Source=.\MSSQLSERVER01;Initial Catalog=regcrudDB;Integrated Security=True";

        public static string CName => cName;
    }
}