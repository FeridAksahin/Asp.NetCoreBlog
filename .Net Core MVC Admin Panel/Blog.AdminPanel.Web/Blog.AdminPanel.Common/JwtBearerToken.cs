namespace Blog.AdminPanel.Common
{
    public class JwtBearerToken
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
