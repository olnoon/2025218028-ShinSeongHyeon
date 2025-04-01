using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class QuestManager : MonoBehaviour
{
    public List<TextAsset> questFiles = new List<TextAsset>();
    [SerializeField] List<Quest> questList;
    [SerializeField] int questIndex;
    [SerializeField] bool questEnd;
    [SerializeField] bool isTyping;
    [SerializeField] GameObject questShower;
    // [SerializeField] TimeManager timeManager;

    public void ReadQuestFile()
    {
        questList.Clear();
        questIndex = 0;
        questEnd = false;

        TextAsset textFile = questFiles[0];
        questFiles.RemoveAt(0);
        StringReader stringReader = new StringReader(textFile.text);

        while(stringReader != null)
        {
            string line = stringReader.ReadLine();

            if(line == null)
                break;

            Quest questData = new Quest();
            questData.questTitle = line.Split('|')[0];
            questData.questKind = line.Split('|')[1];
            questData.questDetail = line.Split('|')[2];
            
            questShower.transform.GetChild(1).GetComponent<Text>().text = questData.questTitle;
            questList.Add(questData);
        }

        questIndex++;

        stringReader.Close();
    }
}
