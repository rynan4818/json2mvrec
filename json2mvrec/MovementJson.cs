using System.Collections.Generic;

namespace json2mvrec
{
    public class MovementJson
    {
        public int objectCount { get; set; }
        public int recordCount { get; set; }
        public string levelID { get; set; }
        public string songName { get; set; }
        public string serializedName { get; set; }
        public string difficulty { get; set; }
        public List<Setting> Settings { get; set; }
        public int recordFrameRate { get; set; }
        public List<string> objectNames { get; set; }
        public List<Scale> objectScales { get; set; }
        public List<NUllObject> recordNullObjects { get; set; }
        public List<Record> records { get; set; }
    }
    public class Setting
    {
        public string name { get; set; }
        public string type { get; set; }
        public List<string> topObjectStrings { get; set; }
        public string rescaleString { get; set; }
        public List<string> searchStirngs { get; set; }
        public List<string> exclusionStrings { get; set; }
    }
    public class Record
    {
        public float songTIme { get; set; }
        public List<float> posX { get; set; }
        public List<float> posY { get; set; }
        public List<float> posZ { get; set; }
        public List<float> rotX { get; set; }
        public List<float> rotY { get; set; }
        public List<float> rotZ { get; set; }
        public List<float> rotW { get; set; }
    }
    public class Scale
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }
    public class NUllObject
    {
        public float songTime { get; set; }
        public int objIndex { get; set; }
    }
}