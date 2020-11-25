using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inviCounter;
    [SerializeField] private TextMeshProUGUI slowMowCounter;
    public static Shop instance = null;
    public int invinsibility = 0;
    public int slowMotion = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        inviCounter.text = "Invinsibility - " + invinsibility.ToString();
        slowMowCounter.text = "Slow motion - " + slowMotion.ToString();
    }

    public void purchaseInvinsibility()
    {
        invinsibility++;
        inviCounter.text = "Invinsibility - " + invinsibility.ToString();
    }

    public void purchaseSlowMotion()
    {
        slowMotion++;
        slowMowCounter.text = "Slow motion - " + slowMotion.ToString();
    }
}
