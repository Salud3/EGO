using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int worth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.CompareTag("Food"))
            {
                GameManager.Instance.ScorePoints(worth);
                AudioManager.Instance.PlaySounds("Munch");
                Destroy(this.gameObject);
            }
            else if (this.CompareTag("NotFood"))
            {
                GameManager.Instance.SubtractPoints(worth);
                Destroy(this.gameObject);
                AudioManager.Instance.PlaySounds("Bonk");
            }
            else if (this.CompareTag("Floor"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
