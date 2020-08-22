using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "Notification", menuName = "Notifications/New Notification")]
    public class Notification : ScriptableObject
    {
        public TypeNotification typeNotification;
        public string messageNotification;
        public GameObject notificationPrefab;
        public List<Status> changeStatusFirstOption;
        public List<Status> changeStatusSecondOption;
    }
}