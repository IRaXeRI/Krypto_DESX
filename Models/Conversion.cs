using System;
using System.Collections.Generic;
using System.Text;

namespace PKG_V1;

public class Conversion
{
    //convert string to array of bool representing bits
    public bool[] ConvertKeyToBoolArray(string key) {
        bool[] answer = new bool[64];
        for (int i = 0; i < 4; i++) {
            char a = key[i];
            string bits = Convert.ToString(a, 2).PadLeft(16, '0');
            for (int j = 0; j < 16; j++) {
                if (bits[j] == '1') {
                    answer[i * 16 + j] = true;
                }
                else {
                    answer[i * 16 + j] = false;
                }
            }
        }
        return answer;
    }

    public List<bool[]> SplitDataForEncryption(string Data) {
        List<bool[]> DataSplit = new List<bool[]>();
        string tempData = Data;
        bool[] tempBoolArray = new bool [64];
        //Splitting data for full 64-bit blocks (char has 16 bits)
        while (tempData.Length / 4 > 0) {
            tempBoolArray = new bool [64];
            for (int i = 0; i < 4; i++) {
                char a = tempData[i];
                string bits = Convert.ToString(a, 2).PadLeft(16, '0');
                for (int j = 0; j < 16; j++) {
                    if (bits[j] == '1') {
                        tempBoolArray[i * 16 + j] = true;
                    }
                    else {
                        tempBoolArray[i * 16 + j] = false;
                    }
                }
            }
            DataSplit.Add(tempBoolArray);
            tempData = tempData.Substring(4, tempData.Length - 4);
        }
        int amountAdded=0;
        tempBoolArray = new bool [64];
        if (tempData.Length % 4 != 0) {
            amountAdded = 4 - tempData.Length;
            for (int i = 0; i < tempData.Length; i++) {
                char a = tempData[i];
                string bits = Convert.ToString(a, 2).PadLeft(16, '0');
                for (int j = 0; j < 16; j++) { 
                    if (bits[j] == '1') { 
                        tempBoolArray[i * 16 + j] = true;
                    }
                    else {
                        tempBoolArray[i * 16 + j] = false;
                    }
                }
            }
            DataSplit.Add(tempBoolArray);
        }
        //Adding last block with only number of added chars in previous block or empty block at the end of message
        bool[] temp = new bool[64];
        switch (amountAdded) { 
            case 0:
                DataSplit.Add(temp);
                break;
            case 1: 
                temp[7] = true;
                DataSplit.Add(temp);
                break;
            case 2:
                temp[6] = true;
                DataSplit.Add(temp);
                break;
            case 3:
                temp[6] = true;
                temp[7] = true;
                DataSplit.Add(temp);
                break;
            }
        return DataSplit;
    }

    public List<bool[]> SplitDataForDecryption(string Data) {
        List<bool[]> DataSplit = new List<bool[]>();
        string tempData = Data;
        bool[] tempBoolArray = new bool [64];
        //Splitting data for full 64-bit blocks (char has 16 bits)
        while (tempData.Length / 4 > 0) {
            tempBoolArray = new bool [64];
            for (int i = 0; i < 4; i++)
            {
                char a = tempData[i];
                string bits = Convert.ToString(a, 2).PadLeft(16, '0');
                for (int j = 0; j < 16; j++)
                {
                    if (bits[j] == '1')
                    {
                        tempBoolArray[i * 16 + j] = true;
                    }
                    else
                    {
                        tempBoolArray[i * 16 + j] = false;
                    }
                }
            }

            DataSplit.Add(tempBoolArray);
            tempData = tempData.Substring(4, tempData.Length - 4);
        }
        return DataSplit;
    }

    public bool[] ConvertSboxAnswerToBoolArray(byte a) {
        bool[] answer = new bool[4];
        for (int i = 0; i < 4; i++) {
            if (a % 2 == 1) {
                answer[3-i] = true;
            }
            else {
                answer[3-i] = false;
            }
            a /= 2;
        }
        return answer;
    }
    
    public string ConvertEncryptedDataToString(List<bool[]> dataBlocks) {
        string answer="";
        int temp;
        char a;
        for (int i = 0; i < dataBlocks.Count; i++) {
            for (int j = 0; j < 4; j++) {
                temp = 0;
                for (int k = 0; k < 16; k++) {
                    if (dataBlocks[i][j * 16 + k]) {
                        temp += Convert.ToInt32(Math.Pow(2, 15 - k));
                    }
                } 
                a = Convert.ToChar(temp);
                answer += a;
            }
        }
        return answer;
    }

    public string ConvertDecryptedDataToString(List<bool[]> dataBlocks) {
        string answer="";
        int temp;
        char a;
        for (int i = 0; i < dataBlocks.Count-1; i++) {
            for (int j = 0; j < 4; j++) {
                temp = 0;
                for (int k = 0; k < 16; k++) { 
                    if (dataBlocks[i][j * 16 + k]) {
                        temp += Convert.ToInt32(Math.Pow(2, 15 - k));
                    }
                }
                a = Convert.ToChar(temp);
                answer += a;
            }
        }
        int amountAdded = 0;
        if (dataBlocks[dataBlocks.Count-1][7]) {
            amountAdded += 1;
        }
        if (dataBlocks[dataBlocks.Count-1][6]) {
            amountAdded += 2;
        }
        answer = answer.Substring(0, answer.Length-amountAdded);
        return answer;
    }

    public (bool[], bool[]) SplitIPIntoHalves(bool[] data) {
        bool[] tempLeftHalf = new bool[32];
        bool[] tempRightHalf = new bool[32];
        for (int i = 0; i < 32; i++) {
            tempLeftHalf[i] = data[i];
            tempRightHalf[i] = data[i + 32];
        }
        return (tempLeftHalf, tempRightHalf);
    }
}