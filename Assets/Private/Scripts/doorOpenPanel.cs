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
    [SerializeField] private string question;
    [SerializeField] private string answer;
    [SerializeField] private List<Image> imageList;

    private void Start()
    {
        enterButton.onClick.AddListener(checkPassword);
        inputField = inputField.GetComponent<InputField>();

        if (question.Length != imageList.Count)
        {
            Debug.LogError("question.Length != imageList.Count");
        }

        for (int i = 0; i < imageList.Count; i++)
        {
            imageList[i].color = Calc2Color.getColorValue(question[i].ToString());
        }
    }

    private void checkPassword()
    {
        Debug.Log(inputField.text);

        if (inputField.text.Equals(answer))
        {
            doorController.open();
        }
        else
        {
            doorController.close();
        }

        inputField.text = "";
        activate(false);
    }

    public void activate(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
