using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button openDoorButton;
    [SerializeField] private doorOpenPanel doorOpenPanel;
    [SerializeField] private DoorController doorController;

    private void Start()
    {
        doorOpenPanel.activate(false);
        openDoorButton.onClick.AddListener(ToggleOpenDoorPanel);
    }

    private void ToggleOpenDoorPanel()
    {
        doorOpenPanel.activate(true);
    }
}
