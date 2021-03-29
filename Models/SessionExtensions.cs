using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace GBCSporting2021_TheDevelopers.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<C>(this ISession session, string key, C value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static C GetObject<C>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return (string.IsNullOrEmpty(value)) ? default(C) : JsonConvert.DeserializeObject<C>(value);
        }
    }
}
