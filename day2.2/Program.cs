using System.IO;

bool isLevelsOk(List<int> input)
{
    bool is_ok = true;
    bool is_growing = false;
    bool is_decreasing = false;
    int? prev = null;

    foreach (var current in input) 
    {
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

    return (is_ok && (is_growing ^ is_decreasing));
}

String line;

StreamReader sr = new StreamReader("input.txt");

var sum = 0;

line = sr.ReadLine();
while (line != null)
{
    var levels = line.Split(" ")?.Where(x => int.TryParse(x, out _))
            .Select(int.Parse)
            .ToList();
    
    if (isLevelsOk(levels))
    {
        sum++;
    }
    else
    {
        for (int i = 0;i < levels.Count(); i++)
        {
            int[] tempLevels = new int[levels.Count()];
            levels.CopyTo(tempLevels);

            var temp = tempLevels.Where((v, idx) => idx != i).ToList();
            if(isLevelsOk(temp))
            {
                sum++;
                break;
            }
        }
    }
    line = sr.ReadLine();
}
sr.Close();

File.WriteAllText("output.txt", ""+sum);
