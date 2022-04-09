namespace FindJobWebApi.Response
{
    public static class ResponseConvertor
    {
        public static Dictionary<string, Object> GetResult(Object status, Object response)
        {
            return new Dictionary<string, Object>()
            {
                {"status", status},
                {"data", response }
            };
        }
    }
}
