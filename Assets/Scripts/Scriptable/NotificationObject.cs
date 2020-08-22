using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "Notification", menuName = "Notifications/New Notification")]
    public class NotificationObject : ScriptableObject
    {
        public TypeNotification typeNotification;
        public string messageNotification;
        public GameObject notificationPrefab;
        public string textFirstOption;
        public List<Status> changeStatusFirstOption;
        public NotificationObject sequenceFirstOption;
        public string textSecondOption;
        public List<Status> changeStatusSecondOption;
        public NotificationObject sequenceSecondOption;
        public bool repeat;
    }
}