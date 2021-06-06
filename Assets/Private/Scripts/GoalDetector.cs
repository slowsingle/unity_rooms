using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class GoalDetector : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float changeSceneDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.SetGoingUp();
            Invoke("ChangeScene", changeSceneDelay);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("GameClearScene");
    }
}
