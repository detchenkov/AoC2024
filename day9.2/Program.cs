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

Console.WriteLine(newStr.ToString());

var lastEmpty = 0;
var fileDeb = 0;
var fileLength = 0;
for (int i = newStr.Length - 1; i >= 0 ; i--)
{
    fileLength++;
    if (fileDeb == 0) fileDeb = i;
    if (newStr[i] == '.' || newStr[fileDeb] != newStr[i])
    {
        fileLength--;
        lastEmpty = -1;
        for(int j = 0; j < i; j++)
        {
            if (newStr[j] == '.' && lastEmpty != -1) continue;
            if (newStr[j] == '.' && lastEmpty == -1) lastEmpty = j;
            if (newStr[j] != '.' && lastEmpty != -1)
            {
                if (j-lastEmpty >= fileLength)
                {
                    newStr.Replace('.', newStr[fileDeb], lastEmpty, fileLength);
                    newStr.Replace(newStr[fileDeb], '.', fileDeb - fileLength+1, fileLength);
                    break;
                }
                lastEmpty = -1;
            }
        }
        fileDeb = 0;
        fileLength = 0;
        if (newStr[i] != '.')
        {
            fileDeb = i;
            fileLength++;
        }
        continue;
    }
}

Console.WriteLine(newStr.ToString());

System.Int128 sum = 0;
for (int i = 0; i < newStr.Length; i++)
{
    if (newStr[i] == '.') continue;
    sum += ((newStr[i]-'0')*i);
}

Console.WriteLine($"{sum}");
