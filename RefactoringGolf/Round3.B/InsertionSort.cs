using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round3.B
{
    
public class InsertionSort : AbstractSort {

	public override int[] Sort(int[] input) {
		for (var i = 0; i < input.Length - 1; i++) {
			for(var j = i+1;j > 0;j--){
				if(input[j] < input[j-1]){
					Swap(input, j, j-1);
				}
			}
		}
		return input;
	}

}




}
