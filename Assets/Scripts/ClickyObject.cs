using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickyObject : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private void OnMouseDown()
    {
        score++;
        Debug.Log("Clicked " + score);
    }
}
