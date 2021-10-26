using System.Collections;
using TigerForge;
using UnityEngine;
using UnityEngine.UI;

public class Presenter : MonoBehaviour
{
    private int playerIndex;
    private GameObject prefabPlayer;
    private GameObject player;

    private const string PLAYER_KEY = "KEY";

    public Button nextBtn;
    public Button prevBtn;

    private void Awake()
    {
        playerIndex = DataPlayer.GetCurrentSkateboardId();
        nextBtn.onClick.AddListener(OnNext);
        prevBtn.onClick.AddListener(OnPrev);
    }

    private void OnPrev()
    {
        playerIndex = DataPlayer.GetPrevSkateboard();
        Destroy(player);

        StartCoroutine(InitPlayer());
    }

    private void OnNext()
    {
        playerIndex = DataPlayer.GetNextSkateboard();
        Destroy(player);

        StartCoroutine(InitPlayer());
    }

    private IEnumerator Start()
    {
        yield return InitPlayer();
    }

    private IEnumerator InitPlayer()
    {
        var request = Resources.LoadAsync<GameObject>($"{playerIndex}");

        while (!request.isDone)
        {
            yield return null;
        }

        prefabPlayer = (GameObject)request.asset;

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

        player = GameObject.Instantiate(prefabPlayer);
        player.transform.localPosition = new Vector3(0, -2.52f, 26.3f);
        player.transform.localScale = Vector3.one * 6f;

    }

    public void SetPlayerState(bool isActive)
    {
        player.gameObject.SetActive(isActive);
    }
}
