using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DW.Save
{
    public class SaveOrLoad
    {
        public static Datas data = new Datas();

        public static void SaveData()
        {
            string path = Path.Combine(Application.dataPath, "Datas.json");

            string stringJson = JsonUtility.ToJson(data);
            File.WriteAllText(path, stringJson);
        }

        public static void LoadData()
        {
            string path = Path.Combine(Application.dataPath, "Datas.json");

            if (File.Exists(path))
            {
                string stringJson = File.ReadAllText(path);
                JsonUtility.FromJsonOverwrite(stringJson, data);
            }
            else return;
        }
    }
}
