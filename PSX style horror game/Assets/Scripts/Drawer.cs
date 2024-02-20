using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using TMPro;

public class Drawer : MonoBehaviour, IClickable
{
    public float throwForce = 10f;
    public bool open = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float lerpTime = 1f;
    public string OutputText = "Open";
    public GameObject CursorCanvas;
    public TMP_Text CursorText;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
        targetPosition = initialPosition;
        targetPosition.z += 0.529f;
        CursorCanvas = GameObject.FindGameObjectWithTag("CursorCanvas");
        CursorText = CursorCanvas.GetComponentInChildren<TMP_Text>();
    }

    public void Clicked()
    {
        if (!open)
        {
            StartCoroutine(LerpPosition(targetPosition, lerpTime));
        }
        else
        {
            StartCoroutine(LerpPosition(initialPosition, lerpTime));
        }
        open = !open;
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
