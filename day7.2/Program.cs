using System.IO;

String[] equations = File.ReadAllLines("input.txt");

System.Int128 sum = 0;

bool IsOk(System.Int128 current, System.Int128 next, System.Int128 res)
{
    if (current + next == res || current * next == res || current.ToString() + next.ToString() == res.ToString())
        return true;
    return false;
}

bool CheckList(List<System.Int128> input, System.Int128 current, System.Int128 res)
{
    if (input.Count == 1)
        return IsOk(current, input[0], res);

    if (Int128.Parse(current.ToString() + input[0].ToString()) <= res) 
        if (CheckList(input.Slice(1, input.Count - 1), Int128.Parse(current.ToString() + input[0].ToString()), res))
            return true;

    if (current + input[0] <= res) 
        if (CheckList(input.Slice(1, input.Count - 1), current + input[0], res))
            return true;

    if (current * input[0] <= res) 
        if (CheckList(input.Slice(1, input.Count - 1), current * input[0], res)) 
            return true;

    return false;
}

foreach(var equation in equations)
{
    var result = System.Int128.Parse(equation.Substring(0, equation.IndexOf(':')));
    var variables = equation.Substring(equation.IndexOf(':')+1)
            .Split(" ")?
            .Where(x => System.Int128.TryParse(x, out _))
            .Select(System.Int128.Parse)
            .ToList();

    if (CheckList(variables, 0, result))
        sum += result;
    
}
Console.WriteLine($"{sum}");
