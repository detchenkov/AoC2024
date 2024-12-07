using System.IO;
using System.Text;

String[] lines = File.ReadAllLines("input.txt");

var count = 0;
var nb_lines = lines.Count();

char[] dir = new char[4] {'<','^','>','v'};

bool exit = false;
bool was_new = false;
int passed_without_new = 0;
int next;

(int pos, int line) start_pos;
(int pos, int line) pos;

start_pos.line = Array.FindIndex(lines, line => line.IndexOfAny(dir) != -1);
start_pos.pos = lines[start_pos.line].IndexOfAny(dir);
var start_direction = Array.FindIndex(dir, el => el == lines[start_pos.line][start_pos.pos]);

for (int ll = 0; ll < lines.Count(); ll++)
{
    for(int j = 0; j < lines[ll].Length; j++)
    {
        pos = start_pos;
        var current = start_direction;

        if (lines[ll][j] == '#' || (ll == start_pos.line && j == start_pos.pos))
            continue;

        for (int i = 0; i < lines.Count(); i++)
            lines.SetValue(lines[i].Replace('X','.').Replace('O','.'), i);

        StringBuilder ns = new StringBuilder(lines[ll]);
        ns[j] = 'O';
        lines.SetValue(ns.ToString(), ll);

        exit = false;
        was_new = false;
        passed_without_new = 0;

        while (!exit) 
        {
            if (lines[pos.line][pos.pos] != 'X') was_new = true;

            StringBuilder sr = new StringBuilder(lines[pos.line]);
            sr[pos.pos] = 'X';
            lines.SetValue(sr.ToString(), pos.line);

            if (current == 0)
            {
                //going left
                next = pos.pos - 1;
                if (next < 0)
                {
                    exit = true;
                    break;
                }
                if (lines[pos.line][next] == '#' || lines[pos.line][next] == 'O')
                {
                    current++;
                    current = current % 4;
                    if (!was_new)
                        passed_without_new++;
                    if (!was_new && passed_without_new > 3)
                    {
                        count++;
                        // Console.WriteLine();
                        // foreach(var e in lines)
                        //     Console.WriteLine(e);
                        // Console.WriteLine();
                        break;
                    }
                    was_new = false;
                    continue;
                }
                pos.pos = next;
            }
            else if (current == 1)
            {
                //going top
                next = pos.line - 1;
                if (next < 0)
                {
                    exit = true;
                    break;
                }
                if (lines[next][pos.pos] == '#' || lines[next][pos.pos] == 'O')
                {
                    current++;
                    current = current % 4;
                    if (!was_new)
                        passed_without_new++;
                    if (!was_new && passed_without_new > 3)
                    {
                        count++;
                        // Console.WriteLine();
                        // foreach(var e in lines)
                        //     Console.WriteLine(e);
                        // Console.WriteLine();
                        break;
                    }
                    was_new = false;
                    continue;
                }
                pos.line = next;
            }
            else if (current == 2)
            {
                //right
                next = pos.pos + 1;
                if (next >= lines[pos.line].Length)
                {
                    exit = true;
                    break;
                }
                if (lines[pos.line][next] == '#' || lines[pos.line][next] == 'O')
                {
                    current++;
                    current = current % 4;
                    if (!was_new)
                        passed_without_new++;
                    if (!was_new && passed_without_new > 3)
                    {
                        count++;
                        // Console.WriteLine();
                        // foreach(var e in lines)
                        //     Console.WriteLine(e);
                        // Console.WriteLine();
                        break;
                    }
                    was_new = false;
                    continue;
                }
                pos.pos = next;
            }
            else if (current == 3)
            {
                //down
                next = pos.line + 1;
                if (next >= lines.Count())
                {
                    exit = true;
                    break;
                }
                if (lines[next][pos.pos] == '#' || lines[next][pos.pos] == 'O')
                {
                    current++;
                    current = current % 4;
                    if (!was_new)
                        passed_without_new++;
                    if (!was_new && passed_without_new > 3)
                    {
                        count++;
                        // Console.WriteLine();
                        // foreach(var e in lines)
                        //     Console.WriteLine(e);
                        // Console.WriteLine();
                        break;
                    }
                    was_new = false;
                    continue;
                }
                pos.line = next;
            }
        }
    }
}

File.WriteAllText("output.txt", $"{count}");
