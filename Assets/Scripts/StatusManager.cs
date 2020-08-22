using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    #region Instance

    public static StatusManager instance;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    #endregion
    
    [SerializeField] private Image socialBar;
    [SerializeField] private Image physicalBar;
    [SerializeField] private Image professionalBar;
    [SerializeField] private Image mentalBar;


    public void ChangeBar(TypeNotification typeNotification, float value)
    {
        switch (typeNotification)
        {
            case TypeNotification.Mental:
                mentalBar.fillAmount = value;
                break;
            case TypeNotification.Physical:
                physicalBar.fillAmount = value;
                break;
            case TypeNotification.Professional:
                professionalBar.fillAmount = value;
                break;
            case TypeNotification.Social:
                socialBar.fillAmount = value;
                break;
        }
    }
}
