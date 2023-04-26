using System;

namespace PKG_V1;

public class Generator
{
    private Transformations trans = new Transformations();
    private Conversion conv = new Conversion();
    //table to shift C_n i D_n
    private static readonly short[] Shift = {1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1};

    public string GenerateKey() {
        string answer="";
        char a;
        Random rand = new Random();
        int tempInt;
        for (int i = 0; i < 4; i++) {
            int IntToChar = 0;
            for (int j = 0; j < 16; j++) {
                tempInt = rand.Next();
                tempInt %= 2;
                IntToChar += tempInt * Convert.ToInt32(Math.Pow(2, Convert.ToDouble(j)));
            }
            a = Convert.ToChar(IntToChar);
            answer += a;
        }
        return answer;
    }

    //create sets of keys C and D basing on key_PC1 doing n iterations where 1<=n<=16
    //by using pattern: C_i = C_{i-1} << shift[i]
    public (bool[,], bool[,]) CreateKeySetsCD(bool[] Key_PC1) {
        bool[,] KeysC = new bool[17, 28];
        bool[,] KeysD = new bool[17, 28];
        for (int i = 0; i < 28; i++) {                                  //generate C_0 and D_0
            KeysC[0, i] = Key_PC1[i];                                   //iterate through left part of K+
            KeysD[0, i] = Key_PC1[i+28];                                //iterate through right part of K+
        }
        for (int i = 1; i < 17; i++) {
            for (int j = 0; j < 28; j++) {
                KeysC[i, j] = KeysC[i - 1, (j + Shift[i-1]) % 28];      //create C_i basing on C_i-1 and shift
                KeysD[i, j] = KeysD[i - 1, (j + Shift[i-1]) % 28];      //create D_i basing on D_i-1 and shift
            }
        }
        return (KeysC, KeysD);
    }
    
    //Create full set of Keys K
    public bool[,] CreateKeySetK(bool[,] KeysC, bool[,] KeysD) {
        bool[,] answer = new bool[17, 56];
        for (int i = 1; i < 17; i++) {
            for (int j = 0; j < 28; j++) {            //generate K_i
                answer[i, j] = KeysC[i,j];             //iterate through C_i
                answer[i, j + 28] = KeysD[i,j];        //iterate through D_i
            }
        }
        return answer;
    }
    
    public bool[,] CreateKeySetKReversed(bool[,] KeysC, bool[,] KeysD) {
        bool[,] answer = new bool[17, 56];
        for (int i = 1; i < 17; i++) {
            for (int j = 0; j < 28; j++) {            //generate K_i
                answer[i, j] = KeysC[17-i,j];             //iterate through C_i
                answer[i, j + 28] = KeysD[17-i,j];        //iterate through D_i
            }
        }
        return answer;
    }
    
    public (bool[,], bool[,]) GenerateSetsLN(bool[] initLeftHalf, bool[] initRightHalf, bool[,] keys)
    {
        bool[,] GenLeftHalf = new bool[17, 32];
        bool[,] GenRightHalf = new bool[17, 32];
        for (int i = 0; i < 32; i++) {
            GenLeftHalf[0, i] = initLeftHalf[i];
            GenRightHalf[0, i] = initRightHalf[i];
        }

        for (int i = 1; i < 17; i++) {
            bool[] temp = FunctionF(GetOneHalf(GenLeftHalf, GenRightHalf,i-1,false), keys, i);
            bool[] temp2 = trans.XOR(temp, GetOneHalf(GenLeftHalf, GenRightHalf, i - 1, true), 32);
            for (int j = 0; j < 32; j++) {
                GenLeftHalf[i, j] = GenRightHalf[i - 1, j];
                GenRightHalf[i, j] = temp2[j]; 
            }
        }
        return (GenLeftHalf, GenRightHalf);
    }
    
    public bool[] FunctionF(bool[] data, bool[,] keys, int iteration) {
        bool[] temp = trans.ETransformation(data);
        bool[] temp2 = trans.XOR(temp, GetK_i(keys, iteration), 48);
        bool[,] sets = new bool[8, 6];
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 6; j++) {
                sets[i, j] = temp2[i*6+j];
            }
        }
        temp2 = Sboxes(sets);
        return trans.PTransformation(temp2);
    }

    public bool[] GetOneHalf(bool[,] genLeftHalf, bool[,] genRightHalf, int index, bool left) {
        bool[] tempHalf = new bool[32];
        for (int i = 0; i < 32; i++) {
            if (left) {
                tempHalf[i] = genLeftHalf[index, i];
            }
            else {
                tempHalf[i] = genRightHalf[index, i];
            }
        }
        return tempHalf;
    }
    
    public bool[] GetK_i(bool[,] keys, int index) {
        bool[] tempKey = new bool[48];
        for (int i = 0; i < 48; i++) {
            tempKey[i] = keys[index, i];
        }
        return tempKey;
    }

    public bool[] Sboxes(bool[,] sets) {
        bool[] answer = new bool[32];
        bool[] temp;
        int[] tempInts = new int[6];
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 6; j++) {
                if (sets[i, j]) {
                    tempInts[j] = 1;
                }
                else {
                    tempInts[j] = 0;
                }
            }
            int x = tempInts[0] * 2 + tempInts[5];
            int y = tempInts[1] * 8 + tempInts[2] * 4 + tempInts[3] * 2 + tempInts[4];
            temp = trans.SBox(conv,i, x, y);
            for (int j = 0; j < 4; j++) {
                answer[i * 4 + j] = temp[j];
            }
        }
        return answer;
    }
    
    public bool[] GenerateLastBlock(bool[,] initLeftHalf, bool[,] initRightHalf) {
        bool[] answer = new bool[64];
        for (int i = 0; i < 32; i++) {
            answer[i] = initRightHalf[16, i];
            answer[i + 32] = initLeftHalf[16, i];
        }
        return answer;
    }
}