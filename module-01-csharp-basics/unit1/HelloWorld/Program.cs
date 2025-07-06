using System;
using System.Net.Http;

Console.WriteLine($"[Sync] ThreadId = {Environment.CurrentManagedThreadId}");
Console.WriteLine("Hello, C#!");

Console.WriteLine("Fetching https://dotnet.microsoft.com/ ...");
int length = await GetContentLengthAsync("https://dotnet.microsoft.com");
Console.WriteLine($"Bytes received = {length}");

async Task<int> GetContentLengthAsync(string url)
{
    using HttpClient client = new();
    Console.WriteLine($"[Async] ThreadId(before await) = {Environment.CurrentManagedThreadId}");
    string html = await client.GetStringAsync(url);
    Console.WriteLine($"[Async] ThreadId(after await) = {Environment.CurrentManagedThreadId}");
    return html.Length;
}

