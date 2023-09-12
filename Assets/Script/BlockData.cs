using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BlockData", menuName = "Scriptable Object/BlockData", order = int.MaxValue)]
public class BlockData : ScriptableObject
{
    public Sprite blockImage;
    public string blockName;
    public int hp;
    public float dropPer;
    public int score;
}