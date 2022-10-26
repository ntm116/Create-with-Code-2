using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Text CounterText;
    private int score;
    private ObjectPooler pooler;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pooler = GetComponent<ObjectPooler>();
        StartGame();
    }

    public void UpdateScore(int scoreToAdd)
    {
        if (scoreToAdd > 0)
            score += scoreToAdd;

        CounterText.text = "Score: " + score;
    }

    void StartGame()
    {
        foreach (GameObject ball in pooler.pooledObjects)
        {
            ball.transform.position = RandomV3();
            ball.SetActive(true);
        }
    }

    private Vector3 RandomV3()
    {
        return new Vector3(0, Random.Range(20, 35), Random.Range(-4, 4));
    }
}
