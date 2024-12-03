using System.IO;
using System.Text.RegularExpressions;

String input;

string pattern = @"mul\((?'left'\d{1,3}),(?'right'\d{1,3})\)";
var res = 0;
StreamReader sr = new StreamReader("input.txt");

input = sr.ReadLine();

while (input != null)
{

    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.None))
    {
        GroupCollection groups = match.Groups;

        res += Int32.Parse(groups["left"].Value) * Int32.Parse(groups["right"].Value);
    }
    input = sr.ReadLine();
}
sr.Close();

File.WriteAllText("output.txt", $"{res}");
