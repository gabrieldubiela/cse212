using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        // Convert the array to a set for O(1) lookups
        var wordSet = new HashSet<string>(words);

        // Create a new set to hold the results
        var results = new HashSet<string>();

        // loop the words
        foreach (var word in words)
        {
            // Invert the word
            var inverted = $"{word[1]}{word[0]}";

            // Compare the word with the inverted word to see if they are different
            if (word != inverted)
            {
                // See if the inverted word is in words
                if (wordSet.Contains(inverted))
                {
                    // Add both the word and the inverted to the new set
                    var pair = $"{word} & {inverted}";
                    var reversePair = $"{inverted} & {word}";
                    if (!results.Contains(pair) && !results.Contains(reversePair))
                        results.Add(pair);
                }
            }
        }
        // return the new set
        // expected output: new[] { "ma & am", "fi & if" }
        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            // Find and save the degree that is in the 4th column (index 3)
            var degree = fields[3];

            // If the degree is already in the dictionary, increment the count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                // Otherwise, add the degree to the dictionary with a count of 1
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // See if the lengths of the words are different
        if (word1.Length != word2.Length)
        {
            return false;
        }

        // create a dictionary to hold the letters of word1
        var letters = new Dictionary<char, int>();

        // use a loop to get the letters in word1
        foreach (var letter in word1)
        {
            // See if the letter is already in the dictionary
            if (letters.ContainsKey(letter))
            {
                // If it is, increment the count
                letters[letter]++;
            }
            else
            {
                // If it isn't, add the letter to the dictionary with a count of 1
                letters[letter] = 1;
            }
        }

        // use a loop to get the letters in word2
        foreach (var letter in word2)
        {
            // See if the letter is in the dictionary
            if (letters.ContainsKey(letter))
            {
                // See if the letter have value bigger than 0, 
                if (letters[letter] > 0)
                    // Decrement the count
                    letters[letter]--;
                else
                    return false;
            }
            else
            {
                // If it isn't, return false
                return false;
            }
        }

        // If pass everything is an anagram and return true
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Create a list to hold the results
        var results = new List<string>();

        // Use a loop in the features
        foreach (var feature in featureCollection.features)
        {
            // Get the properties of feature
            var properties = feature.properties;

            // Create a string with place and mag
            var description = $"{properties.place} - Mag {properties.mag}";

            // Add the string to the list
            results.Add(description);
        }

        // Return the list as an array
        return results.ToArray();
    }
}