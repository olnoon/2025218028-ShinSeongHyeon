using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PostBattle()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
