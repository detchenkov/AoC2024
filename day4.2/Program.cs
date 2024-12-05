using System.IO;

String[] lines = File.ReadAllLines("input.txt");

var count = 0;
var nb_lines = lines.Count();

for (var i = 0; i < nb_lines; i++)
{
    var line_len = lines[i].Length;
    for (var j = 0; j < line_len; j++)
    {
        if (lines[i][j] != 'A') continue;
        if (j + 1 >= line_len) continue;
        if (j - 1 < 0) continue;
        if (i - 1 < 0) continue;
        if (i + 1 >= nb_lines) continue;

        if (lines[i-1][j-1] != 'M' && lines[i-1][j-1] != 'S')
            continue;
        if (lines[i+1][j+1] != 'M' && lines[i+1][j+1] != 'S')
            continue;
        if (lines[i-1][j+1] != 'M' && lines[i-1][j+1] != 'S')
            continue;
        if (lines[i+1][j-1] != 'M' && lines[i+1][j-1] != 'S')
            continue;

        if (lines[i-1][j-1] == 'M' && lines[i+1][j+1] == 'S')
        {
            if (lines[i+1][j-1] == 'M' && lines[i-1][j+1] == 'S')
                count++;
            if (lines[i+1][j-1] == 'S' && lines[i-1][j+1] == 'M')
                count++;
        }
        if (lines[i-1][j-1] == 'S' && lines[i+1][j+1] == 'M')
        {
            if (lines[i+1][j-1] == 'M' && lines[i-1][j+1] == 'S')
                count++;
            if (lines[i+1][j-1] == 'S' && lines[i-1][j+1] == 'M')
                count++;
        }
    }
}

File.WriteAllText("output.txt", $"{count}");

