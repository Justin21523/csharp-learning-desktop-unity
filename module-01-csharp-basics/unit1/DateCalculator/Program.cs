// See https://aka.ms/new-console-template for more information
using System;

// 取得今天日期
DateTime today = DateTime.Now;
Console.WriteLine($"Today: {today:yyyy-MM-dd}");

// 計算自 2000-01-01 起的天數
DateTime start = new DateTime(2000, 1, 1);
double days = (today - start).TotalDays;
Console.WriteLine($"Days since 2000-01-01: {days:N0}");

