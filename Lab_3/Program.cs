using Lab_3;

int[,] systemMatrix =
{
    {4, 1, -2},
    {-1, 3 ,5},
    {3, -1, 5}
};

int[] freeMembersColumn = { 10, -1, 1 };

var cramer = new CramerMethod(systemMatrix, freeMembersColumn);

foreach (double item in cramer.GetResult())
{
    Console.WriteLine(item);
}