using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings")]

public class Settings : ScriptableObject {

    [Range (0,10)]
    public int amountOfPieces;
    [Range(0,3.5f)]
    public float size;

    public int spinSpeed;
    public int delecerationPerSecond;

    public int playerRotateSpeed;


    public List<ContentCreator> rewards;
}
