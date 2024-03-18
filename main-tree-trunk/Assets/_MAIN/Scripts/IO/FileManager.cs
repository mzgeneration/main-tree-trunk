using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager
{
    public static List<string> ReadTextFile(string filePath, bool includeBlankLine = true)
    {
        if (!filePath.StartsWith('/'))
            filePath = FilePaths.root + filePath;

        List<string> lines = new List<string>();
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (includeBlankLine || !string.IsNullOrWhiteSpace(line))
                        lines.Add(line);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Debug.LogError($"File not found: '{ex.FileName}'");
        }

        return lines;
    }
    public static List<string> ReadTextAsset(string filePath, bool includeBlankLine = true)
    {
        return null;
    }
}