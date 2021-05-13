using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorOpenPanel : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Button enterButton;

    private void Start()
    {
        enterButton.onClick.AddListener(checkPassword);
        inputField = inputField.GetComponent<InputField>();
    }

    private void checkPassword()
    {
        Debug.Log(inputField.text);

        if (inputField.text.Equals("5555"))
        {

        }
        else
        {

        }

        activate(false);
    }

    public void activate(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
