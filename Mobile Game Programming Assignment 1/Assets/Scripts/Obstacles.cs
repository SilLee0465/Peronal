using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private PlayerController PlayerController;
    [SerializeField] private CameraShake CameraShake;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "deathObstacle")
        {
            FindObjectOfType<AudioManager>().Play("Slam");
            StartCoroutine(CameraShake.Shake(0.15f, 0.4f));
            //game Over
            PlayerController.isDead = true;
        }
        if(other.tag == "normalObstacle")
        {
            FindObjectOfType<AudioManager>().Play("Slam");
            StartCoroutine(CameraShake.Shake(0.15f, 0.4f));
            if (PlayerController.isHurt == true)
            {
                //game Over
                PlayerController.isDead = true;
            }
            else
            {
                PlayerController.isHurt = true;
            }
        }
    }
}
