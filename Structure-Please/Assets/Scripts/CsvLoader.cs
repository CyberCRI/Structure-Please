using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CsvLoader 
{
	public static List<Dictionary<string, string>> loadCsv(string csv) 
	{
		string[] lines = csv.Split("\n"[0]); // split on newline

		string[] headings = splitLine(lines[0]);
		var results = new List<Dictionary<string, string>>();
		for( int i = 1; i < lines.Length; i++ ) 
		{
			var lineValues = splitLine(lines[i]);
			var lineDict = new Dictionary<string, string>();
			for( int j = 0; j < headings.Length; j++ ) 
			{
				lineDict[headings[i]] = lineValues[i];
			}

			results.Add(lineDict);
		}

		return results;
	}


	public static string[] splitLine(string line) 
	{
		return line.Split(","[0]); // split on comma
	}
}
