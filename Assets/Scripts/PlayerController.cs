using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log(horizontal);
        Debug.Log(vertical);

        Vector2 position = transform.position;
        position.x += horizontal * Time.deltaTime * 3.0f;
        position.y += vertical * Time.deltaTime * 3.0f;
        
        transform.position = position;
    }
}
