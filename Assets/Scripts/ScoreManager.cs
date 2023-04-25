using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;

    private BoxCollider2D savedVictimsArea;

    int score = 0;

    private void Awake()
    {
        instance = this;
        savedVictimsArea = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " Points";
    }

    public void AddPoints()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";

    }

    public void PlaceSavedVictim(GameObject victim)
    {
        Vector3 newPosition = new Vector3(Random.Range(savedVictimsArea.bounds.min.x, savedVictimsArea.bounds.max.x), Random.Range(savedVictimsArea.bounds.min.y, savedVictimsArea.bounds.max.y), 0f);
        victim.transform.position = newPosition;
    }
}
