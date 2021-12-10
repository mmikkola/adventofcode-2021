using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day4 : ProblemBase
    {
        private struct Cell
        {
            public int Number;
            public bool Marked;
        }

        public override object Part1(string[] input)
        {
            var numbers = input[0].Split(',').Select(int.Parse);

            var boards = new List<Cell[][]>();

            for(int i = 1; i < input.Length; i += 5)
            {
                var board = new Cell[5][];
                i++; // Skip newline

                for (int j = 0; j < 5; j++)
                {
                    var raw = input[i + j].Split(' ').Where(s => !string.IsNullOrEmpty(s));
                    var row = raw.Select(n => new Cell() { Number = int.Parse(n), Marked = false }).ToArray();
                    board[j] = row;
                }

                boards.Add(board);
            }

            foreach(var number in numbers)
            {
                foreach(var board in boards)
                {
                    bool gotBingo = MarkNumberAndCheckForBingo(board, number);

                    if(gotBingo)
                    {
                        return CalculateScore(board, number);
                    }
                }
            }

            return -1;
        }

        private int CalculateScore(Cell[][] board, int number)
        {
            int sumOfUnmaked = board.Sum(r => r.Sum(c => c.Marked ? 0 : c.Number));

            return sumOfUnmaked * number;
        }

        private bool MarkNumberAndCheckForBingo(Cell[][] board, int number)
        {
            for(int r = 0; r < 5; r++)
            {
                for(int c = 0; c < 5; c++)
                {
                    if(board[r][c].Number == number)
                    {
                        board[r][c].Marked = true;

                        return CheckForBingo(board, r, c);
                    }
                }
            }

            return false;
        }

        private bool CheckForBingo(Cell[][] board, int row, int column)
        {
            return CheckRowForBingo(board, row) || CheckColumnForBingo(board, column);
        }

        private bool CheckRowForBingo(Cell[][] board, int row)
        {
            for(int c = 0; c < 5; c++)
            {
                if (!board[row][c].Marked)
                    return false;
            }

            return true;
        }

        private bool CheckColumnForBingo(Cell[][] board, int column)
        {
            for (int r = 0; r < 5; r++)
            {
                if (!board[r][column].Marked)
                    return false;
            }

            return true;
        }

        private class BingoBoard
        {
            public bool GotBingo;
            public Cell[][] Board;
        }
        public override object Part2(string[] input)
        {
            var numbers = input[0].Split(',').Select(int.Parse);

            var boards = new List<BingoBoard>();

            for (int i = 1; i < input.Length; i += 5)
            {
                var board = new Cell[5][];
                i++; // Skip newline

                for (int j = 0; j < 5; j++)
                {
                    var raw = input[i + j].Split(' ').Where(s => !string.IsNullOrEmpty(s));
                    var row = raw.Select(n => new Cell() { Number = int.Parse(n), Marked = false }).ToArray();
                    board[j] = row;
                }

                boards.Add(new BingoBoard() { Board = board });
            }

            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    if (board.GotBingo)
                        continue;

                    bool gotBingo = MarkNumberAndCheckForBingo(board.Board, number);
                    board.GotBingo = gotBingo;

                    if(gotBingo && boards.Count(b => !b.GotBingo) == 0)
                    {
                        return CalculateScore(board.Board, number);
                    }
                }
            }

            return -1;
        }
    }
}
