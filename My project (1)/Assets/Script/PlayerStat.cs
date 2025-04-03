using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int currentHP;
    [SerializeField] bool isMain;
    [SerializeField] TurnManager turnManager;

    void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

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
        if(isMain)
        {
            turnManager.PostBattle();
            Debug.Log("아직 해당기능은 완전하지 않습니다.");
        }
    }
}
