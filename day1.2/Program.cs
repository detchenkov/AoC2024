using System.IO;

String line;
List<int> left = new List<int>();
List<int> right = new List<int>();

StreamReader sr = new StreamReader("input.txt");

line = sr.ReadLine();
while (line != null)
{
    string[] words = line.Split("   ");
    left.Add(Int32.Parse(words[0]));
    right.Add(Int32.Parse(words[1]));

    line = sr.ReadLine();
}
sr.Close();

left.Sort();

var sum = 0;

foreach (var item in left)
{
    sum += item * right.FindAll(
        delegate(int e)
        {
            return e == item;
        }).Count();
}

File.WriteAllText("output.txt", ""+sum);
