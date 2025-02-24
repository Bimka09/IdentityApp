namespace IdentityApp.Settings
{
    public class GoogleAuthData
    {
        public const string Section = "GoogleAuth";

        public required string ClientId { get; init; }

        public required string ClientSecret { get; init; }
    }
}
