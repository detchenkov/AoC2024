﻿using System.IO;
using System.Text.RegularExpressions;

String input;

string pattern = @"(?'do'do\(\).*?)?mul\((?'left'\d{1,3}),(?'right'\d{1,3})\)|(?'do'don\'t\(\).*?)mul\((?'left'\d{1,3}),(?'right'\d{1,3})\)";
var res = 0;
bool to_do = true;
StreamReader sr = new StreamReader("input.txt");

input = sr.ReadLine();

while (input != null)
{
    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.None))
    {
        GroupCollection groups = match.Groups;

        if (groups["do"].Value != null && groups["do"].Value != "")
        {
            to_do = !(groups["do"].Value.Substring(0,3) == "don");
        }
        if (to_do)
            res += Int32.Parse(groups["left"].Value) * Int32.Parse(groups["right"].Value);
    }
    input = sr.ReadLine();
}
sr.Close();

File.WriteAllText("output.txt", $"{res}");

