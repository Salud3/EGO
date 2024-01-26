using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefab;
    [SerializeField] GameObject[] notFoodPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start()
    {
        StartCoroutine(FoodSpawn());
    }

    IEnumerator FoodSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y);
            GameObject gameObject = Instantiate(foodPrefab[Random.Range(0, foodPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
        }
    }
}
