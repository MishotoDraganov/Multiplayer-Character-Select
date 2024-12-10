using System;
using TMPro;
using UnityEngine;

public class MainMenuDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_InputField joinCodeInputField;

    private float timeInQueue;
    private bool isMatchmaking;
    private bool isCancelling;
    private ClientGameManager gameManager;

    private void Start()
    {
        if (ClientSingleton.Instance == null) { return; }


        gameManager = ClientSingleton.Instance.Manager;
    }

    private void Update()
    {
        if (isMatchmaking && !isCancelling)
        {
            timeInQueue += Time.deltaTime;
            TimeSpan ts = TimeSpan.FromSeconds(timeInQueue);
        }
    }

    public async void StartHost()
    {
        await HostSingleton.Instance.StartHostAsync();
    }

    public async void StartClient()
    {
        await ClientSingleton.Instance.Manager.BeginConnection(joinCodeInputField.text);
    }
}




// mismatch of detector and manager
