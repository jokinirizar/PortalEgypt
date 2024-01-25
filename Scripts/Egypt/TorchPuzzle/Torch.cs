using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool IsFull = false;
    private int Count = 0;

    public delegate void EventHandler(string current);

    public static event EventHandler OnComplete;

    private void Place(Rigidbody rb, GameObject Item)
    {
        GameManager.instance.IsObjectPickedUp = false;
        Destroy(Item);
        transform.GetChild(Count-1).gameObject.GetComponent<MeshRenderer>().enabled = true;
        if(Count == transform.childCount)
        {
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //La forma correcta: El script del objeto tenga una variable que detecte si esta conectada
        //Comprobar tag de objeto
        GameObject Item = other.gameObject;
        string ItemName = Item.name;

        //Comprobar si el objeto a snappear es el correcto en base a su name y el valor de count (0 palos, 1 bandeja, 2 leña)
        if (!IsFull)
        {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (ItemName == "Legs" && Count == 0)
                {
                  
                    Count++;
                    Debug.Log("Patas colocadas");
                    if (Item.GetComponent<PickableItem>())
                    {
                        Item.GetComponent<PickableItem>().IsPlaced = true;
                    }
                   

                    Place(rb, Item);
                }
                else if (ItemName == "Plate" && Count == 1)
                {
                    Count++;
                    Place(rb, Item);
                    Debug.Log("Bandeja puesta");
                    if (Item.GetComponent<PickableItem>())
                    {
                        Item.GetComponent<PickableItem>().IsPlaced = true;
                    }
                }
                else if ((ItemName == "Firewood" && Count >1)&&(Count< transform.childCount))
                {
                Count++;
                Place(rb, Item);
                    
                    Debug.Log("Leña colocada");
                    if (Item.GetComponent<PickableItem>())
                    {
                        Item.GetComponent<PickableItem>().IsPlaced = true;
                    }
                   
                }else if (Count == transform.childCount)
            {
                IsFull = true;
                //OnComplete("");
            }
            
        }
    }
}