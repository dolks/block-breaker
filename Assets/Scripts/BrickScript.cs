using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakParticlesVFX;
    [SerializeField] Sprite[] crackedSprites;
    Level level;
    GameState gameState;
    int timesHit = 0;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameState = FindObjectOfType<GameState>();
        if (tag == "Breakable")
        {
            level.IncreaseBrickCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if (tag == "Breakable")
        {
            if (timesHit > crackedSprites.Length)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                AddParticles();
                Destroy(gameObject);
                gameState.increaseScore();
                level.DecreaseBrickCount();
            }
            else
            {
                ShowNextCrackedSprite();
            }
        }
        
    }

    private void ShowNextCrackedSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = crackedSprites[spriteIndex];
    }

    private void AddParticles()
    {
        GameObject particles = Instantiate(breakParticlesVFX, transform.position, transform.rotation);
        Destroy(particles, 2);
    }


}
