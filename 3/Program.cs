// skive ab Björn Blomberg
using System;


class Uppgift_tre
{
    static void Main()
    {
        Console.WriteLine("Uppgift 3");
        Console.WriteLine("Gör en osorterad lista med heltal från 1 till 25 blandat.");
        Console.WriteLine("Dessa heltal ska sen skrivas ut till konsolen sorterade efter bokstavsordning på den svenska benämningen av talen.");
        int[] numbers = new int[25];
        Console.WriteLine("skapar listan");
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }
        Console.WriteLine("Ineholet i listan just nu:");
        PrintArr(numbers);
        Console.WriteLine("");
        Console.WriteLine("Blandar listan");
        numbers = MixArr(numbers);
        Console.WriteLine("Ineholet i listan just nu:");
        PrintArr(numbers);
        Console.WriteLine("");
        Console.WriteLine("Skriver ut den i bokstavsordning på svenska:");
        PrintIntArrToWordsInOrder(numbers);
    }

    static void PrintArr(int[] arr)
    {
        for (int i = 0; i < 25; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }

    static int[] MixArr(int[] arr)
    {
        Random rand = new Random();
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        return arr;
    }

    static void PrintIntArrToWordsInOrder(int[] arr)
    {
        Dictionary<int, string> numberToWords = new Dictionary<int, string> {
            {1, "ett"}, {2, "två"}, {3, "tre"}, {4, "fyra"}, {5, "fem"},
            {6, "sex"}, {7, "sju"}, {8, "åtta"}, {9, "nio"}, {10, "tio"},
            {11, "elva"}, {12, "tolv"}, {13, "tretton"}, {14, "fjorton"}, {15, "femton"},
            {16, "sexton"}, {17, "sjutton"}, {18, "arton"}, {19, "nitton"}, {20, "tjugo"},
            {21, "tjugoett"}, {22, "tjugotvå"}, {23, "tjugotre"}, {24, "tjugofyra"}, {25, "tjugofem"}
        };
        List<string> words = arr.Select(number => numberToWords[number]).ToList();
        words.Sort((a, b) => {
            Func<char, bool> isSwedishChar = (c) => {
                return (c == 'å' || c == 'Å' || c == 'ä' || c == 'Ä' || c == 'ö' || c == 'Ö');
            };
            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                char charA = char.ToLower(a[i]);
                char charB = char.ToLower(b[i]);

                if (charA != charB)
                {
                    if (isSwedishChar(charA) && !isSwedishChar(charB))
                    {
                        return 1;
                    }
                    else if (!isSwedishChar(charA) && isSwedishChar(charB))
                    {
                        return -1;
                    }
                    else
                    {
                        return charA.CompareTo(charB);
                    }
                }
            }

            return a.Length.CompareTo(b.Length);
        });
        Console.WriteLine(string.Join(" ", words));
    }
}