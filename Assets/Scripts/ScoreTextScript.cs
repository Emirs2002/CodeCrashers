using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int coffeeAmount;
    
    void Start()
    { 
        coffeeAmount=0;
        text = GetComponent<TextMeshProUGUI>();
    }

  
    void Update()
    {
        text.text = coffeeAmount.ToString();
    }
}
