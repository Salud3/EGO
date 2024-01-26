using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int worth;
    public AudioClip soundFood;
    public AudioClip soundNotFood;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.CompareTag("Food"))
            {
                gameManager.ScorePoints(worth);
                Destroy(this.gameObject);
            }
            else if (this.CompareTag("NotFood"))
            {
                gameManager.SubtractPoints(worth);
                Destroy(this.gameObject);
            }
        }
    }
}