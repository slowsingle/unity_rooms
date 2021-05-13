using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorOpenPanel : MonoBehaviour
{
    /*
      パスワード入力画面。正しいパスワードを入れると、扉が開く。
    */

    [SerializeField] private InputField inputField;
    [SerializeField] private Button enterButton;
    [SerializeField] private DoorController doorController;
    [SerializeField] private string password;

    private void Start()
    {
        enterButton.onClick.AddListener(checkPassword);
        inputField = inputField.GetComponent<InputField>();
    }

    private void checkPassword()
    {
        Debug.Log(inputField.text);

        if (inputField.text.Equals(password))
        {
            doorController.open();
        }
        else
        {
            doorController.close();
        }

        activate(false);
    }

    public void activate(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
