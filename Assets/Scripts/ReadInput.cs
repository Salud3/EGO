using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadInput : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI pointsText;

    public TMP_InputField inputField;
    public GameObject panelScore;
    public Animator anim;

    private string input;

    // Start is called before the first frame update
    void Start()
    {
        inputField.characterLimit = 3;
        pointsText.text = ("Your final score: ") + GameManager.Instance.TotalPoints.ToString();

        if(panelScore != null)
        {
            panelScore.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string name)
    {
        if(name.Length > 3)
        {
            input = name.Substring(0, 3);
        }
        else
        {
            input = name;
        }
        Debug.Log(input);
        GameManager.Instance.SetName(input);

        if(panelScore != null)
        {
            panelScore.SetActive(false);

            StartCoroutine(ActivateCreditsAfterPanelDisables());
        }
    }

    IEnumerator ActivateCreditsAfterPanelDisables()
    {
        yield return new WaitUntil(() => !panelScore.activeSelf);
        if (anim != null)
        {
            anim.SetTrigger("Credits");
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
