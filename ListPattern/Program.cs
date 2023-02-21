
// list pattern, available from C#11 .NET 7

// list / array  

Console.WriteLine(GetNumber(new List<int>() { 1, 2, 3, 4, 5 }));     // 1
Console.WriteLine(GetNumber(new List<int>() { 1, 2, 6 }));           // 2
Console.WriteLine(GetNumber(new List<int>() { 2, 2, 4, 1 }));        // 3
Console.WriteLine(GetNumber(new List<int>() { 1, 2, 5, 11, 9 }));    // 4
Console.WriteLine(GetNumber(new List<int>() { 3, 2, 5, 13 }));       // 5
Console.WriteLine(GetNumber(new List<int>() { 4, 2, 5, 15, 7, 2 })); // 6
Console.WriteLine(GetNumber(new List<int>() { 5, 7, 4, 12 }));       // 7
Console.WriteLine(GetNumber(new List<int>() { 5 }));                 // 8

int GetNumber(List<int> values) => values switch
{
    [1, 2, 3, 4, 5] => 1,
    [1, _, 6] => 2,
    [2, _, _, _] => 3,
    [.., 9] => 4,
    [3, ..] => 5,
    [4, .., 2] => 6,
    [_, .., _] => 7,
    [..] => 8
};

Console.WriteLine("_________________");

// if

int[] numbers = { 1, 2, 3, 4, 5 };
if (numbers is [1, 2, 3, 4, 5])
{
    Console.WriteLine("[1, 2, 3, 4, 5]"); // 1, 2, 3, 4, 5
}

if (numbers is [var first, var second, .., var last])
{
    Console.WriteLine($"first: {first}, second: {second},  last: {last}");
} // first: 1, second: 2, last: 5

Console.WriteLine(GetSlice(new[] { 2, 3, 4, 5 }));      // Middle: 3, 4
Console.WriteLine(GetSlice(new[] { 2, 4, 6, 8 }));      // End: 4, 6, 8
Console.WriteLine(GetSlice(new[] { 1, 2, 3, 5 }));      // Start: 1, 2, 3
Console.WriteLine(GetSlice(new[] { 1, 2, 3, 4 }));      // All: 1, 2, 3, 4
Console.WriteLine(GetSlice(new int[] { }));             // All: 

string GetSlice(int[] values) => values switch
{
    [2, .. var middle, 5] => $"Middle: {string.Join(", ", middle)}",
    [2, .. var end] => $"End: {string.Join(", ", end)}",
    [.. var start, 5] => $"Start: {string.Join(", ", start)}",
    [.. var all] => $"All: {string.Join(", ", all)}"
};



Console.ReadKey();

