using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject applePrefab;
    public GameObject igaguriPrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int raito1 = 2, ration2 = 5;
    float speed = -0.03f;
	
    public void SetParameter(float span, float speed, int raito)
    {
        this.span = span;
        this.speed = speed;
        this.raito1 = raito1;
        this.ration2 = ration2;
    }

	// Update is called once per frame
	void Update ()
    {
        this.delta += Time.deltaTime;

        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;

            int dice = Random.Range(1, 11);
            
            if(dice <= this.raito1)
            {
                item = Instantiate(bombPrefab) as GameObject;
            }

            else if(dice > raito1 && dice <= ration2)
            {
                item = Instantiate(igaguriPrefab) as GameObject;
            }

            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
	}
}
