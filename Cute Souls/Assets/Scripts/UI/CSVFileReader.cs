using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CSVFileReader {

    private static char LineSeperater = '\n';
    private static char fieldSeperator = ',';

    public static string[,] ReadData(TextAsset CSVtextFile)
    {
        int lineNumber = CSVtextFile.text.Split(LineSeperater).Length - 1;    //Length returns a number one higher than it really is.
        int fieldsPerline = (CSVtextFile.text.Split(fieldSeperator).Length - 1) / (lineNumber - 1);
        //Since there are no commas at the end of the line, lineNumber needs to be negated by one because each lines is missing one.

        string[,] stringArray;
        stringArray = new string[lineNumber, fieldsPerline];

        string[] Lines = CSVtextFile.text.Split(LineSeperater);   //Split each line into which character we are talking about.
        for (int x = 0; x < lineNumber; x++)
        {
            string[] fields = Lines[x].Split(fieldSeperator);
            for (int y = 0; y < fieldsPerline; y++)
            {
                stringArray[x, y] = fields[y];
            }
        }
        return stringArray;
    }
}
