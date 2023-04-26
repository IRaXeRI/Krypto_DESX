namespace PKG_V1;

using NUnit.Framework;

public class Generator_Test
{
    Generator gen = new Generator();
    [Test]
    public void CreateKeysCDSetsTest()
    {
        bool[] arrayBefore = {
            true, true, true, true, false, false, false,
            false, true, true, false, false, true, true,
            false, false, true, false, true, false, true,
            false, true, false, true, true, true, true,
            false, true, false, true, false, true, false,
            true, false, true, true, false, false, true,
            true, false, false, true, true, true, true,
            false, false, false, true, true, true, true
        };

        bool[,] arrayAfterLeft = { {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true
            }, {
                true, true, true, false, false, false, false, true, true, false, false, true, true, false, false, true,
                false, true, false, true, false, true, false, true, true, true, true, true
            }, {
                true, true, false, false, false, false, true, true, false, false, true, true, false, false, true, false,
                true, false, true, false, true, false, true, true, true, true, true, true
            }, {
                false, false, false, false, true, true, false, false, true, true, false, false, true, false, true,
                false, true, false, true, false, true, true, true, true, true, true, true, true
            }, {
                false, false, true, true, false, false, true, true, false, false, true, false, true, false, true, false,
                true, false, true, true, true, true, true, true, true, true, false, false
            }, {
                true, true, false, false, true, true, false, false, true, false, true, false, true, false, true, false,
                true, true, true, true, true, true, true, true, false, false, false, false
            }, {
                false, false, true, true, false, false, true, false, true, false, true, false, true, false, true, true,
                true, true, true, true, true, true, false, false, false, false, true, true
            }, {
                true, true, false, false, true, false, true, false, true, false, true, false, true, true, true, true,
                true, true, true, true, false, false, false, false, true, true, false, false
            }, {
                false, false, true, false, true, false, true, false, true, false, true, true, true, true, true, true,
                true, true, false, false, false, false, true, true, false, false, true, true
            }, {
                false, true, false, true, false, true, false, true, false, true, true, true, true, true, true, true,
                true, false, false, false, false, true, true, false, false, true, true, false
            }, {
                false, true, false, true, false, true, false, true, true, true, true, true, true, true, true, false,
                false, false, false, true, true, false, false, true, true, false, false, true
            }, {
                false, true, false, true, false, true, true, true, true, true, true, true, true, false, false, false,
                false, true, true, false, false, true, true, false, false, true, false, true
            }, {
                false, true, false, true, true, true, true, true, true, true, true, false, false, false, false, true,
                true, false, false, true, true, false, false, true, false, true, false, true
            }, {
                false, true, true, true, true, true, true, true, true, false, false, false, false, true, true, false,
                false, true, true, false, false, true, false, true, false, true, false, true
            }, {
                true, true, true, true, true, true, true, false, false, false, false, true, true, false, false, true,
                true, false, false, true, false, true, false, true, false, true, false, true
            }, {
                true, true, true, true, true, false, false, false, false, true, true, false, false, true, true, false,
                false, true, false, true, false, true, false, true, false, true, true, true
            }, {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true
            } };

        bool[,] arrayAfterRight = { {
                false, true, false, true, false, true, false, true, false, true, true, false, false, true, true, false,
                false, true, true, true, true, false, false, false, true, true, true, true
            }, {
                true, false, true, false, true, false, true, false, true, true, false, false, true, true, false, false,
                true, true, true, true, false, false, false, true, true, true, true, false,
            }, {
                false, true, false, true, false, true, false, true, true, false, false, true, true, false, false, true,
                true, true, true, false, false, false, true, true, true, true, false, true,
            }, {
                false, true, false, true, false, true, true, false, false, true, true, false, false, true, true, true,
                true, false, false, false, true, true, true, true, false, true, false, true,
            }, {
                false, true, false, true, true, false, false, true, true, false, false, true, true, true, true, false,
                false, false, true, true, true, true, false, true, false, true, false, true,
            }, {
                false, true, true, false, false, true, true, false, false, true, true, true, true, false, false, false,
                true, true, true, true, false, true, false, true, false, true, false, true,
            }, {
                true, false, false, true, true, false, false, true, true, true, true, false, false, false, true, true,
                true, true, false, true, false, true, false, true, false, true, false, true,
            }, {
                false, true, true, false, false, true, true, true, true, false, false, false, true, true, true, true,
                false, true, false, true, false, true, false, true, false, true, true, false,
            }, {
                true, false, false, true, true, true, true, false, false, false, true, true, true, true, false, true,
                false, true, false, true, false, true, false, true, true, false, false, true,
            }, {
                false, false, true, true, true, true, false, false, false, true, true, true, true, false, true, false,
                true, false, true, false, true, false, true, true, false, false, true, true,
            }, {
                true, true, true, true, false, false, false, true, true, true, true, false, true, false, true, false,
                true, false, true, false, true, true, false, false, true, true, false, false,
            }, {
                true, true, false, false, false, true, true, true, true, false, true, false, true, false, true, false,
                true, false, true, true, false, false, true, true, false, false, true, true,
            }, {
                false, false, false, true, true, true, true, false, true, false, true, false, true, false, true, false,
                true, true, false, false, true, true, false, false, true, true, true, true,
            }, {
                false, true, true, true, true, false, true, false, true, false, true, false, true, false, true, true,
                false, false, true, true, false, false, true, true, true, true, false, false,
            }, {
                true, true, true, false, true, false, true, false, true, false, true, false, true, true, false, false,
                true, true, false, false, true, true, true, true, false, false, false, true,
            }, {
                true, false, true, false, true, false, true, false, true, false, true, true, false, false, true, true,
                false, false, true, true, true, true, false, false, false, true, true, true,
            }, {
                false, true, false, true, false, true, false, true, false, true, true, false, false, true, true, false,
                false, true, true, true, true, false, false, false, true, true, true, true
            } };
        var temp = gen.CreateKeySetsCD(arrayBefore);
        bool[,] arrayGenLeft = temp.Item1;
        bool[,] arrayGenRight = temp.Item2;
        for (int i = 0; i < 17; i++) {
            for (int j = 0; j < 28; j++) {
                Assert.True(arrayAfterLeft[i, j] == arrayGenLeft[i, j]);
                Assert.True(arrayAfterRight[i, j] == arrayGenRight[i, j]);
            }
        }
    }

    [Test]
    public void CreateKSetsTest() {
        bool[,] arrayBeforeLeft = { {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true
            }, {
                true, true, true, false, false, false, false, true, true, false, false, true, true, false, false, true,
                false, true, false, true, false, true, false, true, true, true, true, true
            }, {
                true, true, false, false, false, false, true, true, false, false, true, true, false, false, true, false,
                true, false, true, false, true, false, true, true, true, true, true, true
            }, {
                false, false, false, false, true, true, false, false, true, true, false, false, true, false, true,
                false, true, false, true, false, true, true, true, true, true, true, true, true
            }, {
                false, false, true, true, false, false, true, true, false, false, true, false, true, false, true, false,
                true, false, true, true, true, true, true, true, true, true, false, false
            }, {
                true, true, false, false, true, true, false, false, true, false, true, false, true, false, true, false,
                true, true, true, true, true, true, true, true, false, false, false, false
            }, {
                false, false, true, true, false, false, true, false, true, false, true, false, true, false, true, true,
                true, true, true, true, true, true, false, false, false, false, true, true
            }, {
                true, true, false, false, true, false, true, false, true, false, true, false, true, true, true, true,
                true, true, true, true, false, false, false, false, true, true, false, false
            }, {
                false, false, true, false, true, false, true, false, true, false, true, true, true, true, true, true,
                true, true, false, false, false, false, true, true, false, false, true, true
            }, {
                false, true, false, true, false, true, false, true, false, true, true, true, true, true, true, true,
                true, false, false, false, false, true, true, false, false, true, true, false
            }, {
                false, true, false, true, false, true, false, true, true, true, true, true, true, true, true, false,
                false, false, false, true, true, false, false, true, true, false, false, true
            }, {
                false, true, false, true, false, true, true, true, true, true, true, true, true, false, false, false,
                false, true, true, false, false, true, true, false, false, true, false, true
            }, {
                false, true, false, true, true, true, true, true, true, true, true, false, false, false, false, true,
                true, false, false, true, true, false, false, true, false, true, false, true
            }, {
                false, true, true, true, true, true, true, true, true, false, false, false, false, true, true, false,
                false, true, true, false, false, true, false, true, false, true, false, true
            }, {
                true, true, true, true, true, true, true, false, false, false, false, true, true, false, false, true,
                true, false, false, true, false, true, false, true, false, true, false, true
            }, {
                true, true, true, true, true, false, false, false, false, true, true, false, false, true, true, false,
                false, true, false, true, false, true, false, true, false, true, true, true
            }, {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true
            } };

        bool[,] arrayBeforeRight = { {
                false, true, false, true, false, true, false, true, false, true, true, false, false, true, true, false,
                false, true, true, true, true, false, false, false, true, true, true, true
            }, {
                true, false, true, false, true, false, true, false, true, true, false, false, true, true, false, false,
                true, true, true, true, false, false, false, true, true, true, true, false,
            }, {
                false, true, false, true, false, true, false, true, true, false, false, true, true, false, false, true,
                true, true, true, false, false, false, true, true, true, true, false, true,
            }, {
                false, true, false, true, false, true, true, false, false, true, true, false, false, true, true, true,
                true, false, false, false, true, true, true, true, false, true, false, true,
            }, {
                false, true, false, true, true, false, false, true, true, false, false, true, true, true, true, false,
                false, false, true, true, true, true, false, true, false, true, false, true,
            }, {
                false, true, true, false, false, true, true, false, false, true, true, true, true, false, false, false,
                true, true, true, true, false, true, false, true, false, true, false, true,
            }, {
                true, false, false, true, true, false, false, true, true, true, true, false, false, false, true, true,
                true, true, false, true, false, true, false, true, false, true, false, true,
            }, {
                false, true, true, false, false, true, true, true, true, false, false, false, true, true, true, true,
                false, true, false, true, false, true, false, true, false, true, true, false,
            }, {
                true, false, false, true, true, true, true, false, false, false, true, true, true, true, false, true,
                false, true, false, true, false, true, false, true, true, false, false, true,
            }, {
                false, false, true, true, true, true, false, false, false, true, true, true, true, false, true, false,
                true, false, true, false, true, false, true, true, false, false, true, true,
            }, {
                true, true, true, true, false, false, false, true, true, true, true, false, true, false, true, false,
                true, false, true, false, true, true, false, false, true, true, false, false,
            }, {
                true, true, false, false, false, true, true, true, true, false, true, false, true, false, true, false,
                true, false, true, true, false, false, true, true, false, false, true, true,
            }, {
                false, false, false, true, true, true, true, false, true, false, true, false, true, false, true, false,
                true, true, false, false, true, true, false, false, true, true, true, true,
            }, {
                false, true, true, true, true, false, true, false, true, false, true, false, true, false, true, true,
                false, false, true, true, false, false, true, true, true, true, false, false,
            }, {
                true, true, true, false, true, false, true, false, true, false, true, false, true, true, false, false,
                true, true, false, false, true, true, true, true, false, false, false, true,
            }, {
                true, false, true, false, true, false, true, false, true, false, true, true, false, false, true, true,
                false, false, true, true, true, true, false, false, false, true, true, true,
            }, {
                false, true, false, true, false, true, false, true, false, true, true, false, false, true, true, false,
                false, true, true, true, true, false, false, false, true, true, true, true
            } };

        bool[,] arrayAfter = { {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true, false, true, false, true,
                false, true, false, true, false, true, true, false, false, true, true, false, false, true, true, true,
                true, false, false, false, true, true, true, true,
            }, {
                true, true, true, false, false, false, false, true, true, false, false, true, true, false, false, true,
                false, true, false, true, false, true, false, true, true, true, true, true, true, false, true, false,
                true, false, true, false, true, true, false, false, true, true, false, false, true, true, true, true,
                false, false, false, true, true, true, true, false,
            }, {
                true, true, false, false, false, false, true, true, false, false, true, true, false, false, true, false,
                true, false, true, false, true, false, true, true, true, true, true, true, false, true, false, true,
                false, true, false, true, true, false, false, true, true, false, false, true, true, true, true, false,
                false, false, true, true, true, true, false, true,
            }, {
                false, false, false, false, true, true, false, false, true, true, false, false, true, false, true,
                false, true, false, true, false, true, true, true, true, true, true, true, true, false, true, false,
                true, false, true, true, false, false, true, true, false, false, true, true, true, true, false, false,
                false, true, true, true, true, false, true, false, true,
            }, {
                false, false, true, true, false, false, true, true, false, false, true, false, true, false, true, false,
                true, false, true, true, true, true, true, true, true, true, false, false, false, true, false, true,
                true, false, false, true, true, false, false, true, true, true, true, false, false, false, true, true,
                true, true, false, true, false, true, false, true,
            }, {
                true, true, false, false, true, true, false, false, true, false, true, false, true, false, true, false,
                true, true, true, true, true, true, true, true, false, false, false, false, false, true, true, false,
                false, true, true, false, false, true, true, true, true, false, false, false, true, true, true, true,
                false, true, false, true, false, true, false, true,
            }, {
                false, false, true, true, false, false, true, false, true, false, true, false, true, false, true, true,
                true, true, true, true, true, true, false, false, false, false, true, true, true, false, false, true,
                true, false, false, true, true, true, true, false, false, false, true, true, true, true, false, true,
                false, true, false, true, false, true, false, true,
            }, {
                true, true, false, false, true, false, true, false, true, false, true, false, true, true, true, true,
                true, true, true, true, false, false, false, false, true, true, false, false, false, true, true, false,
                false, true, true, true, true, false, false, false, true, true, true, true, false, true, false, true,
                false, true, false, true, false, true, true, false,
            }, {
                false, false, true, false, true, false, true, false, true, false, true, true, true, true, true, true,
                true, true, false, false, false, false, true, true, false, false, true, true, true, false, false, true,
                true, true, true, false, false, false, true, true, true, true, false, true, false, true, false, true,
                false, true, false, true, true, false, false, true,
            }, {
                false, true, false, true, false, true, false, true, false, true, true, true, true, true, true, true,
                true, false, false, false, false, true, true, false, false, true, true, false, false, false, true, true,
                true, true, false, false, false, true, true, true, true, false, true, false, true, false, true, false,
                true, false, true, true, false, false, true, true,
            }, {
                false, true, false, true, false, true, false, true, true, true, true, true, true, true, true, false,
                false, false, false, true, true, false, false, true, true, false, false, true, true, true, true, true,
                false, false, false, true, true, true, true, false, true, false, true, false, true, false, true, false,
                true, true, false, false, true, true, false, false,
            }, {
                false, true, false, true, false, true, true, true, true, true, true, true, true, false, false, false,
                false, true, true, false, false, true, true, false, false, true, false, true, true, true, false, false,
                false, true, true, true, true, false, true, false, true, false, true, false, true, false, true, true,
                false, false, true, true, false, false, true, true,
            }, {
                false, true, false, true, true, true, true, true, true, true, true, false, false, false, false, true,
                true, false, false, true, true, false, false, true, false, true, false, true, false, false, false, true,
                true, true, true, false, true, false, true, false, true, false, true, false, true, true, false, false,
                true, true, false, false, true, true, true, true,
            }, {
                false, true, true, true, true, true, true, true, true, false, false, false, false, true, true, false,
                false, true, true, false, false, true, false, true, false, true, false, true, false, true, true, true,
                true, false, true, false, true, false, true, false, true, false, true, true, false, false, true, true,
                false, false, true, true, true, true, false, false,
            }, {
                true, true, true, true, true, true, true, false, false, false, false, true, true, false, false, true,
                true, false, false, true, false, true, false, true, false, true, false, true, true, true, true, false,
                true, false, true, false, true, false, true, false, true, true, false, false, true, true, false, false,
                true, true, true, true, false, false, false, true,
            }, {
                true, true, true, true, true, false, false, false, false, true, true, false, false, true, true, false,
                false, true, false, true, false, true, false, true, false, true, true, true, true, false, true, false,
                true, false, true, false, true, false, true, true, false, false, true, true, false, false, true, true,
                true, true, false, false, false, true, true, true,
            }, {
                true, true, true, true, false, false, false, false, true, true, false, false, true, true, false, false,
                true, false, true, false, true, false, true, false, true, true, true, true, false, true, false, true,
                false, true, false, true, false, true, true, false, false, true, true, false, false, true, true, true,
                true, false, false, false, true, true, true, true,
            } };
        bool[,] arrayGen = gen.CreateKeySetK(arrayBeforeLeft, arrayBeforeRight);
        for (int i = 1; i < 17; i++) {
            for (int j = 0; j < 56; j++) {
                Assert.True(arrayAfter[i, j] == arrayGen[i, j]);
            }
        }
    }
    
    [Test]
    public void GenerateSetsLNTest()
    {
        bool[,] keys = new bool[17, 48];
        bool[] key1 = {
            false, false, false, true, true, false, true, true, false, false, false, false, false, false, true, false,
            true, true, true, false, true, true, true, true, true, true, true, true, true, true, false, false, false,
            true, true, true, false, false, false, false, false, true, true, true, false, false, true, false
        };
        for (int i = 0; i < 48; i++) {
            keys[1, i] = key1[i];
        }

        bool[] arrayBeforeLeftHalf = {
            true, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false,
            true, true, false, false, true, true, false, false, true, true, true, true, true, true, true, true
        };
        bool[] arrayBeforeRightHalf = {
            true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false,
            true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false
        };

        bool[] arrayAfterLeftHalf = {
            true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false,
            true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false
        };

        bool[] arrayAfterRightHalf = {
            true, true, true, false, true, true, true, true, false, true, false, false, true, false, true, false, false,
            true, true, false, false, true, false, true, false, true, false, false, false, true, false, false
        };

        var Halves = gen.GenerateSetsLN(arrayBeforeLeftHalf, arrayBeforeRightHalf, keys);
        for (int i = 0; i < 32; i++)
        {
            Assert.True(arrayAfterLeftHalf[i]==Halves.Item1[1,i]);
            Assert.True(arrayAfterRightHalf[i]==Halves.Item2[1,i]);
        }
    }

    [Test]
    public void GetKeyTest()
    {
        bool[,] keys = { {
                false, false, false, true, true, false, true, true, false, false, false, false, false, false, true,
                false, true, true, true, false, true, true, true, true, true, true, true, true, true, true, false,
                false, false, true, true, true, false, false, false, false, false, true, true, true, false, false, true,
                false
            } };

        bool[] recievedKey = gen.GetK_i(keys, 0);
        for (int i = 0; i < 48; i++)
        {
            Assert.True(recievedKey[i]==keys[0,i]);
        }
    }

    [Test]
    public void GetOneHalfTest()
    {
        bool[,] arrayBeforeLeft = { {
                true, true, false, false, true, true, false, false, false, false, false, false, false, false, false,
                false, true, true, false, false, true, true, false, false, true, true, true, true, true, true, true, true
        } };
        bool[,] arrayBeforeRight = { {
                true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false,
                true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false
        } };

        bool[] tempLeft = gen.GetOneHalf(arrayBeforeLeft, arrayBeforeRight, 0, true);
        bool[] tempRight = gen.GetOneHalf(arrayBeforeLeft, arrayBeforeRight, 0, false);

        for (int i = 0; i < 32; i++) {
            Assert.True(tempLeft[i]==arrayBeforeLeft[0,i]);
            Assert.True(tempRight[i]==arrayBeforeRight[0,i]);
        }
    }

    [Test]
    public void SboxesTest()
    {
        bool[,] sets = {
            { false, true, true, false, false, false },
            { false, true, false, false, false, true },
            { false, true, true, true, true, false },
            { true, true, true, false, true, false },
            { true, false, false, false, false, true },
            { true, false, false, true, true, false },
            { false, true, false, true, false, false },
            { true, false, false, true, true, true } };

        bool[] arrayAfterSBoxes = {
            false, true, false, true, true, true, false, false, true, false, false, false, false, false, true, false,
            true, false, true, true, false, true, false, true, true, false, false, true, false, true, true, true
        };

        bool[] temp = gen.Sboxes(sets);
        for (int i = 0; i < 32; i++)
        {
            Assert.True(arrayAfterSBoxes[i] == temp[i]);
        }
    }


}