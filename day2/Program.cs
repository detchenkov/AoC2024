using System.IO;

String line;

StreamReader sr = new StreamReader("input.txt");

var sum = 0;
bool is_ok;
bool is_growing;
bool is_decreasing;
int? prev;

line = sr.ReadLine();
while (line != null)
{
    is_ok = true;
    is_growing = false;
    is_decreasing = false;
    
    prev = null;

    string[] levels = line.Split(" ");
    foreach (var e in levels) 
    {
        var current = Int32.Parse(e);
        if (prev == null)
        {
            prev = current;
            continue;
        }

        int diff = current - prev.Value;
        if (Math.Abs(diff) > 3 || Math.Abs(diff) < 1)
        {
            is_ok = false;
            break;
        }
        if (diff > 0) 
            is_growing = true;
        else 
            is_decreasing = true;

        prev = current;
    }
    line = sr.ReadLine();

    if (is_ok && (is_growing ^ is_decreasing))
        sum++;
}
sr.Close();

File.WriteAllText("output.txt", ""+sum);
