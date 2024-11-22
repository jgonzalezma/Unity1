using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaerAlSuelo : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem efectoCaida;
    [SerializeField] ParticleSystem efectoTabla;
    [SerializeField] AudioClip crashSFX;
    bool haCaido;
    string currentSceneName;

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !haCaido)
        {
            haCaido = true;
            Debug.Log("Has perdido");
            FindObjectOfType<PlayerController>().DisableControls();
            efectoCaida.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delay);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            efectoTabla.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            efectoTabla.Stop();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneName);
    }
}
