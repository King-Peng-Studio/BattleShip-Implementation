using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailCollider : MonoBehaviour
{
    //[HideInInspector]
    public bool CollideWithAMagneticArea = false;
    //[HideInInspector]
    public GameObject MagneticAreaCollided;

    void Start () { GetComponent<Rigidbody2D>().velocity = Vector3.zero; }
    void OnTriggerStay2D(Collider2D other) { if (other.transform.CompareTag("Box")) { CollideWithAMagneticArea = true; MagneticAreaCollided = other.gameObject; } }
    void OnTriggerExit2D (Collider2D other) { if (other.transform.CompareTag("Box")) { CollideWithAMagneticArea = false; MagneticAreaCollided = null; }; }

}
