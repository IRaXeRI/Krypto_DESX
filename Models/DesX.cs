using System.Collections.Generic;

namespace PKG_V1;

public class DesX
{
    // Helper Classes containing essential parts of codes (split for better code readability)
    private readonly Transformations trans = new Transformations();
    private readonly Conversion conv = new Conversion();
    private readonly Generator gen = new Generator();
    
    // list of data split into 64 bit blocks
    private List<bool[]> DataSplit = new List<bool[]>();
    private List<bool[]> IPDataSplit = new List<bool[]>();
    private List<bool[]> EncryptedDataBlock = new List<bool[]>();
    
    // tables to store keys Key1, Key1_PC and Key2 ([n] means it should have n elements)
    private bool[] Key;        // [64] Key is main key used for transformation
    private bool[] Key1;       // [64] Key1 is part of DES-X used to XOR data before using DES
    private bool[] Key2;       // [64] Key2 is part of DES-X used to XOR data after using DES
    private bool[] Key_PC1;    // [56] Key1_PC1 is Key after transformation based on table PC1

    // tables to store keys C_n, D_n & K_n
    private bool[,] KeysC;       // [17, 28] C_n is the left part of K_n, must be separated for transformations
    private bool[,] KeysD;       // [17, 28] D_n is the right part of K_n, must be separated for transformations
    private bool[,] KeysK;       // [17, 56] K_n is a list of keys created by transformations
    private bool[,] Keys_FNL;    // [17, 48] Key1_PC1 is set of keys K after transformation based on table PC2
    private bool[,] LeftHalf;    // [17, 32] LeftHalf is a temporary place to store left part of IP
    private bool[,] RightHalf;   // [17, 32] RightHalf is a temporary place to store right part of IP

    // main function used to encrypt data, requires three string keys and data to encrypt
    public string encrypt(string newData, string K, string K_1, string K_2) {
        bool[] temp;                                              // Adding temporary references used in loop
        bool[] temp2;                                             // Adding temporary references used in loop
        DataSplit = new List<bool[]>();                           // cleaning lists
        IPDataSplit = new List<bool[]>();                         // cleaning lists
        EncryptedDataBlock = new List<bool[]>();                  // cleaning lists
        Key = conv.ConvertKeyToBoolArray(K);                      // Transforming key from string to array of bool for easier use 
        Key1 = conv.ConvertKeyToBoolArray(K_1);                   // Transforming key1 from string to array of bool for easier use 
        Key2 = conv.ConvertKeyToBoolArray(K_2);                   // Transforming key2 from string to array of bool for easier use 
        DataSplit = conv.SplitDataForEncryption(newData);         // Splitting data to 64-bit blocks 
        Key_PC1 = trans.PC1Transformation(Key);                   // Transforming Key using PC1 table
        var KeySetsCD = gen.CreateKeySetsCD(Key_PC1);  // Generating KeysC and KeysD
        KeysC = KeySetsCD.Item1;                                  // Setting reference to KeysC from results of function line above
        KeysD = KeySetsCD.Item2;                                  // Setting reference to KeysC from results of function two lines above
        KeysK = gen.CreateKeySetK(KeysC, KeysD);                  // Generating keysK
        Keys_FNL = trans.PC2Transformation(KeysK);                // Reconstructing Keys K_n basing on PC_2 Table
        for (int i = 0; i < DataSplit.Count; i++) {                                                               // Iterating on every block of data
            temp = trans.XOR(DataSplit[i], Key1, 64);                                                       // XORing block of data with Key1 (DES-X)
            IPDataSplit.Add(trans.IPTransform(temp));                                                         // Transforming block of data basing on IP table
            var Halves = conv.SplitIPIntoHalves(IPDataSplit[i]);                                        // Splitting Data after IP transformation into Left and Right half
            var Halves2 = gen.GenerateSetsLN(Halves.Item1, Halves.Item2, Keys_FNL);  // Creates Sets of L_n and R_N where 1<=n<=16
            LeftHalf = Halves2.Item1;                                                                             // Setting reference to LeftHalf from results of function line above
            RightHalf = Halves2.Item2;                                                                            // Setting reference to KeysC from results of function two lines above
            temp = gen.GenerateLastBlock(LeftHalf, RightHalf);                                                    // Generate Last Block of data (last means it is made from R_16 and L_16)
            temp2 = trans.IPReverseTransformation(temp);                                                          // Performs transformation basing on IPReverse table
            temp = trans.XOR(temp2, Key2, 64);                                                          // XOR block of data with Key2 (DES-X)
            EncryptedDataBlock.Add(temp);                                                                         // Save block of data after transformation into List
        }
        return conv.ConvertEncryptedDataToString(EncryptedDataBlock);
    }
    
    // main function used to encrypt data, requires three string keys and data to encrypt
    public string decrypt(string newData, string K, string K_1, string K_2) {
        bool[] temp;                                              // Adding temporary references used in loop
        bool[] temp2;                                             // Adding temporary references used in loop
        DataSplit = new List<bool[]>();                           // cleaning lists
        IPDataSplit = new List<bool[]>();                         // cleaning lists
        EncryptedDataBlock = new List<bool[]>();                  // cleaning lists
        Key = conv.ConvertKeyToBoolArray(K);                      // Transforming key from string to array of bool for easier use 
        Key1 = conv.ConvertKeyToBoolArray(K_1);                   // Transforming key1 from string to array of bool for easier use 
        Key2 = conv.ConvertKeyToBoolArray(K_2);                   // Transforming key2 from string to array of bool for easier use 
        DataSplit = conv.SplitDataForDecryption(newData);         // Splitting data to 64-bit blocks 
        Key_PC1 = trans.PC1Transformation(Key);                   // Transforming Key using PC1 table
        var KeySetsCD = gen.CreateKeySetsCD(Key_PC1);  // Generating KeysC and KeysD
        KeysC = KeySetsCD.Item1;                                  // Setting reference to KeysC from results of function line above
        KeysD = KeySetsCD.Item2;                                  // Setting reference to KeysC from results of function two lines above
        KeysK = gen.CreateKeySetKReversed(KeysC, KeysD);          // Generating REVERSED!!!! keysK
        Keys_FNL = trans.PC2Transformation(KeysK);                // Reconstructing Keys K_n basing on PC_2 Table
        for (int i = 0; i < DataSplit.Count; i++) {                                                               // Iterating on every block of data
            temp = trans.XOR(DataSplit[i], Key2, 64);                                                       // XORing block of data with Key2 (DES-X)
            IPDataSplit.Add(trans.IPTransform(temp));                                                         // Transforming block of data basing on IP table
            var Halves = conv.SplitIPIntoHalves(IPDataSplit[i]);                                        // Splitting Data after IP transformation into Left and Right half
            var Halves2 = gen.GenerateSetsLN(Halves.Item1, Halves.Item2, Keys_FNL);  // Creates Sets of L_n and R_N where 1<=n<=16
            LeftHalf = Halves2.Item1;                                                                             // Setting reference to LeftHalf from results of function line above
            RightHalf = Halves2.Item2;                                                                            // Setting reference to KeysC from results of function two lines above
            temp = gen.GenerateLastBlock(LeftHalf, RightHalf);                                                    // Generate Last Block of data (last means it is made from R_16 and L_16)
            temp2 = trans.IPReverseTransformation(temp);                                                          // Performs transformation basing on IPReverse table
            temp = trans.XOR(temp2, Key1, 64);                                                          // XOR block of data with Key1 (DES-X)
            EncryptedDataBlock.Add(temp);                                                                         // Save block of data after transformation into List
        }
        return conv.ConvertDecryptedDataToString(EncryptedDataBlock);
    }
}