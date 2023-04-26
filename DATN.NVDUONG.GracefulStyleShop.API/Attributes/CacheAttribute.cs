//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.DependencyInjection;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.Serialization;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//public class RedisCacheAttribute : Attribute, IAsyncActionFilter
//{
//    private readonly int _timeToLeaveSeconds;
//    //private string _keySearch;

//    public RedisCacheAttribute(int timeToLeaveSeconds = 3600)
//    {
//        _timeToLeaveSeconds = timeToLeaveSeconds;
//    }

//    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//    {
//        JObject cacheMemory = null;
//        UserToken userToken = null;
//        if (context.Controller.GetType().IsSubclassOf(typeof(Authentication)))
//            userToken = ((Authentication)context.Controller).UserToken;

//        var cacheKey = await GenerateCacheKeyFromRequest(context.HttpContext.Request, userToken);

//        if (!string.IsNullOrEmpty(cacheKey) && RCache.cache.KeyExists(cacheKey))
//            RCache.GetData(cacheKey, out cacheMemory);

//        if (cacheMemory != null)
//        {
//            context.Result = CommonFunctions.GetCacheResponse(cacheMemory);
//            //RCache.KeyExpire(cacheKey, _timeToLeaveSeconds);
//            // Count cache hit
//            //Utils.AddActivityLog(context.HttpContext.Request.Path);
//            return;
//        }

//        var excutedContext = await next(); // Thực thi api

//        if (excutedContext.Result is ObjectResult objectResult)
//            if (objectResult.Value.GetType().GetProperty("isOk").GetValue(objectResult.Value, null).ObjToStr().ToLower().Equals("true"))
//            {
//                RCache.SetDataCalmeCase(cacheKey, objectResult.Value, _timeToLeaveSeconds);
//            }
//    }

//    private string SerializeCamelCase(object obj)
//    {
//        var jsonSerializerSettings = new JsonSerializerSettings
//        {
//            ContractResolver = new CamelCasePropertyNamesContractResolver()
//        };
//        return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
//    }
//    private async Task<string> GenerateCacheKeyFromRequest(HttpRequest request, UserToken userToken = null)
//    {
//        var keyBuilder = new StringBuilder();
//        if (userToken != null) keyBuilder.Append(userToken.UserID);
//        keyBuilder.Append($"{request.Path.ToString().Replace("/api/", "").Replace("service", "")}");
//        string subkey = "";
//        if (request.Method == "GET")
//            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
//                subkey = subkey + $"|{ key}-{value}";
//        else
//        {
//            request.Body.Position = 0;
//            using var streamReader = new StreamReader(request.Body);
//            subkey = await streamReader.ReadToEndAsync();
//            request.Body.Position = 0;
//        }


//        if (!string.IsNullOrEmpty(subkey))
//        {
//            Convertor.StringToMD5(subkey, out subkey);
//            keyBuilder.Append(subkey);
//        }
//        return keyBuilder.ToString();
//    }
//}
