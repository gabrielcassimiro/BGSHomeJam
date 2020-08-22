using System.Collections.Generic;
using Scriptable;
using UnityEngine;

public class ListNotifications : MonoBehaviour
{
    public List<NotificationObject> baseNotifications = new List<NotificationObject>();
    public List<NotificationObject> datingNotifications = new List<NotificationObject>();
    public List<NotificationObject> workingNotifications = new List<NotificationObject>();

    public NotificationObject GetNotification(bool dating, bool working)
    {
        NotificationObject notificationObject = null;
        if (dating && working && datingNotifications.Count > 0 && workingNotifications.Count > 0)
        {
            if (Random.Range(0.0f, 100.0f) >= 80.0f)
            {
                notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                    ? workingNotifications[Random.Range(0, workingNotifications.Count)]
                    : datingNotifications[Random.Range(0, datingNotifications.Count)];
            }
            else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }

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