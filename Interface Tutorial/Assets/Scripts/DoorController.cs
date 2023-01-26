using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour, IShowable, IClickable
{
    private string currentValue = "Kapıyı Aç";
    public string value { get => currentValue; }
    private bool isOpen;


    [SerializeField] private Vector3 endValue;
    [SerializeField] private float lerpValue;


    public void Click()
    {
        if (!isOpen)
        {
            isOpen = true;
            currentValue = "Kapıyı Kapat";
            SetDoorValue(endValue);
        }
        else
        {
            isOpen = false;
            currentValue = "Kapıyı Aç";
            SetDoorValue(Vector3.zero);
        }
    }




    private void SetDoorValue(Vector3 _endValue)
    {
        transform.DOLocalRotate(_endValue, lerpValue);
    }
}
