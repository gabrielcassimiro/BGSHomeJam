using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPrefab : MonoBehaviour
{
    [SerializeField] private Text text = null;
    [SerializeField] private Button firstOption = null;
    [SerializeField] private Button secondOption = null;

    public void Init(Notification notification)
    {
        this.text.text = notification.messageNotification;
        this.firstOption.onClick.AddListener(() =>
        {
            StopAllCoroutines();

            GameController.Instance.ChangeStatus(notification.changeStatusFirstOption);
            Destroy(gameObject);
        });
        this.secondOption.onClick.AddListener(() =>
        {
            StopAllCoroutines();
            GameController.Instance.ChangeStatus(notification.changeStatusSecondOption);
            Destroy(gameObject);
        });
    }
}