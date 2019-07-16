using System.Collections.Generic;
using System.Linq;

namespace Conways
{
    public class GameOfLife
    {
        private List<int[]> _aliveCells;

        public GameOfLife(List<int[]> seed)
        {
            _aliveCells = seed;
        }

        public IEnumerable<int[]> AliveCells => _aliveCells;

        public IEnumerable<int[]> Tick()
        {
            _aliveCells = Survivors()
                .Union(Births())
                .OrderBy(c => c[1])
                .ThenBy(c => c[0])
                .ToList();
            return _aliveCells;
        }

        private List<int[]> Survivors()
        {
            var survivors = new List<int[]>();
            foreach (var cell in _aliveCells)
            {
                if (LiveNeighbours(cell).Count() == 2 || LiveNeighbours(cell).Count() == 3)
                {
                    survivors.Add(cell);
                }
            }

            return survivors;
        }

        public IEnumerable<int[]> LiveNeighbours(int[] cell)
        {
            return Neighbours(cell)
                .Where(neighbour => _aliveCells.Any(c => c.SequenceEqual(neighbour)))
                .ToList();
        }

        public IEnumerable<int[]> DeadNeighbours(int[] cell)
        {
            return Neighbours(cell)
                .Where(neighbour => !_aliveCells.Any(c => c.SequenceEqual(neighbour)))
                .ToList();
        }

        public IEnumerable<int[]> Neighbours(int[] cell)
        {
            var deltas = new List<int[]>
            {
                new[] {-1, -1},
                new[] {0, -1},
                new[] {1, -1},
                new[] {-1, 0},
                new[] {1, 0},
                new[] {-1, 1},
                new[] {0, 1},
                new[] {1, 1}
            };

            var neighbours = new List<int[]>();
            foreach (var delta in deltas)
            {
                var x = cell[0] + delta[0];
                var y = cell[1] + delta[1];
                neighbours.Add(new[] { x, y });
            }

            return neighbours;
        }

        public IEnumerable<int[]> Births()
        {
            return BirthCandidates()
                .Where(candidate => LiveNeighbours(candidate).Count() == 3)
                .ToList();
        }

        public IEnumerable<int[]> BirthCandidates()
        {
            var deadWithOneLiveNeighbour = new List<List<int[]>>();
            foreach (var cell in _aliveCells)
            {
                deadWithOneLiveNeighbour.Add(new List<int[]>(DeadNeighbours(cell)));
            }

            return deadWithOneLiveNeighbour.SelectMany(list => list)
                .GroupBy(g => new { X = g[0], Y = g[1] })
                .Select(g => g.First())
                .ToList();
        }
    }
}