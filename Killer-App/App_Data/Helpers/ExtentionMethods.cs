﻿using System.Collections.Generic;

namespace Killer_App.App_Data.Helpers
{
    public static class ExtentionMethods
    {
        public static string Join<T>(this List<T> list, string seperator)
        {
            return string.Join(seperator, list);
        }
    }
}