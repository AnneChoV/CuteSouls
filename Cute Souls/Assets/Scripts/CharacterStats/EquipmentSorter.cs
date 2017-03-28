using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSorter : MonoBehaviour {

    //[ReadOnly] public CSVFileReader m_csvFileReader;
    public TextAsset equipmentFile;
    string[,] equipment;


    private void OnValidate()
    {
       // m_csvFileReader = GetComponent<CSVFileReader>();
        equipment = CSVFileReader.ReadData(equipmentFile);
    }

    void Start()
    {
        SortEquipment();
    }

    public void SortEquipment()
    {
        int numberOfClasses = equipment.GetLength(0);
        //Probably reference each of the classes via an archetype array and input their available equipments via their reference. Probably wanna make the character ones static?
    }
    
}
