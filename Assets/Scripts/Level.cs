using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int brickCount;

    // Update is called once per frame
    void Update()
    {
        if (brickCount <= 0)
        {
            LoadNextScene();
        }
    }

    public void IncreaseBrickCount()
    {
        brickCount++;
    }

    public void DecreaseBrickCount()
    {
        brickCount--;
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
}
