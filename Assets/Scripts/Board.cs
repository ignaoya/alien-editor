using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Text;

    private GameObject symbol;

    private float width;
    private float height;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {

        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        x = this.transform.position.x;
        y = this.transform.position.y;

        for (int i = 0; i < Text.Length; i++)
        {
            symbol = Instantiate(Text[i]);
            symbol.transform.position = new Vector3(x - (width / 2) + 0.5f + (1.5f * i), y + (height / 2) - 0.5f, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
