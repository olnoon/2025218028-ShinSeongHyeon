using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //뜯어온 코드에서 수정을 가했습니다.
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public bool IsPause = false;

    public void Pause(bool isStop)
    {
        IsPause = isStop;
        int num = isStop ? 0 : 1;
        Time.timeScale = num;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
