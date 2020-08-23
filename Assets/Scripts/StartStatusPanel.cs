using System.Collections;
using System.Collections.Generic;
using Scriptable;
using UnityEngine;

public class StartStatusPanel : MonoBehaviour
{
    [SerializeField] private List<NotificationObject> startNotifications = new List<NotificationObject>();
    private int _count = 0;
    [SerializeField] private float timeToNewNotification = 0.75f;

    public void NewNotification()
    {
        if (_count < startNotifications.Count)
        {
            var notification = startNotifications[_count];
            var go = Instantiate(notification.notificationPrefab, gameObject.transform);
            var prefab = go.GetComponent<NotificationPrefab>();
            prefab.Init(notification, CallNewNotification);
        }
        else
        {
            GameController.Instance.CallEnumerator();
        }

        _count++;
    }

    private void CallNewNotification()
    {
        StartCoroutine(NewNotificationCoroutine());
    }

    private IEnumerator NewNotificationCoroutine()
    {
        yield return new WaitForSeconds(timeToNewNotification);
        NewNotification();
    }
}