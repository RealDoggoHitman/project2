using UnityEngine;

public class Key : MonoBehaviour, IClickable
{
    public GameObject ItemHand;
    public float throwForce = 10f;

    private GameObject Item;
    public bool Grabbed;
    private GameObject Items;
    private Rigidbody rb;
    private GameObject CamPos;
   

    private void Start()
    {
        Transform parent = transform.parent;
        Items = parent.gameObject;
        CamPos = Camera.main.gameObject;
        Item = gameObject;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Grabbed)
        {
            gameObject.transform.position = ItemHand.transform.position;
            gameObject.transform.rotation = ItemHand.transform.rotation;
            gameObject.transform.SetParent(CamPos.transform);

        }
    }
    public void Clicked()
    {
        if (ItemHand.transform.parent.childCount != 1) { return; }
        Grabbed = true;
        gameObject.transform.position = ItemHand.transform.position;
        gameObject.transform.rotation = ItemHand.transform.rotation;
        gameObject.transform.SetParent(CamPos.transform);

        BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }

        SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.enabled = false;
        }

        CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = false;
        }

        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.enabled = false;
        }

        rb.isKinematic = true;
  
    
    
    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && Grabbed)
        {
            gameObject.transform.SetParent(Items.transform);
            gameObject.layer = LayerMask.NameToLayer("Default");

            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = true;
            }

            SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
            if (sphereCollider != null)
            {
                sphereCollider.enabled = true;
            }

            CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            if (capsuleCollider != null)
            {
                capsuleCollider.enabled = true;
            }

            MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
            if (meshCollider != null)
            {
                meshCollider.enabled = true;
            }

            rb.isKinematic = false;
            Grabbed = false;

            
          
        }
    }
}
