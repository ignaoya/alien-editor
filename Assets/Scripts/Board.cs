using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> startingText;
    private List<GameObject> text = new List<GameObject>();

    private GameObject cursor;
    private int cursorIndex = 0;
    private float cursorMovementX;
    private float cursorMovementY;

    private GameObject symbol;

    private float width;
    private float height;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {

        cursor = GameObject.FindWithTag("Cursor");

        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        x = this.transform.position.x;
        y = this.transform.position.y;

        cursor.transform.position = new Vector3(x - (width / 2) + 1f, y + (height / 2) - 1f, 0);

        for (int i = 0; i < startingText.Count; i++)
        {
            int row = i / 8;
            int col = i % 8;
            symbol = Instantiate(startingText[i]);
            symbol.transform.position = new Vector3(
                x - (width / 2) + 1f + (1.5f * col), y + (height / 2) - 1f - (1.5f * row), 0);
            text.Add(symbol);
        }
    }

    private void FixedUpdate() 
    {
        MoveCursor();
        RemoveSymbol();
    }

    // Update is called once per frame
    void Update()
    {
       UpdateCursor();
       UpdateText();
    }

    void MoveCursor() 
    {
        if (Input.GetButtonDown("left") && this.cursorIndex > 0)
        {
            this.cursorIndex--;
        }
        if (Input.GetButtonDown("right") && this.cursorIndex < 31)
        {
            this.cursorIndex++;
        }
        if (Input.GetButtonDown("up") && this.cursorIndex > 7)
        {
            this.cursorIndex -= 8;
        }
        if (Input.GetButtonDown("down") && this.cursorIndex < 24)
        {
            this.cursorIndex += 8;
        }
    }

    void UpdateCursor()
    {
        int row = this.cursorIndex / 8;
        int col = this.cursorIndex % 8;

        Vector3 newPos = new Vector3(
            x - (width / 2) + 1f + (1.5f * col), y + (height / 2) - 1f - (1.5f * row), 0);

        cursor.transform.position = newPos;
    }

    void RemoveSymbol()
    {
        if (Input.GetButtonDown("Jump") && cursorIndex < text.Count)
        {
            symbol = text[cursorIndex];
            text.RemoveAt(cursorIndex);
            Destroy(symbol);
        }
    }

    void UpdateText()
    {
        for (int i = 0; i < text.Count; i++)
        {
            int row = i / 8;
            int col = i % 8;
            symbol = text[i];
            symbol.transform.position = new Vector3(
                x - (width / 2) + 1f + (1.5f * col), y + (height / 2) - 1f - (1.5f * row), 0);
        }
    }
}
