using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizable
{
	public static IRandomizable GetRandomItem (List<IRandomizable> list) 
	{		
		int sum = 0;

		for (int i = 0; i < list.Count; ++i) {
			sum += list [i].GetWeight ();
		}

		double randomWeight = Random.Range (0, sum);
		int total = 0;
		for (int i = 0; i < list.Count; ++i) {
			total += list [i].GetWeight ();
			if (randomWeight < total) {
				return  list [i];
			}
		}

		return list [0];
	}
}
