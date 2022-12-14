using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicResize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // check if card addition will go outside the GridLayout
    public bool CheckCardAddition(float cardSize, int numCards)
    {
        // get the card's size
        //float cardSize = card.GetComponent<RectTransform>().rect.width;
        // get the card's position
        //Vector2 cardPos = card.GetComponent<RectTransform>().anchoredPosition;
        // get the grid's size
        float gridSize = GetComponent<RectTransform>().rect.width;
        // get the grid's position
        Vector2 gridPos = GetComponent<RectTransform>().anchoredPosition;

        Debug.Log("Size of card: " + cardSize);

        // check if the card will go outside the grid
        if (cardSize * (numCards + 1) > gridSize)
        {
            Debug.Log("Width if not resized: " + (cardSize * (numCards + 1)));
            return true;
        }
        else
        {
            return false;
        }
    }

    
    // resize cells to fit the new card
    public void ResizeGridShrink(float cardSize, int numCards)
    {
        float gridSize = GetComponent<RectTransform>().rect.width;
        float cellWidth = Mathf.Floor(gridSize / (numCards + 1));
        float cellHeight = cellWidth * 1.4f;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
    }

    public bool CheckCardRemoval(float cardSize, int numCards)
    {
        // get the grid's size
        float gridSize = GetComponent<RectTransform>().rect.width;
        // get the grid's position
        Vector2 gridPos = GetComponent<RectTransform>().anchoredPosition;

        Debug.Log("Size of card: " + cardSize);

        // at some point, we'll probably want to check to see if we need to resize based on how much space there is to reclaim
        if (Mathf.Floor(gridSize / numCards) > 150f)
        {
            return false;
        }
        else
        {
            Debug.Log("Width if not resized: " + (cardSize * numCards));
            return true;
        }
    }

    // resize cells to fill space remaining
    public void ResizeGridGrow(float cardSize, int numCards)
    {
        float gridSize = GetComponent<RectTransform>().rect.width;
        float cellWidth = Mathf.Floor(gridSize / numCards);
        float cellHeight = cellWidth * 1.4f;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellWidth, cellHeight);
    }
}
