using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score1 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + scoreValue;
    }
}
