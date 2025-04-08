using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int currentHP;
    public bool isMain;
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
            PostBattle(collider.gameObject);
        }
    }

    void PostBattle(GameObject enemy)
    {
        if(isMain)
        {
            turnManager.PostBattle(enemy);
        }
    }
}
