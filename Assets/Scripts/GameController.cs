using System.Collections;
using System.Collections.Generic;
using Enums;
using Scriptable;
using UnityEngine;

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


    private void Start()
    {
        InitStatus();
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
        if (!notificationObject)
        {
            var notification = listNotifications.GetNotification(true);
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