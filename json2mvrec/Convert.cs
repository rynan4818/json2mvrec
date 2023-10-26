using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace json2mvrec
{
    internal class Convert
    {
        public void ConvertMvrec(MovementJson org, string savePath)
        {
            var meta = new MovementJson
            {
                objectCount = org.objectNames.Count,
                recordCount = org.records.Count,
                levelID = null,
                songName = null,
                serializedName = null,
                difficulty = null,
                Settings = new List<Setting>(),
                recordFrameRate = org.recordFrameRate,
                objectNames = org.objectNames,
                objectScales = new List<Scale>(),
                recordNullObjects = null
            };
            foreach (var searchSetting in org.Settings)
            {
                meta.Settings.Add(new Setting
                {
                    name = searchSetting.name,
                    type = searchSetting.type,
                    topObjectStrings = searchSetting.topObjectStrings,
                    rescaleString = searchSetting.rescaleString,
                    searchStirngs = searchSetting.searchStirngs,
                    exclusionStrings = searchSetting.exclusionStrings
                });
            }
            foreach (var item in org.objectScales)
                meta.objectScales.Add(new Scale() { x = item.x, y = item.y, z = item.z });
            try
            {
            var metaSerialized = JsonConvert.SerializeObject(meta, Formatting.None);
                using (var writer = new BinaryWriter(File.Open(savePath, FileMode.Create), Encoding.UTF8))
                {
                    writer.Write(metaSerialized);
                    foreach (var record in org.records)
                    {
                        writer.Write(record.songTIme);
                        for (int i = 0; i < org.objectNames.Count; i++)
                        {
                            writer.Write(record.posX[i]);
                            writer.Write(record.posY[i]);
                            writer.Write(record.posZ[i]);
                            writer.Write(record.rotX[i]);
                            writer.Write(record.rotY[i]);
                            writer.Write(record.rotZ[i]);
                            writer.Write(record.rotW[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public MovementJson ReadRecordFile(string path)
        {
            MovementJson result;
            var json = this.ReadAllText(path);
            try
            {
                if (json == null)
                {
                    Console.WriteLine("Json file error");
                    throw new JsonReaderException();
                }
                result = JsonConvert.DeserializeObject<MovementJson>(json);
                if (result == null)
                    Console.WriteLine("Empty json");
            }
            catch (JsonReaderException)
            {
                result = null;
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error in reading JSON");
                result = null;
            }
            return result;
        }
        public string ReadAllText(string path)
        {
            FileInfo fileInfo;
            try
            {
                fileInfo = new FileInfo(path);
            }
            catch
            {
                return null;
            }
            if (!fileInfo.Exists || fileInfo.Length == 0)
                return null;
            string result;
            try
            {
                using (var sr = new StreamReader(path))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                result = null;
            }
            return result;
        }
    }
}
