using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameReset : MonoBehaviour
{
    public BoolValue[] boolsforTesting;
    public FloatValue[] floatsToReset;
    public IntValue[] intsToRest;
    public Material[] shaderstoReset;

    public List<InventoryObject> CharacterInventory;

    // Start is called before the first frame update
    void Start()
    {
        //playerInventory.itemOnStart.Clear();

        for (int i = 0; i < boolsforTesting.Length; i++)
        {
            boolsforTesting[i].initialValue = false;
            boolsforTesting[i].RuntimeValue = boolsforTesting[i].initialValue;
        }

        for (int i = 0; i < shaderstoReset.Length; i++)
        {
            shaderstoReset[i].SetFloat("_Outline", 0f);
        }

        for (int i = 0; i < floatsToReset.Length; i++)
        {
            floatsToReset[i].initialValue = 0;
            floatsToReset[i].RuntimeValue = floatsToReset[i].initialValue;
        }
        for (int i = 0; i < intsToRest.Length; i++)
        {
            intsToRest[i].initialValue = 0;
            intsToRest[i].RuntimeValue = intsToRest[i].initialValue;
        }

        
    }
}
