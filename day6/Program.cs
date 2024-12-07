using System.IO;
using System.Text;

String[] lines = File.ReadAllLines("input.txt");

var count = 0;
var nb_lines = lines.Count();

char[] dir = new char[4] {'<','^','>','v'};

bool exit = false;

(int pos, int line) pos;

pos.line = Array.FindIndex(lines, line => line.IndexOfAny(dir) != -1);
pos.pos = lines[pos.line].IndexOfAny(dir);
var current = Array.FindIndex(dir, el => el == lines[pos.line][pos.pos]);

int next;
while (!exit) 
{
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
        if (lines[pos.line][next] == '#')
        {
            current++;
            current = current % 4;
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
        if (lines[next][pos.pos] == '#')
        {
            current++;
            current = current % 4;
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
        if (lines[pos.line][next] == '#')
        {
            current++;
            current = current % 4;
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
        if (lines[next][pos.pos] == '#')
        {
            current++;
            current = current % 4;
            continue;
        }
        pos.line = next;
    }
}

foreach(var line in lines)
{
    foreach(var ch in line)
    {
        if (ch == 'X')
            count++;
    } 
}

File.WriteAllText("output.txt", $"{count}");
