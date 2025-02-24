using System.IO;
using System.Text;

String line;

StreamReader sr = new StreamReader("input.txt");

line = sr.ReadLine();
sr.Close();

StringBuilder newStr = new StringBuilder();
var fileId = 0;
for (int i = 0; i < line.Length; i++)
{
    if (i%2 == 0)
    {
        for(int j = line[i] - '0'; j > 0; j--)
            newStr.Append((char)(fileId+'0'));
        fileId++;
    }
    else
    {
        for(int j = line[i] - '0'; j > 0; j--)
            newStr.Append('.');
    }
}

var lastEmpty = 0;

for (int i = newStr.Length - 1; i >= 0 ; i--)
{
    if (newStr[i] == '.') continue;
    for(int j = lastEmpty; j < i; j++)
    {
        if (newStr[j] == '.')
        {
            lastEmpty = j;
            newStr[j] += newStr[i];
            newStr[i] = (char)(newStr[j] - newStr[i]);
            newStr[j] -= newStr[i];
            break;
        }
    }
}

System.Int128 sum = 0;
for (int i = 0; i < newStr.Length; i++)
{
    if (newStr[i] == '.') continue;
    sum += ((newStr[i]-'0')*i);
}

Console.WriteLine($"{sum}");
