using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUps : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TextMeshProUGUI invinsibility;
    [SerializeField] TextMeshProUGUI slowMotion;
    [SerializeField] Shop shop;

    private float invinsibilityTimer = 5;
    private float invinsibilityTimerReset;
    private bool invinsibilityTimerStart = false;

    private float slowMotionTimer = 3;
    private float slowMotionTimerReset;
    private bool islowMotionTimerStart = false;

    // Start is called before the first frame update
    void Start()
    {
        invinsibilityTimerReset = invinsibilityTimer;
        slowMotionTimerReset = slowMotionTimer;
        invinsibility.text = "Invinsibility x" + shop.invinsibility.ToString();
        slowMotion.text = "Slow Motion x" + shop.slowMotion.ToString();
    }

    void Update()
    {
        if(invinsibilityTimerStart == true)
        {
            invinsibilityTimer -= Time.deltaTime;
            if (invinsibilityTimer <= 0)
            {
                playerController.hitboxStatus(true);
                invinsibilityTimer = invinsibilityTimerReset;
                scriptStatus(false);
            }
        }
        if(islowMotionTimerStart == true)
        {
            slowMotionTimer -= Time.deltaTime;
            if(slowMotionTimer <= 0)
            {
                Time.timeScale = 1.0f;
                slowMotionTimer = slowMotionTimerReset;
                scriptStatus(false);
            }
        }
    }

    public void Invinsibility()
    {
        if(shop.invinsibility > 1)
        {
            shop.invinsibility--;
            invinsibility.text = "Invinsibility x" + shop.invinsibility.ToString();
            playerController.hitboxStatus(false);
            invinsibilityTimerStart = true;
            scriptStatus(true);
        }
    }

    public void SlowMotion()
    {
        if(shop.slowMotion > 1)
        {
            shop.slowMotion--;
            slowMotion.text = "Slow Motion x" + shop.slowMotion.ToString();
            Time.timeScale = 0.5f;
            scriptStatus(true);
        }
    }

    void scriptStatus(bool status)
    {
        GetComponent<PowerUps>().enabled = status;
    }
}
