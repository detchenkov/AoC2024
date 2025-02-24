using System.IO;

String[] input = File.ReadAllLines("input.txt");
bool[,] antinodes = new bool[input[0].Length, input.Count()];

antinodes.Initialize();

for (int line = 0; line < input.Count(); line++)
{
    for (int pos = 0; pos < input[line].Length; pos++)
    {
        var current = input[line][pos];
        if (current == '.') continue;

        for (int i = 0; i < input.Count(); i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                if (i==line && j==pos) continue;
                if (input[i][j] != current) continue;

                float k = ((float)i-line)/(j-pos);
                if (k < 0)
                {
                    var y = Math.Max(i,line) + (Math.Max(i,line) - Math.Min(i,line));
                    var x = Math.Min(j,pos) - (Math.Max(j,pos) - Math.Min(j,pos));

                    if (x >= 0 && y >= 0 && x < input[i].Length && y < input.Count())
                    {
                        antinodes[y,x] = true;
                    }

                    y = Math.Min(i,line) - (Math.Max(i,line) - Math.Min(i,line));
                    x = Math.Max(j,pos) + (Math.Max(j,pos) - Math.Min(j,pos));

                    if (x >= 0 && y >= 0 && x < input[i].Length && y < input.Count())
                    {
                        antinodes[y,x] = true;
                    }
                }
                else
                {
                    var y = Math.Min(i,line) - (Math.Max(i,line) - Math.Min(i,line));
                    var x = Math.Min(j,pos) - (Math.Max(j,pos) - Math.Min(j,pos));

                    if (x >= 0 && y >= 0 && x < input[i].Length && y < input.Count())
                    {
                        antinodes[y,x] = true;
                    }

                    y = Math.Max(i,line) + (Math.Max(i,line) - Math.Min(i,line));
                    x = Math.Max(j,pos) + (Math.Max(j,pos) - Math.Min(j,pos));

                    if (x >= 0 && y >= 0 && x < input[i].Length && y < input.Count())
                    {
                        antinodes[y,x] = true;
                    }
                }
            }
        }
    }
}

var count = 0;

foreach(var e in antinodes)
    if (e) count++;

Console.WriteLine($"{count}");
