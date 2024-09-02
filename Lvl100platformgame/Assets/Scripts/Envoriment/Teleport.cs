using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    int randomLevel;
    [SerializeField] GameObject teleportEffect;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            teleportEffect.SetActive(true);
            Player.instance.playerSpeed = 0;
            randomLevel = Random.Range(1, 100);
            UIManager.instance.currentSceneIndex = randomLevel;
            StartCoroutine(TeleportDelay());
        }
    }
    IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(3);
        Player.instance.playerSpeed = 12;
        teleportEffect.SetActive(false);
        SceneManager.LoadScene(randomLevel);
    }

}
