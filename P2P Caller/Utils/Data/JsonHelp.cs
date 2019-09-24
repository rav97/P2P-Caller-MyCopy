using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

class JsonHelp
{
    public static List<HistoryRecord> DeserializeHistory(string JSON)
    {
        try
        {
            if (JSON != "")
            {
                JArray a = JArray.Parse(JSON);
                return a.ToObject<List<HistoryRecord>>();
            }
            else
                return new List<HistoryRecord>();
        }
        catch(Exception e)
        {
            return new List<HistoryRecord>();
        }
    }
    public static List<Contact> DeserializeContacts(string JSON)
    {
        try
        {
            if (JSON != "")
            {
                JArray a = JArray.Parse(JSON);
                return a.ToObject<List<Contact>>();
            }
            else
                return new List<Contact>();
        }
        catch(Exception e)
        {
            return new List<Contact>();
        }
    }
}
