using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>();
        var results = new List<string>();
        foreach (var word in words)
        {
            var reversed = $"{word[1]}{word[0]}";
            if (set.Contains(reversed))
            {
                results.Add($"{reversed} & {word}");
            }
            else if (word[0] != word[1])
            {
                set.Add(word);
            }
        }
        return results.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 4)
            {
                var degree = fields[3].Trim();
                if (degrees.ContainsKey(degree)) degrees[degree]++;
                else degrees[degree] = 1;
            }
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        var counts = new Dictionary<char, int>();
        foreach (char c in word1.ToLower().Replace(" ", ""))
            counts[c] = counts.GetValueOrDefault(c) + 1;
        foreach (char c in word2.ToLower().Replace(" ", ""))
        {
            if (!counts.ContainsKey(c)) return false;
            counts[c]--;
        }
        return counts.Values.All(v => v == 0);
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var fc = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        return fc.Features.Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}").ToArray();
    }
}