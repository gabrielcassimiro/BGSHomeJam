using System;
using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPrefab : MonoBehaviour
{
    [SerializeField] private Text text = null;
    [SerializeField] private Text firstOptionText = null;
    [SerializeField] private Text secondOptionText = null;
    [SerializeField] private Button firstOption = null;
    [SerializeField] private Button secondOption = null;

    public void Init(NotificationObject notificationObject, Action action = null,
        Action<NotificationObject> specificAction = null)
    {
        text.text = notificationObject.messageNotification;
        firstOptionText.text = notificationObject.textFirstOption;
        secondOptionText.text = notificationObject.textSecondOption;

        if (!notificationObject.repeat)
        {
            var listNotification = GameController.Instance.GetListNotification();
            if (listNotification.baseNotifications.Contains(notificationObject))
                listNotification.baseNotifications.Remove(notificationObject);
            else if (listNotification.datingNotifications.Contains(notificationObject))
                listNotification.datingNotifications.Remove(notificationObject);
        }

        this.firstOption.onClick.AddListener(() =>
        {
            StopAllCoroutines();
            if (notificationObject.sequenceFirstOption != null) specificAction?.Invoke(notificationObject.sequenceFirstOption);
            else action?.Invoke();;
            GameController.Instance.ChangeStatus(notificationObject.changeStatusFirstOption);
            Destroy(gameObject);
        });
        this.secondOption.onClick.AddListener(() =>
        {
            StopAllCoroutines();
            if (notificationObject.sequenceSecondOption != null) specificAction?.Invoke(notificationObject.sequenceSecondOption);
            else action?.Invoke();;
            GameController.Instance.ChangeStatus(notificationObject.changeStatusSecondOption);
            Destroy(gameObject);
        });
    }
}