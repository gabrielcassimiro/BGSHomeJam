using System;
using System.Collections;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    #region Instance

    public static StatusManager instance;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    #endregion

    [SerializeField] private Image socialBar = null;
    [SerializeField] private Image physicalBar = null;
    [SerializeField] private Image professionalBar = null;
    [SerializeField] private Image mentalBar = null;

    public void Init(TypeNotification typeNotification, float value)
    {
        switch (typeNotification)
        {
            case TypeNotification.Mental:
                mentalBar.fillAmount = value;
                break;
            case TypeNotification.Physical:
                physicalBar.fillAmount = value;
                break;
            case TypeNotification.Professional:
                professionalBar.fillAmount = value;
                break;
            case TypeNotification.Social:
                socialBar.fillAmount = value;
                break;
        }
    }

    public void ChangeBar(TypeNotification typeNotification, float value)
    {
        switch (typeNotification)
        {
            case TypeNotification.Mental:
                StartCoroutine(ChangeValueBar(mentalBar, mentalBar.fillAmount, value));
                break;
            case TypeNotification.Physical:
                StartCoroutine(ChangeValueBar(physicalBar, physicalBar.fillAmount, value));
                break;
            case TypeNotification.Professional:
                StartCoroutine(ChangeValueBar(professionalBar, professionalBar.fillAmount, value));
                break;
            case TypeNotification.Social:
                StartCoroutine(ChangeValueBar(socialBar, socialBar.fillAmount, value));
                break;
        }
    }

    private IEnumerator ChangeValueBar(Image target, float currentValue, float finalValue)
    {
        if (finalValue > currentValue) target.color = Color.green;
        if (finalValue < currentValue) target.color = Color.red;
        var newValue = Mathf.Lerp(currentValue, finalValue, 25.0f * Time.deltaTime);
        if (currentValue > 0) target.fillAmount = newValue;
        else
        {
            target.fillAmount = 0;
            GameController.GameOver();
        }
        yield return new WaitForSeconds(0.01f);
        if (Math.Abs(currentValue - finalValue) > 0.0001f) StartCoroutine(ChangeValueBar(target, newValue, finalValue));
        else target.color = Color.white;
    }
}