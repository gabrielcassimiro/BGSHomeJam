using System.Collections.Generic;
using Scriptable;
using UnityEngine;
using Random = UnityEngine.Random;

public class ListNotifications : MonoBehaviour
{
    public List<NotificationObject> baseNotifications = new List<NotificationObject>();
    public List<NotificationObject> datingNotifications = new List<NotificationObject>();

    public NotificationObject GetNotification(bool dating)
    {
        NotificationObject notificationObject = null;
        if (dating && datingNotifications.Count > 0)
        {
            notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                : datingNotifications[Random.Range(0, datingNotifications.Count)];
        }
        else
        {
            notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }
        return notificationObject;
    }
}