using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Duk.Lightbox.Orchard
{
    public static class ListUtils
    {
        public static string ListToString(IList<string> listData)
        {
            if (listData == null || !listData.Any())
            {
                return null;
            }
            return String.Join(" ", listData);
        }

        public static IList<string> StringToList(string stringData)
        {
            if (!String.IsNullOrWhiteSpace(stringData))
            {
                return stringData.Split(new[] {" ", ","}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            return new List<string>();
        }
    }
}