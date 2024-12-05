using System.IO;

String line;

StreamReader sr = new StreamReader("input.txt");

var rulesList = new List<(int left, int right)>();
bool loading_rules = true;

var sum = 0;

line = sr.ReadLine();
while (line != null)
{
    if (line == String.Empty)
    {
        loading_rules = false;
        line = sr.ReadLine();
        continue;
    }

    if (loading_rules)
    {
        string[] rule = line.Split("|");
        rulesList.Add((Int32.Parse(rule[0]),Int32.Parse(rule[1])));
        line = sr.ReadLine();
        continue;
    }
    var update = line.Split(",")?.Select(Int32.Parse)?.ToList();
    bool ok = true;

    for (var i = 0; i < update.Count(); i++)
    {
        var rules = rulesList.FindAll(
            delegate((int left, int right) rule)
            {
                return rule.left == update[i] || rule.right == update[i];
            });

        var query = update.Where((number, index) => 
            {
                if (index == i) return false;
                if (index < i)
                {
                    foreach(var rule in rules)
                    {
                        if(number == rule.right)
                            return true;
                    }
                }
                else
                {
                    foreach(var rule in rules)
                    {
                        if(number == rule.left)
                            return true;
                    }
                }
                return false;
            });

        foreach(var e in query)
        {
            ok = false;
        }
    }

    if (!ok)
    {
        update.Sort(delegate(int x, int y)
        {
            var rules = rulesList.FindAll(
            delegate((int left, int right) rule)
            {
                return (rule.left == x || rule.right == x) && (rule.left == y || rule.right == y);
            });

            foreach(var rule in rules)
            {
                if (rule.left == x && rule.right == y) return -1;
                if (rule.left == y && rule.right == x) return 1;
            }
            return 0;
        });
        sum += update[update.Count/2];
    }

    line = sr.ReadLine();
}
sr.Close();

File.WriteAllText("output.txt", $"{sum}");
