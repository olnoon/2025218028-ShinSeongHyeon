using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.VisualScripting;
using System.Linq;

public class Storyteller : MonoBehaviour
{
    //뜯어온 코드에서 수정을 가했습니다.
    [SerializeField] List<Story> storyList;
    [SerializeField] int epNum;
    [SerializeField] int storyIndex;
    [SerializeField] bool storyEnd;
    [SerializeField] GameObject dialogue;       // 대화가 표시될 텍스트 UI
    [SerializeField] bool isTyping;
    [SerializeField] StoryManager storyManager;
    [SerializeField] TimeManager timeManager;
    [SerializeField] ActManager actManager;
    [SerializeField] bool isQuest;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        storyList = new List<Story>();
        ReadStoryFile();
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    SkipStory();
                }
                else
                {
                    MoveCharacter();
                    WatchStory();
                }
            }
        }
    }
    void MoveCharacter()
    {
        if(storyList[storyIndex].actKind == "move")
        {
            actManager.TimeLineStart(storyList[storyIndex].tellerName);
        }
    }
    void WatchStory()
    {
        if(!isTyping)
        {
            storyIndex++;
            if(storyIndex < storyList.Count)
            {
                StartCoroutine(TypingScript());
            }
            else if(storyIndex == storyList.Count)
            {
                EndDialogue();
            }
        }
        else
        {
            UpdateDialogue(storyList[storyIndex].detail);
            isTyping = false;
        }
    }
    
    public void ReadStoryFile()
    {
        storyList.Clear();
        storyIndex = 0;
        storyEnd = false;

        if (storyManager.storyFiles.Count == 0)
        {
            return;
        }

        TextAsset textFile = storyManager.storyFiles[0];
        storyManager.storyFiles.RemoveAt(0);

        using (StringReader reader = new StringReader(textFile.text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');

                if (tokens.Length < 4)
                {
                    continue;
                }

                Story storyData = new Story
                {
                    tellerName = tokens[0],
                    detail = tokens[1],
                    actKind = tokens[2]
                };

                isQuest = tokens[3].Trim().ToLower() == "true";

                storyList.Add(storyData);
            }
        }

        OnChatWindow();
        StartCoroutine(TypingScript());
        epNum++;
    }

    void OnChatWindow()
    {
        timeManager.Pause(true);
        dialogue.SetActive(true);
    }

    void OffChatWindow()
    {
        timeManager.Pause(false);
        dialogue.SetActive(false);
    }
    void UpdateDialogue(string line)
    {
        dialogue.transform.GetChild(0).GetComponent<Text>().text = storyList[storyIndex].tellerName;
        dialogue.transform.GetChild(1).GetComponent<Text>().text = line;
    }

    void EndDialogue()
    {
        storyIndex = 0;
        if(isQuest)
        {
            GameObject.Find("QuestManager").GetComponent<QuestManager>().ReadQuestFile();
        }
        OffChatWindow();
    }

    void SkipStory()
    {
        EndDialogue();
    }
    public IEnumerator TypingScript()
    {
        isTyping = true;
        for(int i = 0; i < storyList[storyIndex].detail.ToCharArray().Count() + 1; i++)
        {
            if(isTyping)
            {
                UpdateDialogue(storyList[storyIndex].detail.Substring(0, i));
                yield return new WaitForSecondsRealtime(0.1f);
            }
            else
            {
                yield break;
            }
        }
        isTyping = false;
    }
}
