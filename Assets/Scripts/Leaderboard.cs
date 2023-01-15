using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private float templateHeight = 35f;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreListContainer");
        //entryTemplate = transform.Find("highscoreEntryTemplate");
        Debug.Log(entryContainer);
        Debug.Log(entryTemplate);

        entryTemplate.gameObject.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryRectTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "th"; break;

                case 1: rankString = "1st"; break;
                case 2: rankString = "2nd"; break;
                case 3: rankString = "3rd"; break;
            }

            int score = Random.Range(1, 99);

            string name = "ABC";
            entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().text = rankString;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = score.ToString();
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = name;
        }
    }
}
