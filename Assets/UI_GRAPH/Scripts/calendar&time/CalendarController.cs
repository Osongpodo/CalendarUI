using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarController : MonoBehaviour
{
    public GameObject calendarPanel;
    public GameObject item;

    public TMP_Text yearNumText;
    public TMP_Text monthNumText;
    public TMP_Text label;

    const int totalDateNum = 42;
    public List<GameObject> dateItems = new List<GameObject>();


    private DateTime dateTime;
    private DateTime clickedDay;
    private DateTime thatDay;

    public static CalendarController calendarInstance;
    
    public dateEvent DateEvent;

    void Start()
    {
        calendarInstance = this;
        Vector3 startPos = item.transform.localPosition;
        dateItems.Clear();
        dateItems.Add(item);

        for (int i = 1; i < totalDateNum; i++)
        {
            GameObject items = GameObject.Instantiate(item) as GameObject;
            items.name = "day " + (i + 1).ToString();
            items.transform.SetParent(item.transform.parent);
            items.transform.localPosition = new Vector3((i % 7) * 100 + startPos.x, startPos.y - (i / 7) *160, startPos.z);

            dateItems.Add(items);
        }

        dateTime = DateTime.Now;
        clickedDay = DateTime.Now;

        CreateCalendar();

        calendarPanel.SetActive(false);
    }

    void CreateCalendar()
    {
        DateTime firstDay = dateTime.AddDays(-(dateTime.Day - 1));

        int index = (int)firstDay.DayOfWeek;

        DateTime maximumDay = DateTime.Now.AddDays(7);

        int date = 0;

        for (int i = 0; i < totalDateNum; i++)
        {
            label = dateItems[i].GetComponentInChildren<TMP_Text>();
            dateItems[i].SetActive(false);

            if (i >= index)
            {
                thatDay = firstDay.AddDays(date);
                
                if (thatDay.Month == firstDay.Month)
                {
                    dateItems[i].SetActive(true);

                    label.text = (date + 1).ToString();
                    date++;

                    int compare_result = DateTime.Compare(thatDay, maximumDay);

                    label.transform.parent.GetComponent<Button>().interactable = true;

                    if (thatDay.Year == clickedDay.Year &&
                        thatDay.Month == clickedDay.Month &&
                        thatDay.Day == clickedDay.Day)
                        label.color = Color.green;
                    else if (thatDay.Year == DateTime.Now.Year &&
                        thatDay.Month == DateTime.Now.Month &&
                        thatDay.Day == DateTime.Now.Day)
                        label.color = Color.yellow;
                    else if (compare_result <= 0)
                        label.color = Color.white;
                    else
                    {
                        label.color = Color.gray;
                        label.transform.parent.GetComponent<Button>().interactable = false;
                    }
                }
            }

        }

        yearNumText.text = dateTime.Year.ToString();
        monthNumText.text = dateTime.Month.ToString("D2");
    }


    public void OnDateItemClick(string day)
    {
        DateEvent.updateEnable = false;
        DateEvent.text_date.text = yearNumText.text + "." + monthNumText.text+"." + int.Parse(day).ToString("D2");
        clickedDay = new DateTime(int.Parse(yearNumText.text), int.Parse(monthNumText.text), int.Parse(day));
        CreateCalendar();
    }

    public void OnExitClick()
    {
        calendarPanel.SetActive(false);
        //IITP.PanelHandlerBase.Instance.SelectTime(dateTime.ToString("yyyy.MM.dd HH:mm:ss"));
    }

    public void YearPrev()
    {
        dateTime = dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        dateTime = dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        dateTime = dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        dateTime = dateTime.AddMonths(1);
        CreateCalendar();
    }
}
