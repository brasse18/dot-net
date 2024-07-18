public class Uppgift_treTests
{
    [Fact]
    public void GenerateIntArr_ShouldReturnListOfNumbers()
    {
        var expected = Enumerable.Range(1, 25).ToArray();
        var result = Uppgift_tre.GenerateIntArr(25);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MixArr_ShouldReturnArrayWithSameElementsInDifferentOrder()
    {
        var original = Enumerable.Range(1, 25).ToArray();
        var arrayToMix = (int[])original.Clone();
        var result = Uppgift_tre.MixArr(arrayToMix);

        Assert.Equal(original.OrderBy(x => x), result.OrderBy(x => x));
        Assert.NotEqual(original, result);
    }

    [Fact]
    public void IntArrToWordsInOrder_ShouldReturnWordsInAlphabeticalOrder()
    {
        var numbers = new int[] { 1, 2, 3, 4, 5 };
        var expected = new List<string> { "ett", "fem", "fyra", "tre", "två" };
        var result = Uppgift_tre.IntArrToWordsInOrder(numbers);

        Assert.Equal(expected, result);
    }
}