using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFighterClass : BaseClass
{
    [SerializeField]
    private BaseJob jobRef;

    public int strMod;
    public int dexMod;
    public int conMod;
    public int intMod;
    public int wisMod;
    public int chrMod;

    public BaseFighterClass()
    {
        //change when rolling is implamented
        Strength = 18;
        Dexterity = 12;
        Constitution = 12;
        Intelligence = 3;
        Wisdom = 10;
        Charisma = 9;

        #region StatMods
        switch (Strength)
        {
            case 0:
                strMod = -5;
                break;
            case 1:
                strMod = -5;
                break;
            case 2:
                strMod = -4;
                break;
            case 3:
                strMod = -4;
                break;
            case 4:
                strMod = -3;
                break;
            case 5:
                strMod = -3;
                break;
            case 6:
                strMod = -2;
                break;
            case 7:
                strMod = -2;
                break;
            case 8:
                strMod = -1;
                break;
            case 9:
                strMod = -1;
                break;
            case 10:
                strMod = 0;
                break;
            case 11:
                strMod = 0;
                break;
            case 12:
                strMod = 1;
                break;
            case 13:
                strMod = 1;
                break;
            case 14:
                strMod = 2;
                break;
            case 15:
                strMod = 2;
                break;
            case 16:
                strMod = 3;
                break;
            case 17:
                strMod = 3;
                break;
            case 18:
                strMod = 4;
                break;
            case 19:
                strMod = 4;
                break;
            case 20:
                strMod = 5;
                break;
        }
        switch (Dexterity)
        {
            case 0:
                dexMod = -5;
                break;
            case 1:
                dexMod = -5;
                break;
            case 2:
                dexMod = -4;
                break;
            case 3:
                dexMod = -4;
                break;
            case 4:
                dexMod = -3;
                break;
            case 5:
                dexMod = -3;
                break;
            case 6:
                dexMod = -2;
                break;
            case 7:
                conMod = -2;
                break;
            case 8:
                dexMod = -1;
                break;
            case 9:
                dexMod = -1;
                break;
            case 10:
                dexMod = 0;
                break;
            case 11:
                dexMod = 0;
                break;
            case 12:
                dexMod = 1;
                break;
            case 13:
                dexMod = 1;
                break;
            case 14:
                dexMod = 2;
                break;
            case 15:
                dexMod = 2;
                break;
            case 16:
                dexMod = 3;
                break;
            case 17:
                dexMod = 3;
                break;
            case 18:
                dexMod = 4;
                break;
            case 19:
                dexMod = 4;
                break;
            case 20:
                dexMod = 5;
                break;
        }
        switch (Constitution)
        {
            case 0:
                conMod = -5;
                break;
            case 1:
                conMod = -5;
                break;
            case 2:
                conMod = -4;
                break;
            case 3:
                conMod = -4;
                break;
            case 4:
                conMod = -3;
                break;
            case 5:
                conMod = -3;
                break;
            case 6:
                conMod = -2;
                break;
            case 7:
                conMod = -2;
                break;
            case 8:
                conMod = -1;
                break;
            case 9:
                conMod = -1;
                break;
            case 10:
                conMod = 0;
                break;
            case 11:
                conMod = 0;
                break;
            case 12:
                conMod = 1;
                break;
            case 13:
                conMod = 1;
                break;
            case 14:
                conMod = 2;
                break;
            case 15:
                conMod = 2;
                break;
            case 16:
                conMod = 3;
                break;
            case 17:
                conMod = 3;
                break;
            case 18:
                conMod = 4;
                break;
            case 19:
                conMod = 4;
                break;
            case 20:
                conMod = 5;
                break;
        }
        switch (Intelligence)
        {
            case 0:
                intMod = -5;
                break;
            case 1:
                intMod = -5;
                break;
            case 2:
                intMod = -4;
                break;
            case 3:
                intMod = -4;
                break;
            case 4:
                intMod = -3;
                break;
            case 5:
                intMod = -3;
                break;
            case 6:
                intMod = -2;
                break;
            case 7:
                intMod = -2;
                break;
            case 8:
                intMod = -1;
                break;
            case 9:
                intMod = -1;
                break;
            case 10:
                intMod = 0;
                break;
            case 11:
                intMod = 0;
                break;
            case 12:
                intMod = 1;
                break;
            case 13:
                intMod = 1;
                break;
            case 14:
                intMod = 2;
                break;
            case 15:
                intMod = 2;
                break;
            case 16:
                intMod = 3;
                break;
            case 17:
                intMod = 3;
                break;
            case 18:
                intMod = 4;
                break;
            case 19:
                intMod = 4;
                break;
            case 20:
                intMod = 5;
                break;
        }
        switch (Wisdom)
        {
            case 0:
                wisMod = -5;
                break;
            case 1:
                wisMod = -5;
                break;
            case 2:
                wisMod = -4;
                break;
            case 3:
                wisMod = -4;
                break;
            case 4:
                wisMod = -3;
                break;
            case 5:
                wisMod = -3;
                break;
            case 6:
                wisMod = -2;
                break;
            case 7:
                wisMod = -2;
                break;
            case 8:
                wisMod = -1;
                break;
            case 9:
                wisMod = -1;
                break;
            case 10:
                wisMod = 0;
                break;
            case 11:
                wisMod = 0;
                break;
            case 12:
                wisMod = 1;
                break;
            case 13:
                wisMod = 1;
                break;
            case 14:
                intMod = 2;
                break;
            case 15:
                wisMod = 2;
                break;
            case 16:
                wisMod = 3;
                break;
            case 17:
                wisMod = 3;
                break;
            case 18:
                wisMod = 4;
                break;
            case 19:
                wisMod = 4;
                break;
            case 20:
                wisMod = 5;
                break;
        }
        switch (Charisma)
        {
            case 0:
                chrMod = -5;
                break;
            case 1:
                chrMod = -5;
                break;
            case 2:
                chrMod = -4;
                break;
            case 3:
                chrMod = -4;
                break;
            case 4:
                chrMod = -3;
                break;
            case 5:
                chrMod = -3;
                break;
            case 6:
                chrMod = -2;
                break;
            case 7:
                chrMod = -2;
                break;
            case 8:
                chrMod = -1;
                break;
            case 9:
                chrMod = -1;
                break;
            case 10:
                chrMod = 0;
                break;
            case 11:
                chrMod = 0;
                break;
            case 12:
                chrMod = 1;
                break;
            case 13:
                chrMod = 1;
                break;
            case 14:
                chrMod = 2;
                break;
            case 15:
                chrMod = 2;
                break;
            case 16:
                chrMod = 3;
                break;
            case 17:
                chrMod = 3;
                break;
            case 18:
                chrMod = 4;
                break;
            case 19:
                chrMod = 4;
                break;
            case 20:
                chrMod = 5;
                break;
        }
        #endregion
    }
}
