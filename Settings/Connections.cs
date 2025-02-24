namespace IdentityApp.Settings
{
    public class Connections
    {
        public const string Section = "ConnectionStrings";

        public required string IdentityDB { get; init; }

        public required string ProductsDB { get; init; }
    }
}
