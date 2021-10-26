using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopPopup : MonoBehaviour
{
    public UIShopElement[] shopElements;
    public Animator animator;
    public Button hideBtn;

    private void OnValidate()
    {
        if (shopElements == null || shopElements.Length == 0)
            shopElements = GetComponentsInChildren<UIShopElement>();
    }

    private void Awake()
    {
        hideBtn.onClick.AddListener(OnHideShop);

        foreach (var element in shopElements)
        {
            element.SetData();
        }
    }

    public void OnHideShop()
    {
        animator.Play("out");
    }


    public void HideShopEvent()
    {
        //EventManager.EmitEventData(EventName.TRIGGER_PRESENTER, true);
        gameObject.SetActive(false);
    }
}
