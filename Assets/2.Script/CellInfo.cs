
public class CellInfo {

		private int _id;
		private string _name;
		private string _date;
		private int _water;
		private float _ph;
		private int _nutrient;
		private bool _selected;
		
	   public CellInfo(int id, string name, string date, int water, float ph, int nutrient, bool selected){
			_id = id;
			_name = name;
			_date = date;
			_water = water;
			_ph = ph;
		_nutrient = nutrient;
			_selected = selected;
		}
		public int ID{
			get { return _id;  }
			set { _id = value; }
		}
		public string Name{
			get { return _name;  }
			set { _name = value; }
		}
		public string Date{
			get { return _date;  }
			set { _date = value; }
		}
		public int Water {
			get { return _water;  }
			set { _water = value; }
		}
		public float PH {
			get { return _ph;  }
			set { _ph = value; }
		}
		public int Ingredient{
			get{ return _nutrient;  }
			set{ _nutrient = value; }
		}
		public bool Select{
			get { return _selected;  }
			set { _selected = value; }
		}
}
