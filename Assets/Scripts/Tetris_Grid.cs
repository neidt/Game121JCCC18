using Assets.Scripts.GameClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tetris_Grid : MonoBehaviour
{

    private int gridWidth = 10;
    private int gridHeight = 20;

    private TetrisGameGrid myGrid;    //null by default

    public GameObject greenBlock;
    public GameObject blueBlock;
    public GameObject redBlock;
   
	// Use this for initialization
	void Start ()
    {
        myGrid = new TetrisGameGrid(gridWidth, gridHeight);

        myGrid.gridSpaces[0, 0] = new Block(0, 0, BlockColor.Green);

        /*myGrid.gridSpaces[0, 1] = new Block(0, 1, BlockColor.Blue);
        myGrid.gridSpaces[0, 2] = new Block(0, 2, BlockColor.Red);

        for (int x = 0; x < gridWidth; x++)
        {  
            for (int y = 0; y < gridHeight; y++)
            {
               myGrid.gridSpaces[x, y] = new Block(x,y,BlockColor.Blue);
               //GameObject newGreenBlock = GameObject.Instantiate(greenBlock);
            }
        }*/
	}
	
	// Update is called once per frame
	void Update ()
    {
        //draw a square in the appropriate location 
        //for all occupied blocks in myGrid
        
        for (int x=0; x <= gridWidth-1; x++)
        {
            for (int y=0; y <= gridHeight-1; y++)
            {
                //if there is a block present at x,y
                //draw it in the right color

                myGrid.gridSpaces[x, y] = new Block(x, y, BlockColor.Green);
                

                /*if (myGrid.gridSpaces[x,y] != null)
                 {
                    GameObject newGreenBlock = GameObject.Instantiate(greenBlock);
                }*/
                 

            }
        } 
    }
}
