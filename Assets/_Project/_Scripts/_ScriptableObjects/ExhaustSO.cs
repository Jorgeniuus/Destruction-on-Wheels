using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "exhaust", menuName = "ScriptableObjects/exhaust", order = 4)]
public class ExhaustSO : ScriptableObject
{
    public string name;
    public Sprite image;
    public Renderer carExhaust;

    public int indexToSelectCustom;
    public int value;
    public bool locked = true;
}
