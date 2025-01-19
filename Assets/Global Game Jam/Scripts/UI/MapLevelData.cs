using UnityEngine;

[CreateAssetMenu(fileName = "Map",menuName = "ScriptableObject/Map Level")]
public class MapLevelData : ScriptableObject
{
    public int level = 1;
    public int maxBubble;
    public int maxDiamond;
}