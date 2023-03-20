using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public List<Sprite> levelSprites;
    public List<byte> playersPhoto;
    public int spriteIndex;
    public PuzzleSizes puzzleSize;
}
