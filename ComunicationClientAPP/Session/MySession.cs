namespace ComunicationClientAPP.Session
{
    public class MySession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MySession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetUserValue(string key, string value)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            httpContext?.Session.SetString(key, value);
        }
        public string GetUserValue(string key)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            return httpContext?.Session.GetString(key) ?? string.Empty;
        }
        public void RemoveSession(string key)
        {
            var httpContext = _httpContextAccessor.HttpContext;
             httpContext?.Session.Remove(key);
        }
    }
}
