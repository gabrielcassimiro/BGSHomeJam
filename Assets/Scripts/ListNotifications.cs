using System.Collections.Generic;
using System.Linq;
using Scriptable;
using UnityEngine;

public class ListNotifications : MonoBehaviour
{
    public List<NotificationObject> baseNotifications = new List<NotificationObject>();
    public List<NotificationObject> datingNotifications = new List<NotificationObject>();
    public List<NotificationObject> workingNotifications = new List<NotificationObject>();
    public List<NotificationObject> studyingNotifications = new List<NotificationObject>();
    public List<NotificationObject> extraNotifications = new List<NotificationObject>();

    public bool GetSingleNotifications()
    {
        var baseNot = baseNotifications.Where(b => b.repeat == false).ToList();
        var datingNot = datingNotifications.Where(b => b.repeat == false).ToList();
        var workingNot = workingNotifications.Where(b => b.repeat == false).ToList();
        var studyingNot = studyingNotifications.Where(b => b.repeat == false).ToList();
        var extraNot = extraNotifications.Where(b => b.repeat == false).ToList();

        var value = baseNot.Count == 0 && datingNot.Count == 0 && workingNot.Count == 0 && studyingNot.Count == 0 &&
                    extraNot.Count == 0;
        return value;
    }

    public NotificationObject GetNotification(bool dating, bool working, bool studying)
    {
        NotificationObject notificationObject = null;

        // Dating, working and Studying
        if (dating && working && studying && datingNotifications.Count > 0 && workingNotifications.Count > 0 &&
            studyingNotifications.Count > 0)
        {
            if (extraNotifications.Count > 0)
            {
                var random = Random.Range(0.0f, 100.0f);

                if (random <= 40.0f)
                {
                    var rand = Random.Range(0.0f, 100.0f);
                    if (rand < 33.0f)
                        notificationObject = workingNotifications[Random.Range(0, workingNotifications.Count)];
                    else if (rand >= 33.0f && Random.Range(0.0f, 100.0f) < 66.0f)
                        notificationObject = datingNotifications[Random.Range(0, datingNotifications.Count)];
                    else if (rand >= 66.0f)
                        notificationObject = studyingNotifications[Random.Range(0, studyingNotifications.Count)];
                }
                else if (random > 40.0f && random <= 60.0f)
                    notificationObject = extraNotifications[Random.Range(0, extraNotifications.Count)];
                else
                    notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
            }
            else
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
        }
        // Dating and Working
        else if (dating && working && datingNotifications.Count > 0 && workingNotifications.Count > 0)
        {
            if (extraNotifications.Count > 0)
            {
                var random = Random.Range(0.0f, 100.0f);

                if (random <= 40.0f)
                {
                    if (Random.Range(0.0f, 100.0f) >= 80.0f)
                    {
                        notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                            ? workingNotifications[Random.Range(0, workingNotifications.Count)]
                            : datingNotifications[Random.Range(0, datingNotifications.Count)];
                    }
                }
                else if (random > 40.0f && random <= 60.0f)
                    notificationObject = extraNotifications[Random.Range(0, extraNotifications.Count)];
                else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
            }
            else
            {
                if (Random.Range(0.0f, 100.0f) >= 80.0f)
                {
                    notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                        ? workingNotifications[Random.Range(0, workingNotifications.Count)]
                        : datingNotifications[Random.Range(0, datingNotifications.Count)];
                }
                else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
            }
        }
        // Dating and Studying
        else if (dating && studying && datingNotifications.Count > 0 && studyingNotifications.Count > 0)
        {
            if (extraNotifications.Count > 0)
            {
                var random = Random.Range(0.0f, 100.0f);

                if (random <= 40.0f)
                {
                    if (Random.Range(0.0f, 100.0f) >= 80.0f)
                    {
                        notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                            ? studyingNotifications[Random.Range(0, studyingNotifications.Count)]
                            : datingNotifications[Random.Range(0, datingNotifications.Count)];
                    }
                }
                else if (random > 40.0f && random <= 60.0f)
                    notificationObject = extraNotifications[Random.Range(0, extraNotifications.Count)];
                else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
            }
            else
            {
                if (Random.Range(0.0f, 100.0f) >= 80.0f)
                {
                    notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                        ? studyingNotifications[Random.Range(0, studyingNotifications.Count)]
                        : datingNotifications[Random.Range(0, datingNotifications.Count)];
                }
                else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
            }
        }
        // Working and Studying
        else if (working && studying && workingNotifications.Count > 0 && studyingNotifications.Count > 0)
        {
            if (extraNotifications.Count > 0)
            {
                var random = Random.Range(0.0f, 100.0f);

                if (random <= 40.0f)
                {
                    if (Random.Range(0.0f, 100.0f) >= 80.0f)
                    {
                        notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                            ? studyingNotifications[Random.Range(0, studyingNotifications.Count)]
                            : workingNotifications[Random.Range(0, workingNotifications.Count)];
                    }
                }
                else if (random > 40.0f && random <= 60.0f)
                    notificationObject = extraNotifications[Random.Range(0, extraNotifications.Count)];
                else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
            }
            else
            {
                if (Random.Range(0.0f, 100.0f) >= 80.0f)
                {
                    notificationObject = Random.Range(0.0f, 100.0f) < 50.0f
                        ? studyingNotifications[Random.Range(0, studyingNotifications.Count)]
                        : workingNotifications[Random.Range(0, workingNotifications.Count)];
                }
                else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
            }
        }
        //Dating
        else if (dating && datingNotifications.Count > 0)
        {
            if (extraNotifications.Count > 0)
            {
                var random = Random.Range(0.0f, 100.0f);

                if (random <= 70.0f)
                {
                    notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                        ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                        : datingNotifications[Random.Range(0, datingNotifications.Count)];
                }
                else notificationObject = extraNotifications[Random.Range(0, extraNotifications.Count)];
            }
            else
            {
                notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                    ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                    : datingNotifications[Random.Range(0, datingNotifications.Count)];
            }
        }
        //Working
        else if (working && datingNotifications.Count > 0)
        {
            if (extraNotifications.Count > 0)
            {
                var random = Random.Range(0.0f, 100.0f);

                if (random <= 70.0f)
                {
                    notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                        ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                        : workingNotifications[Random.Range(0, workingNotifications.Count)];
                }
                else notificationObject = extraNotifications[Random.Range(0, extraNotifications.Count)];
            }
            else
            {
                notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                    ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                    : workingNotifications[Random.Range(0, workingNotifications.Count)];
            }
        }
        //Studying
        else if (studying && datingNotifications.Count > 0)
        {
            if (extraNotifications.Count > 0)
            {
                var random = Random.Range(0.0f, 100.0f);

                if (random <= 70.0f)
                {
                    notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                        ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                        : studyingNotifications[Random.Range(0, studyingNotifications.Count)];
                }
                else notificationObject = extraNotifications[Random.Range(0, extraNotifications.Count)];
            }
            else
            {
                notificationObject = Random.Range(0.0f, 100.0f) < 80.0f
                    ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                    : studyingNotifications[Random.Range(0, studyingNotifications.Count)];
            }
        }
        else
        {
            if (extraNotifications.Count > 0)
            {
                notificationObject = Random.Range(0.0f, 100.0f) <= 75.0f
                    ? baseNotifications[Random.Range(0, baseNotifications.Count)]
                    : extraNotifications[Random.Range(0, extraNotifications.Count)];
            }
            else notificationObject = baseNotifications[Random.Range(0, baseNotifications.Count)];
        }

        return notificationObject;
    }
}