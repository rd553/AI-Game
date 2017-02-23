using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class NDExtension  {

	public static System.Random random = new System.Random();

	public static void FYShuffle<T>(this List<T> list){
		int c = list.Count;  
		while (c > 1) {  
			c--;  
			int k = random.Next(c + 1);  
			T value = list[k];  
			list[k] = list[c];  
			list[c] = value;  
		}  
	}
}
