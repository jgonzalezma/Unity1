using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem efectoBandera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Has ganado");
            efectoBandera.Play();
            GetComponent<AudioSource>().Play();
            Invoke("NextScene", delay);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
