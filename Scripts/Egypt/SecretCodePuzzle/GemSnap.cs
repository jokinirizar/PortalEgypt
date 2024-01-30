using System.Collections.Generic;
using UnityEngine;

public class GemSnap : MonoBehaviour
{
    // Declare a list with all possible gems
    private List<string> GemTags = new List<string> {"OrangeGem","PinkGem", "PurpleGem", "BlueGem"};
    public string listenToTag = "Gem";
    public bool GemIsSnapped = false;
    public string CorrectGem;
    private Vector3 animToGemScale = new Vector3(30,30,30);
    GameObject Line;
    public void Awake()
    {
        PedestalStatus status = transform.parent.GetComponent<PedestalStatus>();
        //Debug.Log(status.CorrectGem);
        Line = transform.parent.gameObject.transform.parent.gameObject;
        if (status.CorrectGem.Length<2)
        {
            CorrectGem = GemTags[Random.Range(0, 4)];       
            Debug.Log(transform.parent.name + " " + " " + CorrectGem, gameObject);
            status.CorrectGem = CorrectGem;
        }
        else
        {
           CorrectGem = status.CorrectGem;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        GemStatus GemStatusScript = null;
        if (!other.TryGetComponent(out GemStatusScript)) return;
        GameObject Gem = other.gameObject;
        foreach ( string tag in GemTags) {
            if (other.CompareTag(tag) && !GemIsSnapped)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
               // rb.velocity = Vector3.zero;
               // rb.angularVelocity = Vector3.zero;
                rb.rotation = Quaternion.identity;
                rb.isKinematic = true;
                Gem.transform.position = transform.position;
                Gem.layer = LayerMask.NameToLayer("PlacedGem");
                Gem.GetComponent<Rigidbody>().useGravity = false;
                //Vector3 position = Gem.transform.position;
                Gem.GetComponent<PickableItem>().CurrentObject = null;
                GameManager.instance.IsObjectPickedUp = false;
                Gem.transform.parent = this.gameObject.transform;
                Gem.GetComponent<Animator>().enabled = true;
                other.gameObject.GetComponent<PickableItem>().IsPlaced = true;
                //Gem.GetComponentInParent<Transform>().position = position;
                //Gem.GetComponentInParent<Transform>().localScale = animToGemScale;

                //Gem.GetComponent<BoxCollider>().enabled = false;

                if (other.CompareTag(CorrectGem))
                {               
                    other.gameObject.GetComponent<GemStatus>().IsPlaced = true;
                    GemStatusScript.IsCorrectlyPlaced = true;
                    Line.GetComponent<CodeLineScript>().AddGem(GemStatusScript);
                }
                else
                {
                    Line.GetComponent<CodeLineScript>().AddGem(GemStatusScript);
                }
                GemIsSnapped = true;
            }
        }
 
    }
}