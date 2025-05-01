using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocateMaterix
{
    public List<Transform> locates;
}

public class GameManager : MonoBehaviour
{
    public List<LocateMaterix> locateMaterixes;
}
