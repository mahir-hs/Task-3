using ConsoleTables;

namespace Task_3
{
    public class HelpTable
    {
        private readonly string[] _moves;

        public HelpTable(string[] moves)
        {
            _moves = moves;
        }

        public void PrintTable()
        {
            var table = new ConsoleTable(new[] { "v PC\\User >" }.Concat(_moves).ToArray());

            for (int i = 0; i < _moves.Length; i++)
            {
                var row = new List<string> { _moves[i] };
                for (int j = 0; j < _moves.Length; j++)
                {
                    var result = GetResult(i, j);
                    row.Add(result);
                }
                table.AddRow(row.ToArray());
            }

            table.Write();
        }

        private string GetResult(int playerMoveIndex, int computerMoveIndex)
        {
            int half = _moves.Length / 2;
            int distance = (computerMoveIndex - playerMoveIndex + _moves.Length) % _moves.Length;

            return distance <= half ? "Win" : distance == half + 1 ? "Draw" : "Lose";
        }
    }
}
