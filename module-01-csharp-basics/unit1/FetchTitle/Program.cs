using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading.Tasks;

async Task MainAsync()
{
    string url = "https://dotnet.microsoft.com";
    Console.WriteLine("=== Synchronous ===");
    var swSync = Stopwatch.StartNew();
    string htmlSync = new HttpClient().GetStringAsync(url).Result;
    string titleSync = Regex.Match(htmlSync, "<title>(.*?)</title>").Groups[1].Value;
    swSync.Stop();
    Console.WriteLine($"Title: {titleSync}");
    Console.WriteLine($"Sync elapsed: {swSync.ElapsedMilliseconds} ms\n");

    Console.WriteLine("=== Asynchronous ===");
    var swAsync = Stopwatch.StartNew();
    string titleAsync = await FetchTitleAsync(url);
    swAsync.Stop();
    Console.WriteLine($"Title: {titleAsync}");
    Console.WriteLine($"Async elapsed: {swAsync.ElapsedMilliseconds} ms");
}

async Task<string> FetchTitleAsync(string url)
{
    using HttpClient client = new();
    string html = await client.GetStringAsync(url);
    var match = Regex.Match(html, "<title>(.*?)</title>", RegexOptions.IgnoreCase);
    return match.Groups.Count > 1 ? match.Groups[1].Value : "(no title)";
}

// 程式入口
await MainAsync();
