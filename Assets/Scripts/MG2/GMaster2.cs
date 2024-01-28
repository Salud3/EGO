using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GMaster2 : MonoBehaviour
{
    public static GMaster2 Instance;
    [SerializeField] TiroP rito;
    [SerializeField] GameObject Brazo;
    [SerializeField] GameObject Dentadura;
    [SerializeField] float puntuacionObtenida;
    [SerializeField] Image charging;
    [SerializeField] Sprite sprite;

    private void Start()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(ActivarBrazo());
    }

    public void End()
    {

        charging.sprite = sprite;
        Animator animator = charging.GetComponent<Animator>();
        animator.SetTrigger("In");
        StartCoroutine(StartChangeScene());
    }

    IEnumerator StartChangeScene()
    {
        yield return new WaitForSeconds(3.2f);
        GameManager.Instance.SceneLoad(SceneManager.GetActiveScene().buildIndex + 1);

    }
    IEnumerator ActivarBrazo()
    {
        yield return new WaitForSeconds(5.1f);
        Brazo.SetActive(true);
        Dentadura.SetActive(true);
    }
}
