using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button openDoorButton;
    [SerializeField] private DoorController doorController;
    [SerializeField] private InputField inputField;

    private void Start()
    {
        openDoorButton.onClick.AddListener(ToggleDoor);
        inputField = inputField.GetComponent<InputField>();
    }

    private void ToggleDoor()
    {
        Debug.Log(inputField.text);

        if (inputField.text.Equals("5555"))
        {
            doorController.open();
        }
        else
        {
            doorController.close();
        }
        
    }
}
