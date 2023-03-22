using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Punctuation : MonoBehaviour
{

    private float points;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = points.ToString("0");
    }

    public void SumarPoints(float enterPoints)
    {
        points += enterPoints;
    }
}
