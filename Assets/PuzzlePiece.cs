
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    //[HideInInspector]
    public bool CollideWithAMagneticArea = false;
    //[HideInInspector]
    public GameObject MagneticAreaCollided;

    void Start () { GetComponent<Rigidbody2D>().velocity = Vector3.zero; }
    void Update () { transform.position = new Vector3(transform.position.x, transform.position.y, -1f); }
    void OnTriggerEnter2D(Collider2D other) { if (other.transform.CompareTag("Magnetic Area")) { CollideWithAMagneticArea = true; MagneticAreaCollided = other.gameObject; } }
    void OnTriggerExit2D (Collider2D other) { if (other.transform.CompareTag("Magnetic Area")) { CollideWithAMagneticArea = false; MagneticAreaCollided = null; }; }

}
