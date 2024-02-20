using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using TMPro;

public class TrashCan : MonoBehaviour, IClickable
{
 

  


    public void Clicked()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,5f);


    }


}
