# HackerRank

Listing personal HackerHank Solution
---
## Bot saves princess
https://www.hackerrank.com/challenges/saveprincess

Princess Peach is trapped in one of the four corners of a square grid. You are in the center of the grid and can move one step at a time in any of the four directions. Can you rescue the princess?

Input format

The first line contains an odd integer N (3 <= N < 100) denoting the size of the grid. This is followed by an NxN grid. Each cell is denoted by '-' (ascii value: 45). The bot position is denoted by 'm' and the princess position is denoted by 'p'.

Grid is indexed using Matrix Convention

Output format

Print out the moves you will take to rescue the princess in one go. The moves must be separated by '\n', a newline. The valid moves are LEFT or RIGHT or UP or DOWN.

Sample input
```
3
---
-m-
p--
```
Sample output
```
DOWN
LEFT
```
Task
Complete the function displayPathtoPrincess which takes in two parameters - the integer N and the character array grid. The grid will be formatted exactly as you see it in the input, so for the sample input the princess is at grid[2][0]. The function shall output moves (LEFT, RIGHT, UP or DOWN) on consecutive lines to rescue/reach the princess. The goal is to reach the princess in as few moves as possible.

The above sample input is just to help you understand the format. The princess ('p') can be in any one of the four corners.

``` C#
using System;

public class app
{
    private static void displayPathtoPrincess(int n, String[] grid)
    {
        var str = string.Join(string.Empty, grid);
        for (int x = str.IndexOf('m') / n; x < str.IndexOf('p') / n; x++) Console.WriteLine("DOWN");
        for (int x = str.IndexOf('m') / n; x > str.IndexOf('p') / n; x--) Console.WriteLine("UP");
        for (int x = str.IndexOf('m') % n; x < str.IndexOf('p') % n; x++) Console.WriteLine("RIGHT");
        for (int x = str.IndexOf('m') % n; x > str.IndexOf('p') % n; x--) Console.WriteLine("LEFT");
    }

    private static void Main(String[] args)
    {
        int m;

        m = int.Parse(Console.ReadLine());
        String[] grid = new String[m];
        for (int i = 0; i < m; i++)
        {
            grid[i] = Console.ReadLine();
        }

        displayPathtoPrincess(m, grid);
    }
}
```
