using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int currentHP;

    void Start()
    {
        currentHP = HP;
    }
    
}
