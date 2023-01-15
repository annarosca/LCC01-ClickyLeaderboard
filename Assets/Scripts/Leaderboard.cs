using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        }
    }
}
