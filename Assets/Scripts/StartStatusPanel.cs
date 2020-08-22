using System.Collections.Generic;
using Scriptable;
using UnityEngine;

public class StartStatusPanel : MonoBehaviour
{
    [SerializeField] private List<NotificationObject> startNotifications = new List<NotificationObject>();
    private int _count = 0;

    private void Start()
    {
        NewNotification();
    }

    private void NewNotification()
    {
        if (_count < startNotifications.Count)
        {
            var notification = startNotifications[_count];
            var go = Instantiate(notification.notificationPrefab, gameObject.transform);
            var prefab = go.GetComponent<NotificationPrefab>();
            prefab.Init(notification, NewNotification);
        }
        else
        {
            GameController.Instance.NewNotification();
        }

        _count++;
    }
}