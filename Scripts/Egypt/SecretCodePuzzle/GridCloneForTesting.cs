using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class WorldUICanvas : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    public RectTransform cursor;
    RectTransform draggableImage;
    bool dragging = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        // Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        // Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {

        // Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        // Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        // Create a list of Raycast Results
        List<RaycastResult> res = new List<RaycastResult>();

        // Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, res);
        if (res.Count > 0)
        {

            cursor.position = Vector3.MoveTowards(cursor.position, res[0].worldPosition, Time.deltaTime * 10f);
            Vector3 cursorPos = cursor.localPosition;
            cursorPos.z = 0;
            cursor.localPosition = cursorPos;
        }
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            dragging = false;
            draggableImage = null;
        }
        if (dragging)
        {
            draggableImage.position = cursor.position;
        }
        // Check for mouse click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            // Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            // Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            // Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            // For every result returned, output the name of the GameObject on the Canvas hit by the Ray


            foreach (RaycastResult result in results)
            {


                if (result.gameObject.name.ToLower() != "screen" && result.gameObject.name.ToLower() != "cursor")
                {
                    // Update the position of the cursor to match the hit position

                    Debug.Log("Hit " + result.gameObject.name);
                    int c = 1;
                    if (result.gameObject.CompareTag("HexagonTile"))
                    {
                        result.gameObject.GetComponent<GridSlot>().CheckIfNeighborHasProperty();
                        foreach (GameObject tile in result.gameObject.GetComponent<GridSlot>().adjacentTiles)
                        {
                            Debug.Log("ADJACENT TILE " + c + " :" + tile.name);

                            c++;
                        }
                        c = 1;
                        c = 1;

                    }

                    else if (result.gameObject.tag.ToLower() == "draggable")
                    {
                        draggableImage =  result.gameObject.GetComponent<RectTransform>();
                        dragging = true;
                    }
                    else if (result.gameObject.tag.ToLower() == "hexagontile")
                    {
                        //createNeighboringHexagonList(result);
                    }

                }

            }
        }
    }
}