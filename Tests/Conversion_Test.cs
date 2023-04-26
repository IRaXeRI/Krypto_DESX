namespace PKG_V1;

using NUnit.Framework;

public class Conversion_Test
{
    private Conversion conv = new Conversion();
    [Test]
    public void SplitIntoHalvesTest()
    {
        bool[] arrayBefore = {
            true, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false,
            true, true, false, false, true, true, false, false, true, true, true, true, true, true, true, true, true,
            true, true, true, false, false, false, false, true, false, true, false, true, false, true, false, true,
            true, true, true, false, false, false, false, true, false, true, false, true, false, true, false
        };

        bool[] arrayAfterLeft = {
            true, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false,
            true, true, false, false, true, true, false, false, true, true, true, true, true, true, true, true
        };

        bool[] arrayAfterRight = { 
            true, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false, true,
            true, true, true, false, false, false, false, true, false, true, false, true, false, true, false
        };

        var arraySplit = conv.SplitIPIntoHalves(arrayBefore);
        for (int i = 0; i < 32; i++)
        {
            Assert.True(arraySplit.Item1[i] == arrayAfterLeft[i]);
            Assert.True(arraySplit.Item2[i] == arrayAfterRight[i]);
        }
    }
}