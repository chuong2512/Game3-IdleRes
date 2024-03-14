using UnityEngine;

public class Tracking : MonoBehaviour
{
    public static Tracking instance;

    private bool first;

    private void Awake()
    {
        if (Tracking.instance == null)
        {
            Tracking.instance = this;
        }
        else if (Tracking.instance != this)
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }

    private void Start()
    {
        this.first = !PlayerPrefs.HasKey("first_session");
        if (this.first)
        {
            PlayerPrefs.SetInt("first_session", 1);
        }
    }

    public void Tutorial_Start(string step)
    {
    }

    public void Tutorial_Done(string step)
    {
    }

    public void UI_Interaction(string position, string action)
    {
    }

    public void Ads_Impress(string adsTYPE, string position)
    {
    }

    public void Ads_Status(string adsTYPE, string action, string position, string status)
    {
    }

    public void IAP(string product)
    {
    }

    public void Rate_Show()
    {
    }

    public void Rate_Action(string action)
    {
    }
}