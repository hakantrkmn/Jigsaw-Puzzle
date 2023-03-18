using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelDatas : ScriptableObject
{
    public List<Sprite> levelSprites;
    public List<byte> playersPhoto;
    public int spriteIndex;
}
