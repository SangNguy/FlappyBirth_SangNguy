using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BirdController.instance != null)
        {
            if (BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeController>()); 
            }
        }
        _PipeMoveMent();
    }
    void _PipeMoveMent()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp; 

    }
    void OnCollisionEnter2D(Collision2D target)
    {
            
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Destroy")
        {
            Destroy(gameObject);  // pipe bien mat sau khi cham vao "destroy pipe"
        }
    }
}
