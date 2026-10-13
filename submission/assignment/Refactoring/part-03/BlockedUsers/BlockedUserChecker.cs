using System.Diagnostics;
using System.Timers;

namespace RefactoringLab.Part03.BlockedUsers;

public static class BlockedUserChecker
{
    //Time complexity after Add HashSet O(N + M)  before O(N * M) 
    public static int CountBlocked(List<int> blockedIds, int[] requestIds)
    {
        var hashBlockedIds = new HashSet<int>(blockedIds);  // O(N) because we will itreate on blocked list to make hashset

        var blocked = 0; // O(1)

        foreach (var id in requestIds)  // O(M)   (M * 1 * 1) = (M)
        {
            if (hashBlockedIds.Contains(id)) // O(1)
                blocked++; // O(1)
        }

        return blocked;
    }

    public static List<int> BuildBlockedIds(int count)
    {
        var list = new List<int>(count);
        for (var i = 0; i < count; i++)
            list.Add(i);
        return list;
    }

    public static int[] BuildRequestIds(int count, int maxId, int seed = 42)
    {
        var rnd = new Random(seed);
        var ids = new int[count];
        for (var i = 0; i < count; i++)
            ids[i] = rnd.Next(maxId);
        return ids;
    }

    public static long MeasureMs(List<int> blockedIds, int[] requestIds, out int found)
    {
        var sw = Stopwatch.StartNew();
        found = CountBlocked(blockedIds, requestIds);
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
