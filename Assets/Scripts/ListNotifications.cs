using System.Collections.Generic;
using Scriptable;
using UnityEngine;
using Random = UnityEngine.Random;

public class ListNotifications : MonoBehaviour
{
    public List<Notification> baseNotifications = new List<Notification>();
    public List<Notification> datingNotifications = new List<Notification>();

    public Notification GetNotification(bool dating)
    {
        Notification notification = null;
        if (dating)
        {
            notification = Random.Range(0.0f, 100.0f) < 80.0f
                ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                : datingNotifications[Random.Range(0, datingNotifications.Count)];
        }
        else
        {
            notification = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }
        return notification;
    }
}