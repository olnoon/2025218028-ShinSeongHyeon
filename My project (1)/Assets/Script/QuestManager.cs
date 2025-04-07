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
        if (questFiles.Count == 0) return;

        questList.Clear();
        questIndex = 0;
        questEnd = false;

        TextAsset textFile = questFiles[0];
        questFiles.RemoveAt(0);

        using (StringReader reader = new StringReader(textFile.text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');
                if (tokens.Length < 3)
                {
                    continue;
                }

                Quest quest = new Quest
                {
                    questTitle = tokens[0],
                    questKind = tokens[1],
                    questDetail = tokens[2]
                };

                questList.Add(quest);
            }
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (questList.Count > 0)
        {
            questShower.transform.GetChild(1).GetComponent<Text>().text = questList[0].questTitle;
        }
    }

}
