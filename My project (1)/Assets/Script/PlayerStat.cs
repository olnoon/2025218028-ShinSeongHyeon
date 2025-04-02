using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int currentHP;

    void Start()
    {
        currentHP = HP;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<EnemyStat>() != null)
        {
            PostBattle();
        }
    }

    void PostBattle()
    {
        Debug.Log("나중에 다른 씬으로 넘어가게 할 예정입니다.");
    }
}
