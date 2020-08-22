using System.Collections.Generic;
using Scriptable;
using UnityEngine;

public class ListNotifications : MonoBehaviour
{
    public List<NotificationObject> baseNotifications = new List<NotificationObject>();
    public List<NotificationObject> datingNotifications = new List<NotificationObject>();
    public List<NotificationObject> workingNotifications = new List<NotificationObject>();
    public List<NotificationObject> studyingNotifications = new List<NotificationObject>();

    public NotificationObject GetNotification(bool dating, bool working, bool studying)
    {
        NotificationObject notificationObject = null;
        if (dating && working && studying && datingNotifications.Count > 0 && workingNotifications.Count > 0 &&
            studyingNotifications.Count > 0)
        {
            if (Random.Range(0.0f, 100.0f) >= 50.0f)
            {
                var rand = Random.Range(0.0f, 100.0f);
                if (rand < 33.0f)
                    notificationObject = workingNotifications[Random.Range(0, workingNotifications.Count)];
                else if (rand >= 33.0f && Random.Range(0.0f, 100.0f) < 66.0f)
                    notificationObject = datingNotifications[Random.Range(0, datingNotifications.Count)];
                else if (rand >= 66.0f)
                    notificationObject = studyingNotifications[Random.Range(0, studyingNotifications.Count)];
            }
            else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }
        else if (dating && working && datingNotifications.Count > 0 && workingNotifications.Count > 0)
        {
            if (Random.Range(0.0f, 100.0f) >= 80.0f)
            {
                notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                    ? workingNotifications[Random.Range(0, workingNotifications.Count)]
                    : datingNotifications[Random.Range(0, datingNotifications.Count)];
            }
            else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }
        else if (dating && studying && datingNotifications.Count > 0 && studyingNotifications.Count > 0)
        {
            if (Random.Range(0.0f, 100.0f) >= 80.0f)
            {
                notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                    ? studyingNotifications[Random.Range(0, studyingNotifications.Count)]
                    : datingNotifications[Random.Range(0, datingNotifications.Count)];
            }
            else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }
        else if (working && studying && workingNotifications.Count > 0 && studyingNotifications.Count > 0)
        {
            if (Random.Range(0.0f, 100.0f) >= 80.0f)
            {
                notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                    ? studyingNotifications[Random.Range(0, studyingNotifications.Count)]
                    : workingNotifications[Random.Range(0, workingNotifications.Count)];
            }
            else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }
        else if (dating && datingNotifications.Count > 0)
        {
            notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                : datingNotifications[Random.Range(0, datingNotifications.Count)];
        }
        else if (working && datingNotifications.Count > 0)
        {
            notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                : workingNotifications[Random.Range(0, workingNotifications.Count)];
        }
        else if (studying && datingNotifications.Count > 0)
        {
            notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                : studyingNotifications[Random.Range(0, studyingNotifications.Count)];
        }
        else
        {
            notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }

        return notificationObject;
    }
}