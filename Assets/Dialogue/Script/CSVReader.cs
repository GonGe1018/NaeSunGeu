    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using UnityEngine;
    using Application = UnityEngine.Device.Application;

    public class CSVReader
    {
        static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
        static char[] TRIM_CHARS = { '\"' };

        public static List<Dictionary<string, object>> Read(string file)
        {

            //프로젝트 내부 streamingAssets 폴더 내부 경로만 읽을 수 있습니다.
            //Application.persistentDataPath

            // string path;
            //
            // path = Application.persistentDataPath + '/' + file;
            
            // #if UNITY_ANDROID
            // path = "jar:file://" + Application.dataPath + "!/assets/" + file;
            // #elif UNITY_EDITOR
            // path = Application.streamingAssetsPath + '/' + file;
            // #endif
            
            // StreamReader SR = new StreamReader(path);
            // string result = "";
            // result = SR.ReadToEnd();
            // SR.Close();

            file = file.Replace(".csv", "");

            var list = new List<Dictionary<string, object>>();
            TextAsset data = Resources.Load (file) as TextAsset;

            var lines = Regex.Split (data.text, LINE_SPLIT_RE);

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
