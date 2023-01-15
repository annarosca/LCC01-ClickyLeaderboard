using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickyObject : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        gameManager.IncreaseScore();
    }
}
