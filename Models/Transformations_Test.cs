namespace PKG_V1;

using NUnit.Framework;

public class Transformations_Test {
    //Test examples taken from https://page.math.tu-berlin.de/~kant/teaching/hess/krypto-ws2006/des.htm
    Transformations trans = new Transformations();
    [Test] //Checking if PC1 transformation function works ona specified data
    public void PC1Test() {
        bool[] arrayBefore = {
            false, false, false, true, false, false, true, true,
            false, false, true, true, false, true, false, false,
            false, true, false, true, false, true, true, true,
            false, true, true, true, true, false, false, true,
            true, false, false, true, true, false, true, true,
            true, false, true, true, true, true, false, false,
            true, true, false, true, true, true, true, true,
            true, true, true, true, false, false, false, true
        };
        bool[] arrayAfter = {
            true, true, true, true, false, false, false,
            false, true, true, false, false, true, true,
            false, false, true, false, true, false, true,
            false, true, false, true, true, true, true,
            false, true, false, true, false, true, false,
            true, false, true, true, false, false, true,
            true, false, false, true, true, true, true,
            false, false, false, true, true, true, true
        };

        bool[] arrayTrans = trans.PC1Transformation(arrayBefore);
        for (int i = 0; i < 56; i++) {
            Assert.True(arrayAfter[i] == arrayTrans[i]);
        }
    }
    
    [Test] //Checking if PC2 transformation function works ona specified data
    public void PC2Test() {
        bool[,] arrayBefore = { {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true, false, true, false, true,
                false, true, false, true, false, true, true, false, false, true, true, false, false, true, true, true,
                true, false, false, false, true, true, true, true
            }, {
                true, true, true, false, false, false, false, true, true, false, false, true, true, false, false, true,
                false, true, false, true, false, true, false, true, true, true, true, true, true, false, true, false,
                true, false, true, false, true, true, false, false, true, true, false, false, true, true, true, true,
                false, false, false, true, true, true, true, false
            }, {
                true, true, false, false, false, false, true, true, false, false, true, true, false, false, true, false,
                true, false, true, false, true, false, true, true, true, true, true, true, false, true, false, true,
                false, true, false, true, true, false, false, true, true, false, false, true, true, true, true, false,
                false, false, true, true, true, true, false, true
            }, {
                false, false, false, false, true, true, false, false, true, true, false, false, true, false, true,
                false, true, false, true, false, true, true, true, true, true, true, true, true, false, true, false,
                true, false, true, true, false, false, true, true, false, false, true, true, true, true, false, false,
                false, true, true, true, true, false, true, false, true
            }, {
                false, false, true, true, false, false, true, true, false, false, true, false, true, false, true, false,
                true, false, true, true, true, true, true, true, true, true, false, false, false, true, false, true,
                true, false, false, true, true, false, false, true, true, true, true, false, false, false, true, true,
                true, true, false, true, false, true, false, true
            }, {
                true, true, false, false, true, true, false, false, true, false, true, false, true, false, true, false,
                true, true, true, true, true, true, true, true, false, false, false, false, false, true, true, false,
                false, true, true, false, false, true, true, true, true, false, false, false, true, true, true, true,
                false, true, false, true, false, true, false, true
            }, {
                false, false, true, true, false, false, true, false, true, false, true, false, true, false, true, true,
                true, true, true, true, true, true, false, false, false, false, true, true, true, false, false, true,
                true, false, false, true, true, true, true, false, false, false, true, true, true, true, false, true,
                false, true, false, true, false, true, false, true
            }, {
                true, true, false, false, true, false, true, false, true, false, true, false, true, true, true, true,
                true, true, true, true, false, false, false, false, true, true, false, false, false, true, true, false,
                false, true, true, true, true, false, false, false, true, true, true, true, false, true, false, true,
                false, true, false, true, false, true, true, false
            }, {
                false, false, true, false, true, false, true, false, true, false, true, true, true, true, true, true,
                true, true, false, false, false, false, true, true, false, false, true, true, true, false, false, true,
                true, true, true, false, false, false, true, true, true, true, false, true, false, true, false, true,
                false, true, false, true, true, false, false, true
            }, {
                false, true, false, true, false, true, false, true, false, true, true, true, true, true, true, true,
                true, false, false, false, false, true, true, false, false, true, true, false, false, false, true, true,
                true, true, false, false, false, true, true, true, true, false, true, false, true, false, true, false,
                true, false, true, true, false, false, true, true
            }, {
                false, true, false, true, false, true, false, true, true, true, true, true, true, true, true, false,
                false, false, false, true, true, false, false, true, true, false, false, true, true, true, true, true,
                false, false, false, true, true, true, true, false, true, false, true, false, true, false, true, false,
                true, true, false, false, true, true, false, false
            }, {
                false, true, false, true, false, true, true, true, true, true, true, true, true, false, false, false,
                false, true, true, false, false, true, true, false, false, true, false, true, true, true, false, false,
                false, true, true, true, true, false, true, false, true, false, true, false, true, false, true, true,
                false, false, true, true, false, false, true, true
            }, {
                false, true, false, true, true, true, true, true, true, true, true, false, false, false, false, true,
                true, false, false, true, true, false, false, true, false, true, false, true, false, false, false, true,
                true, true, true, false, true, false, true, false, true, false, true, false, true, true, false, false,
                true, true, false, false, true, true, true, true
            }, {
                false, true, true, true, true, true, true, true, true, false, false, false, false, true, true, false,
                false, true, true, false, false, true, false, true, false, true, false, true, false, true, true, true,
                true, false, true, false, true, false, true, false, true, false, true, true, false, false, true, true,
                false, false, true, true, true, true, false, false
            }, {
                true, true, true, true, true, true, true, false, false, false, false, true, true, false, false, true,
                true, false, false, true, false, true, false, true, false, true, false, true, true, true, true, false,
                true, false, true, false, true, false, true, false, true, true, false, false, true, true, false, false,
                true, true, true, true, false, false, false, true
            }, {
                true, true, true, true, true, false, false, false, false, true, true, false, false, true, true, false,
                false, true, false, true, false, true, false, true, false, true, true, true, true, false, true, false,
                true, false, true, false, true, false, true, true, false, false, true, true, false, false, true, true,
                true, true, false, false, false, true, true, true
            }, {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true, false, true, false, true,
                false, true, false, true, false, true, true, false, false, true, true, false, false, true, true, true,
                true, false, false, false, true, true, true, true
            } };
        bool[,] arrayAfter = { {
                false, false, false, true, true, false, true, true, false, false, false, false, false, false, true,
                false, true, true, true, false, true, true, true, true, true, true, true, true, true, true, false,
                false, false, true, true, true, false, false, false, false, false, true, true, true, false, false, true,
                false
            }, {
                false, true, true, true, true, false, false, true, true, false, true, false, true, true, true, false,
                true, true, false, true, true, false, false, true, true, true, false, true, true, false, true, true,
                true, true, false, false, true, false, false, true, true, true, true, false, false, true, false, true
            }, {
                false, true, false, true, false, true, false, true, true, true, true, true, true, true, false, false,
                true, false, false, false, true, false, true, false, false, true, false, false, false, false, true,
                false, true, true, false, false, true, true, true, true, true, false, false, true, true, false, false,
                true
            }, {
                false, true, true, true, false, false, true, false, true, false, true, false, true, true, false, true,
                true, true, false, true, false, true, true, false, true, true, false, true, true, false, true, true,
                false, false, true, true, false, true, false, true, false, false, false, true, true, true, false, true
            }, {
                false, true, true, true, true, true, false, false, true, true, true, false, true, true, false, false,
                false, false, false, false, false, true, true, true, true, true, true, false, true, false, true, true,
                false, true, false, true, false, false, true, true, true, false, true, false, true, false, false, false
            }, {
                false, true, true, false, false, false, true, true, true, false, true, false, false, true, false, true,
                false, false, true, true, true, true, true, false, false, true, false, true, false, false, false, false,
                false, true, true, true, true, false, true, true, false, false, true, false, true, true, true, true
            }, {
                true, true, true, false, true, true, false, false, true, false, false, false, false, true, false, false,
                true, false, true, true, false, true, true, true, true, true, true, true, false, true, true, false,
                false, false, false, true, true, false, false, false, true, false, true, true, true, true, false, false
            }, {
                true, true, true, true, false, true, true, true, true, false, false, false, true, false, true, false,
                false, false, true, true, true, false, true, false, true, true, false, false, false, false, false, true,
                false, false, true, true, true, false, true, true, true, true, true, true, true, false, true, true
            }, {
                true, true, true, false, false, false, false, false, true, true, false, true, true, false, true, true,
                true, true, true, false, true, false, true, true, true, true, true, false, true, true, false, true,
                true, true, true, false, false, true, true, true, true, false, false, false, false, false, false, true
            }, {
                true, false, true, true, false, false, false, true, true, true, true, true, false, false, true, true,
                false, true, false, false, false, true, true, true, true, false, true, true, true, false, true, false,
                false, true, false, false, false, true, true, false, false, true, false, false, true, true, true, true
            }, {
                false, false, true, false, false, false, false, true, false, true, false, true, true, true, true, true,
                true, true, false, true, false, false, true, true, true, true, false, true, true, true, true, false,
                true, true, false, true, false, false, true, true, true, false, false, false, false, true, true, false
            }, {
                false, true, true, true, false, true, false, true, false, true, true, true, false, false, false, true,
                true, true, true, true, false, true, false, true, true, false, false, true, false, true, false, false,
                false, true, true, false, false, true, true, true, true, true, true, false, true, false, false, true
            }, {
                true, false, false, true, false, true, true, true, true, true, false, false, false, true, false, true,
                true, true, false, true, false, false, false, true, true, true, true, true, true, false, true, false,
                true, false, true, true, true, false, true, false, false, true, false, false, false, false, false, true
            }, {
                false, true, false, true, true, true, true, true, false, true, false, false, false, false, true, true,
                true, false, true, true, false, true, true, true, true, true, true, true, false, false, true, false,
                true, true, true, false, false, true, true, true, false, false, true, true, true, false, true, false
            }, {
                true, false, true, true, true, true, true, true, true, false, false, true, false, false, false, true,
                true, false, false, false, true, true, false, true, false, false, true, true, true, true, false, true,
                false, false, true, true, true, true, true, true, false, false, false, false, true, false, true, false
            }, {
                true, true, false, false, true, false, true, true, false, false, true, true, true, true, false, true,
                true, false, false, false, true, false, true, true, false, false, false, false, true, true, true, false,
                false, false, false, true, false, true, true, true, true, true, true, true, false, true, false, true
            } };

        bool[,] arrayTrans = trans.PC2Transformation(arrayBefore);
        for (int i = 1; i < 17; i++) {
            for (int j = 0; j < 48; j++) {
                Assert.True(arrayAfter[i-1, j] == arrayTrans[i, j]);
            }
        }
    }

    [Test] //Test IP transformation
    public void IPTest() {
        bool[] arrayBefore = {
            false, false, false, false, false, false, false, true, false, false, true, false, false, false, true, true,
            false, true, false, false, false, true, false, true, false, true, true, false, false, true, true, true,
            true, false, false, false, true, false, false, true, true, false, true, false, true, false, true, true,
            true, true, false, false, true, true, false, true, true, true, true, false, true, true, true, true
        };

        bool[] arrayAfter = {
            true, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false,
            true, true, false, false, true, true, false, false, true, true, true, true, true, true, true, true, true,
            true, true, true, false, false, false, false, true, false, true, false, true, false, true, false, true,
            true, true, true, false, false, false, false, true, false, true, false, true, false, true, false
        };
        
        bool[] arrayTrans = trans.IPTransform(arrayBefore);
        for (int i = 0; i < 64; i++) {
            Assert.True(arrayAfter[i] == arrayTrans[i]);
        }
    }

    [Test]
    public void ETest() {
        bool[] arrayBefore = {
            true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false,
            true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false
        };

        bool[] arrayAfter = {
            false, true, true, true, true, false, true, false, false, false, false, true, false, true, false, true,
            false, true, false, true, false, true, false, true, false, true, true, true, true, false, true, false,
            false, false, false, true, false, true, false, true, false, true, false, true, false, true, false, true
        };
        bool[] arrayTrans = trans.ETransformation(arrayBefore);
        for (int i = 0; i < 48; i++) {
            Assert.True(arrayAfter[i] == arrayTrans[i]);
        }
    }

    [Test]
    public void PTest() {
        bool[] arrayBefore = {
            false, true, false, true, true, true, false, false, true, false, false, false, false, false, true, false,
            true, false, true, true, false, true, false, true, true, false, false, true, false, true, true, true 
        };

        bool[] arrayAfter = {
            false, false, true, false, false, false, true, true, false, true, false, false, true, false, true, false,
            true, false, true, false, true, false, false, true, true, false, true, true, true, false, true, true,
        };
        bool[] arrayTrans = trans.PTransformation(arrayBefore);
        for (int i = 0; i < 32; i++) {
            Assert.True(arrayAfter[i] == arrayTrans[i]);
        }
    }
    
    [Test] //Test IP transformation
    public void IPReverseTest() {
        bool[] arrayBefore = {
            false, false, false, false, true, false, true, false, false, true, false, false, true, true, false, false,
            true, true, false, true, true, false, false, true, true, false, false, true, false, true, false, true,
            false, true, false, false, false, false, true, true, false, true, false, false, false, false, true, false,
            false, false, true, true, false, false, true, false, false, false, true, true, false, true, false, false
        };

        bool[] arrayAfter = {
            true, false, false, false, false, true, false, true, true, true, true, false, true, false, false, false,
            false, false, false, true, false, false, true, true, false, true, false, true, false, true, false, false,
            false, false, false, false, true, true, true, true, false, false, false, false, true, false, true, false,
            true, false, true, true, false, true, false, false, false, false, false, false, false, true, false, true,
        };
        
        bool[] arrayTrans = trans.IPReverseTransformation(arrayBefore);
        for (int i = 0; i < 64; i++) {
            Assert.True(arrayAfter[i] == arrayTrans[i]);
        }
    }
    
    [Test]
    public void XORTest() {
        bool[] temp1 = new bool[1];
        bool[] temp2 = new bool[1];
        bool[] tempArray;
        //1
        temp1[0] = true;
        temp2[0] = true;
        tempArray = trans.XOR(temp1, temp2, 1);
        Assert.False(tempArray[0]);
        //2
        temp1[0] = true;
        temp2[0] = false;
        tempArray = trans.XOR(temp1, temp2, 1);
        Assert.True(tempArray[0]);
        //3
        temp1[0] = false;
        temp2[0] = true;
        tempArray = trans.XOR(temp1, temp2, 1);
        Assert.True(tempArray[0]);
        //4
        temp1[0] = false;
        temp2[0] = false;
        tempArray = trans.XOR(temp1, temp2, 1);
        Assert.False(tempArray[0]);

        bool[] data = {
            false, false, false, false, false, false, false, false, false, true, true, false, false, false, false, true,
            false, false, false, false, false, false, false, false, false, true, true, false, false, false, true, false,
            false, false, false, false, false, false, false, false, false, true, true, false, false, false, true, true,
            false, false, false, false, false, false, false, false, false, true, true, false, false, true, false, false
        };
        bool[] key = {
            false, false, false, false, false, false, false, false, false, false, true, true, false, false, false, true,
            false, false, false, false, false, false, false, false, false, false, true, true, false, false, true, false,
            false, false, false, false, false, false, false, false, false, false, true, true, false, false, true, true,
            false, false, false, false, false, false, false, false, false, false, true, true, false, true, false, false
        };

        bool[] result = {
            false, false, false, false, false, false, false, false, false, true, false, true, false, false, false,
            false, false, false, false, false, false, false, false, false, false, true, false, true, false, false,
            false, false, false, false, false, false, false, false, false, false, false, true, false, true, false,
            false, false, false, false, false, false, false, false, false, false, false, false, true, false, true,
            false, false, false, false
        };

        bool[] temp = trans.XOR(data, key, 64);
        for (int i = 0; i < 64; i++)
        {
            Assert.True(temp[i]==result[i]);
        }
    }
}