using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PartyManager : MonoBehaviour
{
    public List<GameObject> partyMembers;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
