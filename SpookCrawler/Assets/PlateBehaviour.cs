using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    public GameObject boulderPrefab;

    private Vector3 originalPos;
    private bool isActivated = false;
    private Vector3 platePressed = new Vector3(0f, -0.15f, 0f);

    public Transform spawnBoulder;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.name == "Player" && !isActivated)
        {
            isActivated = true;
            this.GetComponent<Collider2D>().enabled = false;
            //transform.position += platePressed;
            GameObject boulder = Instantiate(boulderPrefab, spawnBoulder.position, boulderPrefab.transform.rotation);
            boulder.GetComponent<BoulderMovement>().Activate();
        }       
    }
}
