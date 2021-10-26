using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Animator uiMainAnimator;

    public GameObject uiRewardGameObject;
    public GameObject uiChapter;
    public GameObject uiSettings;

    public Button shopBtn;
    public Button chapterBtn;
    public Button settingsBtn;

    private void Awake()
    {
        shopBtn.onClick.AddListener(OnOpenShop);
        chapterBtn.onClick.AddListener(OnOpenChapter);
        settingsBtn.onClick.AddListener(OnSettings);
    }

    private void OnOpenShop()
    {
        SetPlayerState(false);
        uiRewardGameObject.SetActive(true);
    }

    private void OnOpenChapter()
    {
        uiMainAnimator.Play("out");
        uiChapter.SetActive(true);
        SetPlayerState(false);
    }

    private void OnSettings()
    {
        uiSettings.SetActive(true);
    }

    public void SetPlayerState(bool isActive)
    {
        //EventManager.EmitEventData(EventName.TRIGGER_PRESENTER, isActive);
    }
}
