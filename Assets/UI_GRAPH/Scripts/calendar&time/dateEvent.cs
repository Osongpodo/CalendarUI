using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class dateEvent : MonoBehaviour
{
    public TMP_Text text_date;
    public bool updateEnable = true;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if(updateEnable)
        {
            string date = DateTime.Now.ToString("yyyy.MM.dd");

            text_date.text = date;
        }
    }
}
