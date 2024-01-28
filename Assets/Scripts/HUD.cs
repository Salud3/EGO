using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI points;

    void Update()
    {
        points.text = GameManager.Instance.TotalPoints.ToString();
    }
}
