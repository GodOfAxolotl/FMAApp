﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMAApp
{
    public static class ContainerHandler
    {

        public static List<string> cardridges = new List<string>();


        public static void setup()
        {
            cardridges.Clear();
            for (int i = 0; i < 8; i++)
            {
                cardridges.Add("Zutat " + i.ToString());
            }
        }

        public static string getIngByIndex(int idx)
        {
            if(idx < 8)
                return cardridges[idx];

            return "null";
        }

        public static string ConvertToJson()
        {
            List<string> clonedList = new List<string>(cardridges);
            return JsonConvert.SerializeObject(clonedList, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
    }

}
