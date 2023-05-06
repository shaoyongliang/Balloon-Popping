using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    private int score = 0;
    public static Score instance;
    public TMP_Text ScoreText;
    [SerializeField] private AudioSource BlowupSound;
    private GameObject balloon;
    bool soundplayed = false;


    // Start is called before the first frame update
    void Start()
    {

        DisplayScore();

    }

    void Awake()
    {
        if (balloon == null)
            balloon = GameObject.FindGameObjectWithTag("Balloon");
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (balloon == null && !soundplayed)
        {
            BlowupSound.Play();
            soundplayed = true;
        }
    }

    public void DisplayScore()
    {
        ScoreText.text = "Score: " + score.ToString();
    }



    public void IncreaseScore(int v)
    {
        BlowupSound.Play();
        score += v;
        ScoreText.text = "Score:" + score.ToString();
    }


}
