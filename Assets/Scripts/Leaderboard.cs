using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private float templateHeight = 35f;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreListContainer");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ score = 23, name = "ABC" },
            new HighscoreEntry{ score = 34, name = "DFG" },
            new HighscoreEntry{ score = 14, name = "HIJ" },
            new HighscoreEntry{ score = 45, name = "KLM" },
            new HighscoreEntry{ score = 59, name = "NOP" }
        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryRectTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString = rank switch
        {
            1 => "1st",
            2 => "2nd",
            3 => "3rd",
            _ => rank + "th",
        };
        int score = highscoreEntry.score;

        string name = highscoreEntry.name;

        entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().text = rankString;
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = score.ToString();
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);

    }

    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
