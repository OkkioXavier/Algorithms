namespace Algorithms.Greedy;

public record Station<T>(HashSet<T> Regions);

public static class CoverageExtensions
{
    /// <summary>
    /// Tries to find a 'minimal' number of stations to cover a set of regions
    /// Uses a greedy algorithm to cover as many regions as possible by selected the stations with most coverage first
    /// Answer may be suboptimal
    /// </summary>
    /// <param name="stations">The available stations</param>
    /// <param name="regions">The regions to cover</param>
    public static (IEnumerable<Station<T>>, IEnumerable<T> CoveredStations) FindCoverage<T>(this IEnumerable<Station<T>> stations, params T[] regions) where T : IComparable
    {
        var queue = new PriorityQueue<Station<T>, int>(stations.Select(s => (s, s.Regions.Count)),
            Comparer<int>.Create((a, b) => -a.CompareTo(b)));
        var uncoveredRegions = new HashSet<T>(regions);
        var coveringStations = new List<Station<T>>();

        while (uncoveredRegions.Count > 0 && queue.TryDequeue(out var station, out _))
        {
            if (uncoveredRegions.Any(station.Regions.Contains))
            {
                coveringStations.Add(station);
                uncoveredRegions.ExceptWith(station.Regions);
            }
        }

        return (coveringStations, regions.Except(uncoveredRegions));
    }
    
    public static (IEnumerable<Station<T>>, IEnumerable<T> CoveredStations) FindCoverageMinimalStations<T>(this IEnumerable<Station<T>> stations, params T[] regions) where T : IComparable
    {
        var uncoveredRegions = new HashSet<T>(regions);
        var coveringStations = new List<Station<T>>();
        var availableStations = stations.ToHashSet();

        while (uncoveredRegions.Count > 0)
        {
            var station = GetStationWithMostCoverage(availableStations, uncoveredRegions);

            if (station is null)
            {
                break;
            }
           
            coveringStations.Add(station);
            availableStations.Remove(station);
            uncoveredRegions.ExceptWith(station.Regions);
        }

        return (coveringStations, regions.Except(uncoveredRegions));
        
        Station<T>? GetStationWithMostCoverage(HashSet<Station<T>> remainingStations, HashSet<T> remainingRegions)
        {
            int bestValue = 0;
            Station<T>? bestStation = null;
            var length = remainingStations.Count;

            foreach (var station in remainingStations)
            {
                if (station.Regions.Count < bestValue)
                {
                    continue;
                }
                
                var overlap = station.Regions.Count(remainingRegions.Contains);

                if (overlap > bestValue)
                {
                    bestValue = overlap;
                    bestStation = station;
                }

                if (bestValue == length)
                {
                    return bestStation;
                }
            }

            return bestStation;
        }
    }
}