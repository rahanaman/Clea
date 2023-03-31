using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;



public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))"; // REGEX 따옴표 0,2개로 묶인 쌍 앞에 있는 건 카운트, 1개로 끝나면 카운트X

    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };
    public static List<Dictionary<string, object>> Read(TextAsset data)
    {
        var list = new List<Dictionary<string, object>>();

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
}

public class StringParser
{
    static string NUM_PARSE = @"{[\d]*}";
    public static string ParseDesc(string desc, int[] data)
    {
        string str = desc;
        MatchCollection mc = Regex.Matches(str, NUM_PARSE);
        foreach(Match m in mc)
        {
            string value = m.Value;
            //{1}???
            int index = int.Parse(value.Trim('{').TrimEnd('}'));
            if(0 <= index && index < data.Length)
            {
                str = Regex.Replace(str, string.Concat("\\", value), data[index].ToString());
            }
        }
        return str;
    }
}