using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
class Data
{
    public string name;
    public List<string> likes;
    public int level;
}
public class Datum
{
    public List<string> datas;
}

public class UpdateMananger : MonoBehaviour
{
    void Start()
    {
        var json = @"
			{
    			""name"": ""Park"",
				""likes"": [
        			""dog"",        
        			""cat""
    			],
    			""level"": 10
			}
		";

        var tree = @"
            {
              ""data"": [
               {
                  ""_id"": ""578325f55c5ba443d06fdfad"",
                  ""cam_stale_data_flag"": ""False"",
                  ""day"": ""2016-07-10"",
                  ""device_id"": ""2b0038000147353138383138"",
                  ""device_name"": ""photon9"",
                  ""growth"": ""9012"",
                  ""height"": ""350"",
                  ""last_camshot_time"": ""Fri, 08 Jul 2016 18:11:37 GMT"",
                  ""last_heard"": ""Fri, 08 Jul 2016 17:27:45 GMT"",
                  ""nutrient_conductivity"": ""3.810"",
                  ""phVal"": ""5.04"",
                  ""plant_id"": ""91"",
                  ""read_time"": ""Sun, 10 Jul 2016 21:51:14 GMT"",
                  ""stale_device_data"": ""True"",
                  ""time_between_water"": ""240"",
                  ""time_for_water"": ""15""
                }
              ]
            }
      ";
  
        var data = JsonUtility.FromJson<Data>(json);
        var treeData = JsonUtility.FromJson<Datum>(json);
       
        Debug.Log(data.name); // Park
        Debug.Log(data.level); // 10

       foreach (var v in data.likes)
        {
            Debug.Log(v);
        }
    }
}