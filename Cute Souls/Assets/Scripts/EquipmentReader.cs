using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;


public class EquipmentReader : MonoBehaviour
{
    public TextAsset EquipmentCSV;

    private char LineSeperater = '\n';
    private char fieldSeperator = ',';
    public string[,] stringArray;

    private void Start()
    {
        // ReadFile();
        ReadData();
    }


    public string[,] ReadData()
    {

        int lineNumber = EquipmentCSV.text.Split(LineSeperater).Length - 1;    //Length returns a number one higher than it really is.
        int fieldsPerline = (EquipmentCSV.text.Split(fieldSeperator).Length - 1) / (lineNumber - 1);  //There are no commas at the end of the line, character number needs to be negated here.

        stringArray = new string[lineNumber, fieldsPerline];

        string[] Lines = EquipmentCSV.text.Split(LineSeperater);   //Split each line into which character we are talking about.
        for (int x = 0; x < lineNumber; x++)
        { 
            string[] fields = Lines[x].Split(fieldSeperator);
            for (int y = 0; y < fieldsPerline; y++)
            {
                stringArray[x, y] = fields[y];
                Debug.Log(fields[y]);
            }
        }
        return stringArray;
    }
}
