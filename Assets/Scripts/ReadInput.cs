using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public TMP_InputField inputField;
    private string input;

    // Start is called before the first frame update
    void Start()
    {
        inputField.characterLimit = 3;
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
    }
}
