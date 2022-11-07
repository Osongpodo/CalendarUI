using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class timeEvent : MonoBehaviour
{
    public TMP_Text time;

    public Slider timer;

    public GameObject popup;

    public dateEvent DateEvent;

    const int MIN_TIME = 0;
    const int MAX_TIME = 86400;

    void Start()
    {
        OnTodayClick();
    }

    private void Update_Time()
    {
        string txt = DateTime.Now.ToString("HH:mm:ss");
        time.text = txt;
    }

    public void valueChanged(Slider slider, TMP_Text text)
    {
        int diff = MAX_TIME - MIN_TIME;
        int value = MIN_TIME + (int)(diff * slider.value);

        string h, m, s;
        int hh = value / 3600;
        int mm = (value % 3600) / 60;
        int ss = (value % 60);

        h = startZero(hh);
        m = startZero(mm);
        s = startZero(ss);

        text.text = h + ":" + m + ":" + s;

        CancelInvoke("Update_Time");
    }

    public void OnTodayClick()
    {
        if (IsInvoking("Update_Time"))
            CancelInvoke("Update_Time");
        InvokeRepeating("Update_Time", 0, 0.2f);

        DateTime dt = DateTime.Now;
        timer.onValueChanged.AddListener(delegate { valueChanged(timer, time); });

        int HH = Int32.Parse(dt.ToString("HH"));
        int mm = Int32.Parse(dt.ToString("mm"));
        int ss = Int32.Parse(dt.ToString("ss"));

        DateEvent.updateEnable = true;
        //IITP.PanelHandlerBase.Instance.ResetTime();
        timer.value = (float)(HH * 3600 + mm * 60 + ss) / MAX_TIME;
    }

    public string startZero(int num)
    {
        return (num < 10) ? "0" + num : "" + num;
    }
}
