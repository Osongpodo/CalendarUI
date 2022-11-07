using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CalendarDays : MonoBehaviour
{
    public TMP_Text text;
    public GameObject clicked;

    public void OnDateItemClick()
    {
        CalendarController.calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<TMP_Text>().text);

        ////Debug.Log(EventSystem.current.currentSelectedGameObject);
        
        //if(clicked == EventSystem.current.currentSelectedGameObject)
        //{
        //    clicked.GetComponentInChildren<TMP_Text>().color = Color.green;
        //}
 
    }

}
