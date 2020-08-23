using System;
using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPrefab : MonoBehaviour
{
    [SerializeField] private Text title = null;
    [SerializeField] private Text text = null;
    [SerializeField] private Text firstOptionText = null;
    [SerializeField] private Text secondOptionText = null;
    [SerializeField] private Button firstOption = null;
    [SerializeField] private Button secondOption = null;

    public void Init(NotificationObject notificationObject, Action action = null,
        Action<NotificationObject> specificAction = null)
    {
        if (title) title.text = notificationObject.titleNotification;
        if (text) text.text = notificationObject.messageNotification;
        if (firstOptionText) firstOptionText.text = notificationObject.textFirstOption;
        if (secondOptionText) secondOptionText.text = notificationObject.textSecondOption;
        ListNotifications listNotifications = GameController.Instance.GetListNotification();
        if (notificationObject.newNotification)
        {
            if (!listNotifications.extraNotifications.Contains(notificationObject.newNotificationObject))
            {
                listNotifications.extraNotifications.Add(notificationObject.newNotificationObject);
            }
        }

        if (!notificationObject.repeat)
        {
            var listNotification = GameController.Instance.GetListNotification();
            if (listNotification.baseNotifications.Contains(notificationObject))
                listNotification.baseNotifications.Remove(notificationObject);
            else if (listNotification.datingNotifications.Contains(notificationObject))
                listNotification.datingNotifications.Remove(notificationObject);
            else if (listNotification.workingNotifications.Contains(notificationObject))
                listNotification.workingNotifications.Remove(notificationObject);
            else if (listNotification.studyingNotifications.Contains(notificationObject))
                listNotification.studyingNotifications.Remove(notificationObject);
            else if (listNotification.extraNotifications.Contains(notificationObject))
                listNotification.extraNotifications.Remove(notificationObject);
        }

        this.firstOption.onClick.AddListener(() =>
        {
            if (notificationObject.firstOptionAffect)
            {
                if (notificationObject.affectingDating)
                    GameController.Instance.isDating = notificationObject.datingStatus;
                if (notificationObject.affectWork)
                    GameController.Instance.isWorking = notificationObject.employmentStatus;
                if (notificationObject.affectsStudies)
                    GameController.Instance.isStudying = notificationObject.studiesStatus;
            }

            StopAllCoroutines();
            if (notificationObject.sequenceFirstOption != null)
                specificAction?.Invoke(notificationObject.sequenceFirstOption);
            else action?.Invoke();
            ;
            GameController.Instance.ChangeStatus(notificationObject.changeStatusFirstOption);
            Destroy(gameObject);
        });
        this.secondOption.onClick.AddListener(() =>
        {
            if (notificationObject.secondOptionAffect)
            {
                if (notificationObject.affectingDating)
                    GameController.Instance.isDating = notificationObject.datingStatus;
                if (notificationObject.affectWork)
                    GameController.Instance.isWorking = notificationObject.employmentStatus;
                if (notificationObject.affectsStudies)
                    GameController.Instance.isStudying = notificationObject.studiesStatus;
            }

            StopAllCoroutines();
            if (notificationObject.sequenceSecondOption != null)
                specificAction?.Invoke(notificationObject.sequenceSecondOption);
            else action?.Invoke();
            ;
            GameController.Instance.ChangeStatus(notificationObject.changeStatusSecondOption);
            Destroy(gameObject);
        });
    }
}