using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMaster2 : MonoBehaviour
{
    [SerializeField] TiroP rito;
    [SerializeField] GameObject Brazo;
    [SerializeField] GameObject Dentadura;
    [SerializeField] float puntuacionObtenida;
    [SerializeField] Animator animator;

    private void Start()
    {
        StartCoroutine(ActivarBrazo());
    }

    void End()
    {
        animator.SetTrigger("FadeIn");
    }

    IEnumerator ActivarBrazo()
    {
        yield return new WaitForSeconds(1.8f);
        Brazo.SetActive(true);
        Dentadura.SetActive(true);
    }
}
