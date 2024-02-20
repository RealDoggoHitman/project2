using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using TMPro;

public class VentDoor : MonoBehaviour, IClickable
{
    public bool Open = false;
    public GameObject key;
    private Key keys;
    private GameObject CursorCanvas;
    private TMP_Text CursorText;
    public GameObject teleportPos;

    public string OutputText = "Ineed to loosen the scrwes with something";

    private void Start()
    {
        keys = key.GetComponent<Key>();
        CursorCanvas = GameObject.FindGameObjectWithTag("CursorCanvas");
        CursorText = CursorCanvas.GetComponentInChildren<TMP_Text>();
    }

    public void Clicked()
    {
        if (Open)
        {
          GameObject.FindGameObjectWithTag("Player").transform.position = teleportPos.transform.position;
        }
        else
        {
            if (keys.Grabbed)
            {
                Open = true;
                CursorText.text = "Opened";
            }
            else
            {
                CursorText.text = OutputText;
            }

            
        }
    }


}
