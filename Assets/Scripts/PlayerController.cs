using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float baseSpeed = 70f;
    [SerializeField] float boostSpeed = 100f;
    [SerializeField] float lowerSpeed = 40f;
    bool puedeMoverse = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // Encuentra el componente surface effector 2d, y como solo hay uno, en el nieve sprite shape, lo encuentra ahí aunque
        // este script esté asociado al player
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    [SerializeField] float torqueAmount = 1f;
    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        PlayerSpeed();
    }

    public void DisableControls()
    {
        puedeMoverse = false;
    }

    private void PlayerSpeed()
    {
        if (puedeMoverse)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                surfaceEffector2D.speed = boostSpeed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                surfaceEffector2D.speed = lowerSpeed;
            }
            else
            {
                surfaceEffector2D.speed = baseSpeed;
            }
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
