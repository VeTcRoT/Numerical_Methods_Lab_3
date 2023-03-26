using Lab_3;

double[,] systemMatrix =
{
    {4, 1, -2},
    {-1, 3 ,5},
    {3, -1, 5}
};

double[] freeMembersColumn = { 10, -1, 1 };

var cramer = new CramerMethod(systemMatrix, freeMembersColumn);
var gauss = new GaussMethod(systemMatrix, freeMembersColumn);
var matrix = new MatrixMethod(systemMatrix, freeMembersColumn);

Console.WriteLine(new string('-', 30) + "Task 1" + new string('-', 30) + "\n");

double[] cramerResult = cramer.GetResult();

Console.WriteLine("Cramer's method: ");
Console.WriteLine("Result: X = {0}, Y = {1}, Z = {2}\n", cramerResult[0], cramerResult[1], cramerResult[2]);

double[] gaussResult = gauss.GetResult();

Console.WriteLine("Gauss's method: ");
Console.WriteLine("Result: X = {0}, Y = {1}, Z = {2}\n", gaussResult[0], gaussResult[1], gaussResult[2]);

Console.WriteLine(new string('-', 30) + "Task 2" + new string('-', 30) + "\n");

double[] matrixResult = matrix.GetResult();

Console.WriteLine("Matrix method: ");
Console.WriteLine("Result: X = {0}, Y = {1}, Z = {2}\n", matrixResult[0], matrixResult[1], matrixResult[2]);