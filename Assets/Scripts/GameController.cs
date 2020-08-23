﻿using System.Collections;
using System.Collections.Generic;
using Enums;
using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Instance

    public static GameController Instance;

    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(this.gameObject);
    }

    #endregion

    private Dictionary<TypeNotification, int> playerStatus = new Dictionary<TypeNotification, int>();
    [SerializeField] private float maxPoints = 1000.0f;
    [SerializeField] private ListNotifications listNotifications = null;
    [SerializeField] private Transform notificationParent = null;
    [SerializeField] private DaysOfWeek daysOfWeek = DaysOfWeek.Domingo;
    [SerializeField] private int daysCount = 1;
    [SerializeField] private int notificationsCount = 0;
    [SerializeField] private Text dayNameText;
    [SerializeField] private Text dayNumberText;

    [Header("Social Status")] public bool isDating = false;
    public bool isWorking = false;
    public bool isStudying = false;


    private void Start()
    {
        InitStatus();
        SetDay();
        foreach (var value in playerStatus)
        {
            var fillAmount = value.Value / maxPoints;
            StatusManager.instance.Init(value.Key, fillAmount);
        }

        // NewNotification();
    }

    private void InitStatus()
    {
        playerStatus.Add(TypeNotification.Mental, 50);
        playerStatus.Add(TypeNotification.Physical, 50);
        playerStatus.Add(TypeNotification.Professional, 50);
        playerStatus.Add(TypeNotification.Social, 50);
    }

    public ListNotifications GetListNotification()
    {
        return listNotifications;
    }

    public void ChangeStatus(List<Status> status)
    {
        status.ForEach(stat =>
        {
            playerStatus[stat.typeNotification] += stat.value;
            var fillAmount = playerStatus[stat.typeNotification] / maxPoints;
            StatusManager.instance.ChangeBar(stat.typeNotification, fillAmount);
        });
    }

    public void NewNotification(NotificationObject notificationObject = null)
    {
        DaysManager();
        if (!notificationObject)
        {
            var notification = listNotifications.GetNotification(isDating, isWorking, isStudying);
            var go = Instantiate(notification.notificationPrefab, notificationParent);
            var prefab = go.GetComponent<NotificationPrefab>();
            prefab.Init(notification, CallEnumerator, NewSpecificNotification);
        }
        else
        {
            var go = Instantiate(notificationObject.notificationPrefab, notificationParent);
            var prefab = go.GetComponent<NotificationPrefab>();
            prefab.Init(notificationObject, CallEnumerator, NewSpecificNotification);
        }
    }

    private void DaysManager()
    {
        notificationsCount++;
        if (notificationsCount % 4 == 0)
            daysCount++;
        Debug.Log($"Resto de {notificationsCount}/{7} é {notificationsCount % 7}");
        SetDay();
    }

    private void SetDay()
    {
        switch (daysCount % 7)
        {
            case 1:
                daysOfWeek = DaysOfWeek.Domingo;
                if (dayNameText) dayNameText.text = $"{daysOfWeek.ToString()}";
                break;
            case 2:
                daysOfWeek = DaysOfWeek.Segunda;
                if (dayNameText) dayNameText.text = $"{daysOfWeek.ToString()}-Feira";
                break;
            case 3:
                daysOfWeek = DaysOfWeek.Terça;
                if (dayNameText) dayNameText.text = $"{daysOfWeek.ToString()}-Feira";
                break;
            case 4:
                daysOfWeek = DaysOfWeek.Quarta;
                if (dayNameText) dayNameText.text = $"{daysOfWeek.ToString()}-Feira";
                break;
            case 5:
                daysOfWeek = DaysOfWeek.Quinta;
                if (dayNameText) dayNameText.text = $"{daysOfWeek.ToString()}-Feira";
                break;
            case 6:
                daysOfWeek = DaysOfWeek.Sexta;
                if (dayNameText) dayNameText.text = $"{daysOfWeek.ToString()}-Feira";
                break;
            case 0:
                daysOfWeek = DaysOfWeek.Sábado;
                if (dayNameText) dayNameText.text = $"{daysOfWeek.ToString()}";
                break;
        }
        if (dayNumberText) dayNumberText.text = $"{daysCount.ToString()}";
    }

    private void NewSpecificNotification(NotificationObject notificationObject)
    {
        StartCoroutine(WaitNewNotification(notificationObject));
    }

    private void CallEnumerator()
    {
        StartCoroutine(WaitNewNotification());
    }

    private IEnumerator WaitNewNotification(NotificationObject notificationObject = null)
    {
        yield return new WaitForSeconds(1f);
        if (!notificationObject) NewNotification();
        else NewNotification(notificationObject);
    }

    public static void GameOver()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Game Over!");
    }
}