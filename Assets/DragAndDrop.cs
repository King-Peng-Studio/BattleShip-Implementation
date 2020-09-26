using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [HideInInspector]
    public GameObject SelectedPiece;
    private Vector3 InitialPos, SelfInitialPos;

    public GameObject MousePointCollider, MainCanvas, FireGrid, TextMessage;

    [HideInInspector] public bool PlacementEnd = false;
    [HideInInspector] public int FreeShips = 10;

    void Update()
    { 

        if (Input.GetMouseButtonDown(0)) {
         RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
         if (Hit.transform != null) if (Hit.transform.CompareTag("Ship")) { SelectedPiece = Hit.transform.gameObject; InitialPos = SelectedPiece.transform.parent.transform.position; SelfInitialPos = SelectedPiece.transform.position; }; };
        
        if (MousePointCollider != null && SelectedPiece != null) 
         if (Input.GetMouseButtonUp(0) && MousePointCollider.GetComponent<MousePointCollider>().CollideWithAMagneticArea) { 
         if (SelectedPiece.GetComponent<RectTransform>().sizeDelta.x/SelectedPiece.GetComponent<RectTransform>().sizeDelta.y == 1) SelectedPiece.transform.position = new Vector3(MousePointCollider.GetComponent<MousePointCollider>().MagneticAreaCollided.transform.position.x, MousePointCollider.GetComponent<MousePointCollider>().MagneticAreaCollided.transform.position.y, -1f); // else SelectedPiece.transform.position = new Vector3(MousePointCollider.GetComponent<MousePointCollider>().MagneticAreaCollided.transform.position.x + ((SelectedPiece.GetComponent<RectTransform>().sizeDelta.x / (SelectedPiece.GetComponent<RectTransform>().sizeDelta.x / SelectedPiece.GetComponent<RectTransform>().sizeDelta.y)*2)/10), MousePointCollider.GetComponent<MousePointCollider>().MagneticAreaCollided.transform.position.y, -1f); };
            else if (SelectedPiece.transform.GetChild(0).GetComponent<TailCollider>().CollideWithAMagneticArea) SelectedPiece.transform.parent.transform.position = new Vector3(MousePointCollider.GetComponent<MousePointCollider>().MagneticAreaCollided.transform.position.x, MousePointCollider.GetComponent<MousePointCollider>().MagneticAreaCollided.transform.position.y, -1f); /*"}"*/ FreeShips--; };
        if (SelectedPiece != null && Input.GetMouseButton(0)) { Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); if (SelectedPiece.GetComponent<RectTransform>().sizeDelta.x/SelectedPiece.GetComponent<RectTransform>().sizeDelta.y == 1) SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, -1f); else { SelectedPiece.transform.parent.transform.position = new Vector3(MousePoint.x, MousePoint.y, -1f); }; SelectedPiece.transform.parent.transform.SetParent(MainCanvas.transform); }
         
        if (SelectedPiece != null && Input.GetMouseButtonUp(0)) { if (SelectedPiece.GetComponent<RectTransform>().sizeDelta.x/SelectedPiece.GetComponent<RectTransform>().sizeDelta.y != 1) { if (!(MousePointCollider.GetComponent<MousePointCollider>().CollideWithAMagneticArea) || (!(SelectedPiece.transform.GetChild(0)).GetComponent<TailCollider>().CollideWithAMagneticArea)) SelectedPiece.transform.parent.transform.position = InitialPos; } else if (!(MousePointCollider.GetComponent<MousePointCollider>().CollideWithAMagneticArea)) SelectedPiece.transform.position = SelfInitialPos; SelectedPiece = null; } 

        if (FreeShips == 0) { PlacementEnd = true; FireGrid.SetActive(true); TextMessage.SetActive(false); }

    }    
}
