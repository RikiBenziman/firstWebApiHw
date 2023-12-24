using Entities;
using Services;

namespace webApiShopSite.MiddleWare
{
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext,IRatingService _ratingService)
        {
            Rating rating = new Rating
            {
                Host = httpContext.Request.Headers.Host.ToString(),
                Method = httpContext.Request.Method.ToString(),
                Path = httpContext.Request.Path.ToString(),
                Referer = httpContext.Request.Headers.Referer.ToString(),
                UserAgent = httpContext.Request.Headers.UserAgent.ToString(),
                RecordDate = DateTime.Now
            };
            //•	HOST - כתובת האתר בה אנו גולשים כעת
            //•	METHOD - המתודה אליה נגשנו)
            //•	[PATH] URL ה-אליו בוצעה הפניה
            //•	REFERER - הדף ממנו התבצעה הפניה
            //•	USER_AGENT - מכיל את שם הדפדפן, גירסתו, מערכת ההפעלה ושפתה
            //•	RECORD_DATE -תאריך הרישום לרייטינג
            _ratingService.creatRatingAsync(rating); 
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
