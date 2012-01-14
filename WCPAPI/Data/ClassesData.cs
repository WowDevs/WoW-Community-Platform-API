﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WCPAPI
{
    [DataContract]
    public class ClassesData
    {
        #pragma warning disable 0649
        [DataMember(Name = "classes")]
        public Class[] Classes;
        #pragma warning restore 0649

        const string baseURL = "http://{0}.battle.net/api/wow/data/character/classes";

        public static ClassesData Get(string region, Locale? locale = null)
        {
            string url = String.Format(baseURL, region);

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (locale.HasValue)
                parameters.Add("locale", locale.Value.ToString());

            if (parameters.Count != 0)
                url += "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)).ToArray());

            return ApiRequest.Get<ClassesData>(url);
        }
    }

    [DataContract]
    public class Class
    {
        [DataMember(Name = "id")]
        public int Id;
        [DataMember(Name = "mask")]
        public int Mask;
        [DataMember(Name = "powerType")]
        public string PowerType;
        [DataMember(Name = "name")]
        public string Name;
    }
}
