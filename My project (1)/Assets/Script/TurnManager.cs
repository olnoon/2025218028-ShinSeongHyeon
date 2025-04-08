using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerPoses;
    [SerializeField] List<bool> isContainPlayerPoses;
    [SerializeField] List<GameObject> enemyPoses;
    [SerializeField] List<bool> isContainEnemyPoses;
    [SerializeField] PartyManager partyManager;
    [SerializeField] List<GameObject> globalizeEnemys;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PostBattle(GameObject enemy)
    {
        globalizeEnemys.Add(enemy);
        DontDestroyOnLoad(enemy);
        SceneManager.LoadScene("BattleScene");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "BattleScene")
        {
            SetPlayerPos();
            SetEnemyPos();
            PlacePlayerLoop();
            PlaceEnemyLoop();
        }
    }

    void SetPlayerPos()
    {
        playerPoses.Add(GameObject.Find("FrontPlayerPos1"));
        playerPoses.Add(GameObject.Find("FrontPlayerPos2"));
        playerPoses.Add(GameObject.Find("FrontPlayerPos2"));
        playerPoses.Add(GameObject.Find("BackPlayerPos1"));
        playerPoses.Add(GameObject.Find("BackPlayerPos2"));
        playerPoses.Add(GameObject.Find("BackPlayerPos3"));
        isContainPlayerPoses = new List<bool>(new bool[6]);
    }
    
    void SetEnemyPos()
    {
        enemyPoses.Add(GameObject.Find("FrontEnemyPos1"));
        enemyPoses.Add(GameObject.Find("FrontEnemyPos2"));
        enemyPoses.Add(GameObject.Find("FrontEnemyPos2"));
        enemyPoses.Add(GameObject.Find("BackEnemyPos1"));
        enemyPoses.Add(GameObject.Find("BackEnemyPos2"));
        enemyPoses.Add(GameObject.Find("BackEnemyPos3"));
        isContainEnemyPoses = new List<bool>(new bool[6]);
    }

    void PlacePlayerLoop()
    {
        for (int i = 0; i < partyManager.partyMembers.Count; i++)
        {
            GameObject partyMember = partyManager.partyMembers[i];
            
            for (int j = 0; j < playerPoses.Count; j++)
            {
                if(isContainPlayerPoses[j])
                {
                    continue;
                }
                GameObject playerPos = playerPoses[j];
                partyMember.GetComponent<PlayerMove>().isAnchored = true;
                partyMember.transform.position = playerPos.transform.position;
                isContainPlayerPoses[j] = true;
                break;
            }
        }
    }
    
    void PlaceEnemyLoop()
    {
        for (int i = 0; i < globalizeEnemys.Count; i++)
        {
            GameObject globalizeEnemy = globalizeEnemys[i];
            
            for (int j = 0; j < enemyPoses.Count; j++)
            {
                if(isContainEnemyPoses[j])
                {
                    continue;
                }
                GameObject enemyPos = enemyPoses[j];
                globalizeEnemy.GetComponent<EnemyMove>().isAnchored = true;
                globalizeEnemy.transform.position = enemyPos.transform.position;
                isContainEnemyPoses[j] = true;
                break;
            }
        }
    }
}
