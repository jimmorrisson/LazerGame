using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct objectsSpawnInformation
{
    public int positionX;
    public int positionZ;
    public int time;
}
public class Level
{
    public string levelName { get; set; }
    public int levelIndex { get; set; }
    public uint UnlockedTowers;
    public int StartingGold;
    public List<objectsSpawnInformation> objects;
    public Level(string levelString)
    {
        objects = new List<objectsSpawnInformation>();
        string[] allLines = levelString.Split('\n');
        string[] firstLineValue = allLines[0].Split(',');
        levelName = firstLineValue[0];
        levelIndex = int.Parse(firstLineValue[1]);
        UnlockedTowers = uint.Parse(firstLineValue[2]);
        StartingGold = int.Parse(firstLineValue[3]);

        for (int i = 1; i < allLines.Length; i++)
        {
            if (allLines[i] == "")
                break;
            string[] objectInfo = allLines[i].Split(',');
            objectsSpawnInformation o = new objectsSpawnInformation();
            o.positionX = int.Parse(objectInfo[0]);
            o.positionZ = int.Parse(objectInfo[1]);
            o.time = int.Parse(objectInfo[2]);

            objects.Add(o);
            //string[] allLinesValues = s.Split(',');
            //levelName = allLinesValues[0];
            //levelIndex = int.Parse(allLinesValues[1]);
            //UnlockedTowers = uint.Parse(allLinesValues[2]);
            //StartingGold = int.Parse(allLinesValues[3]);
        }
    }
}
