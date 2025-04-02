using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ActorID
{
    public string name;
    public TimelineAsset timeline;
    public PlayableDirector playableDirector;
}
//TODO 새롭게 TXT파일만들어서 활용하는게 좋을 듯
public class ActManager : MonoBehaviour
{
    [SerializeField] List<ActorID> actorIDs;

    public void TimeLineStart(string characterName)
    {
        foreach(ActorID actorID in actorIDs)
        {
            if(actorID.name == characterName)
            {
                actorID.playableDirector.playableAsset = actorID.timeline; // 타임라인 할당
                actorID.playableDirector.Play(); 
            }
        }
    }
}
