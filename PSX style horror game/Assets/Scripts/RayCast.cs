using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public interface IClickable
{
    void Clicked();
}

public class RayCast : MonoBehaviour
{
    public int rayDistance = 3;
    public GameObject cursor;
    public GameObject cursor2;
    private Camera mainCamera;
    public GameObject CursorCanvas;
    public TMP_Text CursorText;
    void Start()
    {
        mainCamera = Camera.main;
        CursorCanvas = GameObject.FindGameObjectWithTag("CursorCanvas");
        CursorText = CursorCanvas.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance);
        cursor2.SetActive(false);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            IClickable clickable = hit.transform.GetComponent<IClickable>();

            if (clickable != null)
            {
                cursor2.SetActive(true);
                cursor.SetActive(false);

                if (Input.GetMouseButtonDown(0))
                {
                   
                        clickable.Clicked();
                    
                }
            }
            else
            {
                cursor2.SetActive(false);
                cursor.SetActive(true);
                CursorText.text = "";
            }
        }
        else
        {
            cursor.SetActive(true);
            cursor2.SetActive(false);
        }
    }
}
