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

    public List<bool[]> SplitDataForEncryption(byte[] Data) {
        List<bool[]> DataSplit = new List<bool[]>();
        bool[] tempBoolArray = new bool [64];
        int blocksCompleted = 0;
        //Splitting data for full 64-bit blocks (byte has 8 bits)
        int excededNotFullBlocks = Data.Length % 8;
        while (Data.Length > blocksCompleted * 8 + excededNotFullBlocks) {
            tempBoolArray = new bool [64];
            for (int i = 0; i < 8; i++) {
                byte a = Data[blocksCompleted * 8 + i];
                string bits = Convert.ToString(a, 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++) {
                    if (bits[j] == '1') {
                        tempBoolArray[i * 8 + j] = true;
                    }
                    else {
                        tempBoolArray[i * 8 + j] = false;
                    }
                }
            }
            DataSplit.Add(tempBoolArray);
            blocksCompleted++;
        }
        int amountAdded=0;
        tempBoolArray = new bool [64];
        if (Data.Length%(blocksCompleted*8)!=0) {
            amountAdded = 8 - Data.Length%(blocksCompleted*8);
            for (int i = 0; i < 8 - amountAdded; i++) {
                byte a = Data[blocksCompleted * 8 + i];
                string bits = Convert.ToString(a, 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++) { 
                    if (bits[j] == '1') { 
                        tempBoolArray[i * 8 + j] = true;
                    }
                    else {
                        tempBoolArray[i * 8 + j] = false;
                    }
                }
            }
            DataSplit.Add(tempBoolArray);
        }
        //Adding last block with only number of added chars in previous block or empty block at the end of message
        bool[] temp = new bool[64];
        string tempString = Convert.ToString(amountAdded, 2).PadLeft(8, '0');
        for (int j = 0; j < 8; j++) { 
            if (tempString[j] == '1') { 
                temp[j] = true;
            }
            else {
                temp[j] = false;
            }
        }
        DataSplit.Add(temp);
        return DataSplit;
    }

    public List<bool[]> SplitDataForDecryption(byte[] Data) {
        List<bool[]> DataSplit = new List<bool[]>();
        bool[] tempBoolArray = new bool [64];
        int blocksCompleted = 0;
        //Splitting data for full 64-bit blocks (byte has 8 bits)
        while (Data.Length > blocksCompleted * 8) {
            tempBoolArray = new bool [64];
            for (int i = 0; i < 8; i++) {
                byte a = Data[blocksCompleted * 8 + i];
                string bits = Convert.ToString(a, 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++) {
                    if (bits[j] == '1') {
                        tempBoolArray[i * 8 + j] = true;
                    }
                    else {
                        tempBoolArray[i * 8 + j] = false;
                    }
                }
            }
            DataSplit.Add(tempBoolArray);
            blocksCompleted++;
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
    
    public byte[] ConvertEncryptedDataToString(List<bool[]> dataBlocks) {
        List<byte> answer = new();
        int temp;
        for (int i = 0; i < dataBlocks.Count; i++) {
            for (int j = 0; j < 8; j++) {
                temp = 0;
                for (int k = 0; k < 8; k++)
                {
                    if (dataBlocks[i][j * 8 + k])
                    {
                        temp += Convert.ToInt32(Math.Pow(2, 7 - k));
                    }
                }
                answer.Add(Convert.ToByte(temp));
            }
        }
        return answer.ToArray();
    }

    public byte[] ConvertDecryptedDataToString(List<bool[]> dataBlocks) {
        List<byte> answer = new();
        int temp;
        for (int i = 0; i < dataBlocks.Count - 1; i++) {
            for (int j = 0; j < 8; j++) {
                temp = 0;
                for (int k = 0; k < 8; k++)
                {
                    if (dataBlocks[i][j * 8 + k])
                    {
                        temp += Convert.ToInt32(Math.Pow(2, 7 - k));
                    }
                }
                answer.Add(Convert.ToByte(temp));
            }
        }
        int amountAdded = 0;
        for (int i = 0; i < 8; i++) {
            if (dataBlocks[dataBlocks.Count-1][i])
            amountAdded += Convert.ToInt32(Math.Pow(2, 7 - i));
        }
        for (int i = 0; i < amountAdded; i++) {
            answer.RemoveAt(answer.Count-1);
        }
        return answer.ToArray();
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