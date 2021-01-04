using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        scoreText.SetText(score + "");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void increaseScore()
    {
        score += 100;
        scoreText.SetText(score + "");
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
