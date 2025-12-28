using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ClickDebugger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("========= FARE TIKLANDI! =========");

            // Hangi UI objelerine týklandýðýný bul
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            Debug.Log("Týklanan obje sayýsý: " + results.Count);

            foreach (RaycastResult result in results)
            {
                Debug.Log("? " + result.gameObject.name + " (Parent: " +
                    (result.gameObject.transform.parent != null ? result.gameObject.transform.parent.name : "yok") + ")");
            }
        }
    }
}