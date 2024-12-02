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
right.Sort();

var sum = 0;

for (var i = 0; i< left.Count(); i++)
{
    sum += Math.Abs(left[i] - right[i]);
}

File.WriteAllText("output.txt", ""+sum);
