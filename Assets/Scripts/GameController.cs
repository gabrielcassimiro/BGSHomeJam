using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using Random = UnityEngine.Random;

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
    [SerializeField] private ListNotifications listNotifications;
    [SerializeField] private Transform notificationParent;


    private void Start()
    {
        InitStatus();
        foreach (var value in playerStatus)
        {
            var fillAmount = value.Value / maxPoints;
            StatusManager.instance.ChangeBar(value.Key, fillAmount);
        }

        NewNotification();
    }

    private void InitStatus()
    {
        playerStatus.Add(TypeNotification.Mental, 50);
        playerStatus.Add(TypeNotification.Physical, 50);
        playerStatus.Add(TypeNotification.Professional, 50);
        playerStatus.Add(TypeNotification.Social, 50);
    }

    public void ChangeStatus(List<Status> status)
    {
        status.ForEach(stat =>
        {
            playerStatus[stat.typeNotification] += stat.value;
            var fillAmount = playerStatus[stat.typeNotification] / maxPoints;
            StatusManager.instance.ChangeBar(stat.typeNotification, fillAmount);
        });
        StartCoroutine(WaitNewNotification());
    }

    private void NewNotification()
    {
        
        var notification = listNotifications.GetNotification(true);
        var go = Instantiate(notification.notificationPrefab, notificationParent);
        var prefab = go.GetComponent<NotificationPrefab>();
        prefab.Init(notification);
    }

    private IEnumerator WaitNewNotification()
    {
        yield return new WaitForSeconds(0.5f);
        NewNotification();
    }
}