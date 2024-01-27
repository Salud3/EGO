using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager: MonoBehaviour
{
    public GameObject[] obstacles;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float TimePrevSpawn;
    [SerializeField] float spawnTime;
    [Header("HarcoreMode")]
    public float Hardcoretimer;
    [SerializeField] bool hardcore;

    // Start is called before the first frame update
    void Update()
    {
        if (GMaster1.Instance.startG)
        {

            if (hardcore)
            {
                Hardcoretimer += Time.deltaTime;

                if (Hardcoretimer >= (TimePrevSpawn * .65))
                {

                    Hardcoretimer = 0;
                    SpawnCall();
                    if (count >= 3 && TimePrevSpawn > 4)
                    {
                        Debug.Log("Spawn normal minus");
                        TimePrevSpawn -= 1;
                    }

                }


                if (GMaster1.Instance.Speed < 12)
                {
                    SwitchHardcoreSpawn();
                    Hardcoretimer = 0;
                }


            }
            else
            {
                spawnTime += Time.deltaTime;

                if (spawnTime >= TimePrevSpawn && (GMaster1.Instance.xRun > 50.5f))
                {
                    spawnTime = 0;
                    SpawnCall();
                    if (count >= 3 && TimePrevSpawn > 4)
                    {
                        Debug.Log("Spawn normal minus");
                        TimePrevSpawn -= 1;
                    }

                }


                if (GMaster1.Instance.Speed > 12 && count > 4)
                {
                    SwitchHardcoreSpawn();
                    spawnTime = 0;
                }

            }

        }
    }

    void SwitchHardcoreSpawn()
    {
        hardcore = !hardcore;
    }

    bool CanSpawn(){
        return GMaster1.Instance.xRun > 50.5f && !GMaster1.Instance.finished;
    }

    void SpawnCall()
    {
        if (CanSpawn())
        {
            Spawn();
        }
 

    }

    int count;
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        int randomobs = Random.Range(0, 3);

        GameObject obs = obstacles[randomobs];

        Instantiate(obs, transform.position + new Vector3(randomX, transform.position.y, 0), transform.rotation);
        count++;
    }

}
