using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CellController : MonoBehaviour {

    public GameObject[] greenCells;
    private GameObject _greenCellSelected;
    public Text waterText;
    public Text phText;
    public Text nutrientText;
    public Text cellName;
    int water;
    int ph;
    int nutrient;
    int value;
    // Use this for initialization
    void Start() {
        water = 0;
        ph = 0;
        nutrient = 0;
        value = 0;
    }

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
                Debug.Log(cell.gameObject.GetComponent<GreenCellStatus>().GetNameOfCell());
                _greenCellSelected = cell;
                cellName.text = _greenCellSelected.GetComponent<GreenCellStatus>().GetNameOfCell();
                water = _greenCellSelected.GetComponent<GreenCellStatus>().GetWaterOfCell();
                ph = _greenCellSelected.GetComponent<GreenCellStatus>().GetPhOfCell();
                nutrient = _greenCellSelected.GetComponent<GreenCellStatus>().GetNutrientOfCell();
                waterText.text = water.ToString();
                phText.text = ph.ToString();
                nutrientText.text = nutrient.ToString();

            }
           cell.gameObject.GetComponent<GreenCellStatus>().SetSelected();
        }
    }
    #region controlValue
    public void Water_OnPlusButtonClick()
    {
        water++;
        waterText.text = water.ToString();
    }

    public void Water_OnMinusButtonClick()
    {
        water--;
        waterText.text = water.ToString();
    }

    public void Water_OnOKButtonClick()
    {
        _greenCellSelected.GetComponent<GreenCellStatus>().SetWaterValue(water);
        _greenCellSelected.GetComponent<GreenCellStatus>().waterLevel = water;
        _greenCellSelected.GetComponent<GreenCellStatus>().display[2].GetComponentInChildren<Text>().text = "Water : " + water.ToString();
        
        
    }
    public void PH_OnPlusButtonClick()
    {
        ph++;
        phText.text = ph.ToString();
    }

    public void PH_OnMinusButtonClick()
    {
        ph--;
        phText.text = ph.ToString();
    }

    public void PH_OnOKButtonClick()
    {
        _greenCellSelected.GetComponent<GreenCellStatus>().SetPHValue(ph);
        _greenCellSelected.GetComponent<GreenCellStatus>().phLevel = ph;
        _greenCellSelected.GetComponent<GreenCellStatus>().display[3].GetComponentInChildren<Text>().text = "PH    : " + ph.ToString();
    }
    public void Nut_OnPlusButtonClick()
    {
        nutrient++;
        nutrientText.text = nutrient.ToString();
    }

    public void Nut_OnMinusButtonClick()
    {
        nutrient--;
        nutrientText.text = nutrient.ToString();
    }

    public void Nut_OnOKButtonClick()
    {
        _greenCellSelected.GetComponent<GreenCellStatus>().SetNutrientValue(nutrient);
        _greenCellSelected.GetComponent<GreenCellStatus>().sunLevel = nutrient;
        _greenCellSelected.GetComponent<GreenCellStatus>().display[4].GetComponentInChildren<Text>().text = "Sun   : " + nutrient.ToString();
    }
    #endregion
}
