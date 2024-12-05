using System.IO;

String[] lines = File.ReadAllLines("input.txt");

var count = 0;
var nb_lines = lines.Count();

for (var i = 0; i < nb_lines; i++)
{
    var line_len = lines[i].Length;
    for (var j = 0; j < line_len; j++)
    {
        if (lines[i][j] != 'X') continue;
        //horizontal
        if (j + 3 < line_len)
        {
            if (lines[i].Substring(j, 4) == "XMAS")
                count++;
            //diag r-t
            if (i - 3 >= 0)
            {
                if (lines[i-1][j+1] == 'M' && lines[i-2][j+2] == 'A' && lines[i-3][j+3] == 'S')
                    count++;
            }
            //diag r-b
            if (i + 3 < nb_lines)
            {
                if (lines[i+1][j+1] == 'M' && lines[i+2][j+2] == 'A' && lines[i+3][j+3] == 'S')
                    count++;
            }
        }
        //horizontal backwards
        if (j - 3 >= 0)
        {
            if (lines[i].Substring(j-3, 4) == "SAMX")
                count++;
            // diag l-t
            if (i - 3 >= 0)
            {
                if (lines[i-1][j-1] == 'M' && lines[i-2][j-2] == 'A' && lines[i-3][j-3] == 'S')
                    count++;
            }
            // diag l-b
            if (i + 3 < nb_lines)
            {
                if (lines[i+1][j-1] == 'M' && lines[i+2][j-2] == 'A' && lines[i+3][j-3] == 'S')
                    count++;
            }
        }
        //vertical
        if (i + 3 < nb_lines)
        {
            if (lines[i+1][j] == 'M' && lines[i+2][j] == 'A' && lines[i+3][j] == 'S')
                count++;
        }
        //vertical backwards
        if (i - 3 >= 0)
        {
            if (lines[i-1][j] == 'M' && lines[i-2][j] == 'A' && lines[i-3][j] == 'S')
                count++;
        }

    }
}

File.WriteAllText("output.txt", $"{count}");
