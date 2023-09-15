using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        // initialize variables before you use them
        //if i had initialized isGameActive after the StartCoroutine(method), the game will break
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
