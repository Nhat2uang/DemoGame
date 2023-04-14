using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "ResourseData")]
public class Resource : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int life;
    public int cycle;
    public int price;
}
