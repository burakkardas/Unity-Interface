using UnityEngine;

public class LightController : MonoBehaviour, IClickable, IShowable
{
    [SerializeField] private GameObject lightObject;

    private string currentValue = "Işığı Aç";
    public string value { get => currentValue; }
    private bool isOpen;


    public void Click()
    {
        if (!isOpen)
        {
            isOpen = true;
            currentValue = "Işığı Kapat";
        }
        else
        {
            isOpen = false;
            currentValue = "Işığı Aç";
        }

        SetActiveLightObject(isOpen);
    }



    private void SetActiveLightObject(bool value)
    {
        lightObject.SetActive(value);
    }
}
