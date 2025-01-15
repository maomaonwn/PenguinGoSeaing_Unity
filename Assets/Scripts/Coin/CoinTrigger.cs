using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinTrigger : MonoBehaviour
{   

    private void OnTriggerEnter(Collider other)
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++index);
    }
}
