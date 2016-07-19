using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GreenCellEvent : MonoBehaviour {
    #region CellInfo Calss
    public class CellInfo
    {

        private string _name;
        private string _date;
        private float _water;
        private float _ph;
        private float _sun;

        public CellInfo(string name, string date, float water, float phLevel, float sunLight)
        {
            _name = name;
            _date = date;
            _water = water;
            _ph = phLevel;
            _sun = sunLight;
        }

        public void SetName(string str)
        {
            _name = str;
        }
        public void SetDate(string str)
        {
            _date = str;
        }
        public void SetWater(float amount)
        {
            _water = amount;
        }
        public void SetPH(float ph)
        {
            _ph = ph;
        }
        public void SetSunLight(float sun)
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
    }
    #endregion
    public string nameStr;
    public string dateStr;
    public float waterLevel;
    public float phLevel;
    public float sunLevel;
    public InputField[] display;
    /*InputField[0] = Name
      InputField[1] = Date
      InputField[2] = Water
      InputField[3] = PH
      InputField[4] = Sun
   */
    CellInfo cellInfo = new CellInfo("_empty", "none", 0.0f, 0.0f, 0.0f);
    bool selectCell = false;
    // Use this for initialization
    void Start()
    {
        selectCell = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetCellInfo();
    }
    public bool isSelected()
    {
        if (selectCell == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void SetCellInfo()
    {
        cellInfo.SetName(nameStr);
        cellInfo.SetDate(dateStr);
        cellInfo.SetPH(phLevel);
        cellInfo.SetSunLight(sunLevel);
        cellInfo.SetWater(waterLevel);
    }

    public void OnGreenCellClick()
    {
        display[0].GetComponentInChildren<Text>().text = "Name  : " + cellInfo.GetName();
        display[1].GetComponentInChildren<Text>().text = "Date  : " + cellInfo.GetDate();
        display[2].GetComponentInChildren<Text>().text = "Water : " + cellInfo.GetWater();
        display[3].GetComponentInChildren<Text>().text = "PH    : " + cellInfo.GetPH();
        display[4].GetComponentInChildren<Text>().text = "Sun   : " + cellInfo.GetSun();

        if (selectCell == false)
        {
            selectCell = true;
        }
    }
}
