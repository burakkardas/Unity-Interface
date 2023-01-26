using UnityEngine;
using TMPro;


public class PlayerSelectionController : MonoBehaviour
{
    [SerializeField] private TMP_Text hoverText;

    private Camera mainCamera;

    private Pick pickInput;
    private RaycastHit hit;

    [SerializeField] private float rayDistance;



    private void Awake()
    {
        GetComponentValues();
    }



    private void OnEnable()
    {
        pickInput.Enable();
    }



    private void OnDisable()
    {
        pickInput.Disable();
    }


    private void Update()
    {
        SetRaycast();
    }


    private void SetRaycast()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Pickable"))
                {
                    IShowable showable = hit.collider.GetComponent<IShowable>();
                    hoverText.text = showable.value;


                    if (pickInput.Pickable.LeftClick.triggered)
                    {
                        IClickable clickable = hit.collider.GetComponent<IClickable>();
                        clickable.Click();
                    }
                }
            }
        }
        else
        {
            hoverText.text = "";
        }
    }


    private void GetComponentValues()
    {
        pickInput = new Pick();
        mainCamera = Camera.main;
    }
}
