using System.Collections;
using TigerForge;
using UnityEngine;
using UnityEngine.UI;

public class Presenter : MonoBehaviour
{
    private int skateboardIndex;

    private const string PLAYER_KEY = "KEY";

    public Button nextBtn;
    public Button prevBtn;

    [SerializeField]
    private GameObject skateboard;
    [SerializeField]
    private GameObject skateboardPreb;


    private void Awake()
    {
        skateboardIndex = DataPlayer.GetCurrentSkateboardId();
        nextBtn.onClick.AddListener(OnNext);
        prevBtn.onClick.AddListener(OnPrev);
    }

    private void OnPrev()
    {
        skateboardIndex = DataPlayer.GetPrevSkateboard();
        Destroy(skateboard);

        StartCoroutine(InitPlayer());
    }

    private void OnNext()
    {
        skateboardIndex = DataPlayer.GetNextSkateboard();
        Destroy(skateboard);

        StartCoroutine(InitPlayer());
    }

    private IEnumerator Start()
    {
        yield return InitPlayer();
    }

    private IEnumerator InitPlayer()
    {
        var request = Resources.LoadAsync<GameObject>($"Prefabs/{skateboardIndex}");

        while (!request.isDone)
        {
            yield return null;
        }

        skateboardPreb = (GameObject)request.asset;

        SetPlayer();
        SetPlayerState(true);
    }

    private void OnEnable()
    {
        EventManager.StartListening(EventName.TRIGGER_PRESENTER, OnTrigger);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventName.TRIGGER_PRESENTER, OnTrigger);
    }

    private void OnTrigger()
    {
        var isActive = EventManager.GetBool(EventName.TRIGGER_PRESENTER);

        SetPlayerState(isActive);
    }

    private void SetPlayer()
    {
        // if (playerIndex >= playerList.Length)
        // {
        //     throw new Exception("Out of list");
        // }
        //
        // player = playerList[playerIndex];

        skateboard = GameObject.Instantiate(skateboardPreb);
        skateboard.transform.localPosition = new Vector3(5, -10, 25);
        skateboard.transform.localScale = Vector3.one * 10f;

    }

    public void SetPlayerState(bool isActive)
    {
        skateboard.gameObject.SetActive(isActive);
    }
}
