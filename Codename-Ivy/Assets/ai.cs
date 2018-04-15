using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TensorFlow;

public class ai : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RunImage()
	{
		TextAsset graphModel = Resources.Load ("frozen_model.bytes") as TextAsset;
		TFGraph graph = new TFGraph ();
		graph.Import (graphModel.bytes);
		TFSession session = new TFSession (graph);
		var runner = session.GetRunner ();
		runner.AddInput (graph ["Placeholder"] [0], new float[]{ placeholder_value1, placeholder_value2 });
		runner.Fetch (graph["final_result"][0]);
		float[,] recurrent_tensor = runner.Run () [0].GetValue () as float[,];
	}
}
