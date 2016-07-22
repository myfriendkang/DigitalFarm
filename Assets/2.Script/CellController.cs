using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CellController : MonoBehaviour {


    public GameObject[] greenCells;
    private GameObject _greenCellSelected;
	public GameObject slider;
    public InputField nameField;
    public Text waterText;
    public Text phText;
    public Text nutrientText;
    public Text cellName;
    string str = "Name";
    int water;
    int ph;
    int nutrient;
	int currentCell_ID;

    // Use this for initialization
    void Start() {
        water = 0;
        ph = 0;
        nutrient = 0;
    }
	/*
    // Update is called once per frame
    void Update() {
        CheckWhichCellSelected();
    }

    void CheckWhichCellSelected()
    {
        foreach (GameObject cell in greenCells)
        {
            if (cell.GetComponent<GreenCellStatus>().selectCell == true)
            {
				currentCell_ID = cell.GetComponent<GreenCellStatus> ().plantID;
                _greenCellSelected = cell;
                waterText.text = water.ToString();
                phText.text = ph.ToString();
                nutrientText.text = nutrient.ToString();
            }
            cell.gameObject.GetComponent<GreenCellStatus>().SetSelected();
        }
    }
    */
    #region controlValue
    public void Water_OnPlusButtonClick()
    {
         if (nameField.GetComponentInChildren<Text>().text != str)
        {
            water++;
            waterText.text = water.ToString();
        }
    }

    public void Water_OnMinusButtonClick()
    {
        if (nameField.GetComponentInChildren<Text>().text != str)
        {
            water--;
            waterText.text = water.ToString();
        }
    }
		
    public void PH_OnPlusButtonClick()
    {
        if (nameField.GetComponentInChildren<Text>().text != str)
        {
            ph++;
            phText.text = ph.ToString();
        }
    }

    public void PH_OnMinusButtonClick()
    {
        if (nameField.GetComponentInChildren<Text>().text != str)
        {
            ph--;
            phText.text = ph.ToString();
        }
    }
		
    public void Nut_OnPlusButtonClick()
    {
        if (nameField.GetComponentInChildren<Text>().text != str)
        {
            nutrient++;
            nutrientText.text = nutrient.ToString();
        }
    }

    public void Nut_OnMinusButtonClick()
    {
        if (nameField.GetComponentInChildren<Text>().text != str)
        {
            nutrient--;
            nutrientText.text = nutrient.ToString();
        }
    }
		
    #endregion








}
