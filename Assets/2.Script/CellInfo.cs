
public class CellInfo
{

	private int _id;
	private string _name;
	private string _date;
	private int _water;
	private float _ph;
	private int _nutrient;
	private bool _selected;
	private float _height;
	private int _leaves;
	private string _text;

	public CellInfo (int id, string name, string date, int water, float ph, int nutrient, float height, int leave, string text, bool selected)
	{
		_id = id;
		_name = name;
		_date = date;
		_water = water;
		_ph = ph;
		_nutrient = nutrient;
		_height = height;
		_leaves = leave;
		_text = text;
		_selected = selected;
	}

	public float Height {
		get{ return _height; }
		set{ _height = value; }
	}

	public int Leaves {
		get{ return _leaves; }
		set{ _leaves = value; }
	}

	public string Text {
		get{ return _text; }
		set{ _text = value; }
	}

	public int ID {
		get { return _id; }
		set { _id = value; }
	}

	public string Name {
		get { return _name; }
		set { _name = value; }
	}
	public string GetText(){
		return _text;
	}
	public string Date {
		get { return _date; }
		set { _date = value; }
	}

	public int Water {
		get { return _water; }
		set { _water = value; }
	}

	public float PH {
		get { return _ph; }
		set { _ph = value; }
	}

	public int Ingredient {
		get{ return _nutrient; }
		set{ _nutrient = value; }
	}

	public bool Select {
		get { return _selected; }
		set { _selected = value; }
	}
}
