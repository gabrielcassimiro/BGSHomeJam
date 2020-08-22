using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPrefab : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button firstOption;
    [SerializeField] private Button secondOption;

    public void Init(Notification notification)
    {
        this.text.text = notification.messageNotification;
        this.firstOption.onClick.AddListener(() =>
        {
            GameController.Instance.ChangeStatus(notification.changeStatusFirstOption);
            Destroy(gameObject);
        });
        this.secondOption.onClick.AddListener(() =>
        {
            GameController.Instance.ChangeStatus(notification.changeStatusSecondOption);
            Destroy(gameObject);
        });
    }
}