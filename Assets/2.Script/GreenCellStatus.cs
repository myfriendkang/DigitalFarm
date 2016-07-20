using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GreenCellStatus : MonoBehaviour {
    #region CellInfo Calss
    public class CellInfo
    {

        private string  _name;
        private string _date;
        private int _water;
        private int _ph;
        private int _sun;
		private int _id;

		public CellInfo(string name, string date, int water, int phLevel, int sunLight, int id)
        {
            _name = name;
            _date = date;
            _water = water;
            _ph = phLevel;
            _sun = sunLight;
			_id = id;
        }
		public void SetID(int id){
			_id = id;
		}
        public void SetName(string str)
        {
            _name = str;
        }
        public void SetDate(string str)
        {
            _date = str;
        }
        public void SetWater(int amount)
        {
            _water = amount;
        }
        public void SetPH(int ph)
        {
            _ph = ph;
        }
        public void SetSunLight(int sun)
        {
            _sun = sun;
        }

        public string GetName()
        {
            return _name;
        }
        public string GetDate()
        {
            return _date;
        }
        public float GetWater()
        {
            return _water;
        }
        public float GetPH()
        {
            return _ph;
        }
        public float GetSun()
        {
            return _sun;
        }
		public int GetID(){
			return _id;
		}
    }
    #endregion
    public string nameStr;
    public string dateStr;
    public int waterLevel;
    public int phLevel;
    public int sunLevel;
	public int plantID;

    public InputField[] display;
	public GameObject cameraManager;
    /*
     *display[0] = Name
     *display[1] = Date
     *display[2] = Water
     *display[3] = PH
     *display[4] = Sun
     */
    public Sprite[] images;
    /*images[0] = default
     *images[1] = outline
     *images[2] = clicked
     */
     
    CellInfo cellInfo = new CellInfo("_empty", "none", 0, 0, 0, 0);
    public bool selectCell = false;
    // Use this for initialization
    void Start () {
        selectCell = false;
        cellInfo.SetName(nameStr);
        cellInfo.SetDate(dateStr);
        cellInfo.SetPH(phLevel);
        cellInfo.SetSunLight(sunLevel);
        cellInfo.SetWater(waterLevel);
		cellInfo.SetID (plantID);
    }
	
	// Update is called once per frame
	void Update () {
        SetCellInfo();
    }
    void SetCellInfo()
    {

    }

    public void OnGreenCellClick()
    {
		Debug.Log (cellInfo.GetID ());
		cameraManager.GetComponent<ControlCamera> ().FocusObj (plantID);
		display[0].GetComponentInChildren<Text>().text = "Name  : " + cellInfo.GetName();
        display[1].GetComponentInChildren<Text>().text = "Date  : " + cellInfo.GetDate();
        display[2].GetComponentInChildren<Text>().text = "Water : " + cellInfo.GetWater();
        display[3].GetComponentInChildren<Text>().text = "PH    : " + cellInfo.GetPH();
        display[4].GetComponentInChildren<Text>().text = "Nutrient   : " + cellInfo.GetSun();
        if (selectCell == false)
        {
            selectCell = true;
        }
    }

    public void ShowDefault()
    {
        this.gameObject.GetComponent<Image>().sprite = images[0];
    }
    public void ShowOutline()
    {
        this.gameObject.GetComponent<Image>().sprite = images[1];
    }
    public void ShowSelected()
    {
        this.gameObject.GetComponent<Image>().sprite = images[2]; 
    }
    public string GetNameOfCell()
    {
        return cellInfo.GetName();
    }
    public int GetWaterOfCell()
    {
        return Convert.ToInt32(cellInfo.GetWater());
    }
    public int GetPhOfCell()
    {
        return Convert.ToInt32(cellInfo.GetPH());
    }
    public int GetNutrientOfCell()
    {
        return Convert.ToInt32(cellInfo.GetSun());
    }
    public void SetSelected()
    {
        selectCell = false;
    }
    public void SetWaterValue(int water)
    {
        cellInfo.SetWater(water);
    }
    public void SetPHValue(int ph)
    {
        cellInfo.SetPH(ph);
    }
    public void SetNutrientValue(int nut)
    {
        cellInfo.SetSunLight(nut);
    }
}
