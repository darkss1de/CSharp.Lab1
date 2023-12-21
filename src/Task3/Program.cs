using System;
using System.Collections.Generic;
using System.Xml;

/// <summary>
///  Класс Event представляющий событие в журнале
/// </summary>
class Event
{
    public string Date { get; set; } = null!;
    public string Result { get; set; } = null!;
    public string IpFrom { get; set; } = null!;
    public string Method { get; set; } = null!;
    public string UrlTo { get; set; } = null!;
    public string Response { get; set; } = null!;
}

/// <summary>
///  Класс Log представляющий журнал событий
/// </summary>
class Log
{
    public List<Event> Events { get; set; }

    public Log()
    {
        Events = new List<Event>();
    }
}

/// <summary>
///  Статический класс для преобразования XML в объект Log
/// </summary>
static class XmlParser
{
    public static Log ParseXml(string xml)
    {
        Log log = new Log();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);

        XmlNodeList eventNodes = xmlDoc.SelectNodes("/log/event");
        foreach (XmlNode eventNode in eventNodes)
        {
            Event logEvent = new Event();

            logEvent.Date = eventNode.Attributes["date"].Value.Trim();
            logEvent.Result = eventNode.Attributes["result"].Value.Trim();
            logEvent.IpFrom = eventNode.SelectSingleNode("ip-from").InnerText.Trim();
            logEvent.Method = eventNode.SelectSingleNode("method").InnerText.Trim();
            logEvent.UrlTo = eventNode.SelectSingleNode("url-to").InnerText.Trim();
            logEvent.Response = eventNode.SelectSingleNode("response").InnerText.Trim();

            log.Events.Add(logEvent);
        }

        return log;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string xml = @"<log>
<event date='27/May/1999:02:32:46' result='success'>
<ip-from>195.151.62.18</ip-from>
<method>GET</method>
<url-to>/mise/</url-to>
<response>200</response>
</event>
<event date='27/May/1999:02:41:47' result='success'>
<ip-from>195.209.248.12</ip-from>
<method>GET</method>
<url-to>soft.htm</url-to>
<response>200</response>
</event>
<event date='27/May/1999:02:32:46' result='success'>
<ip-from>195.151.62.18</ip-from>
<method>GET</method>
<url-to>/mise/</url-to>
<response>200</response>
</event>
<event date='27/May/1999:02:41:47' result='success'>
<ip-from>195.209.248.12</ip-from>
<method>GET</method>
<url-to>soft.htm</url-to>
<response>200</response>
</event>
</log>";

        Log log = XmlParser.ParseXml(xml);

        // Выводим информацию о событиях из журнала
        foreach (Event logEvent in log.Events)
        {
            Console.WriteLine("Date: " + logEvent.Date);
            Console.WriteLine("Result: " + logEvent.Result);
            Console.WriteLine("IP From: " + logEvent.IpFrom);
            Console.WriteLine("Method: " + logEvent.Method);
            Console.WriteLine("URL To: " + logEvent.UrlTo);
            Console.WriteLine("Response: " + logEvent.Response);
            Console.WriteLine();
        }
    }
}
