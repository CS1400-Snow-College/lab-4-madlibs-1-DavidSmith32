Console.Clear();

// Step 2
Console.WriteLine(@"
Welcome to 'Mad Libs'
I will ask for different types of words with which I will build a funny story with.");

// Step 3
string originalStory = @"A vacation is when you take a trip to some (adjective) 
place with your (adjective) family. Usually, you go to some place that is near 
a/an (noun) or up on a/an (noun). A good vacation place is one where you can ride 
(plural-noun) or play (game) or go hunting for (plural-noun). I like to spend my time 
(verb-ending-in-“ing”) or (verb-ending-in-“ing”). When parents go on a vacation, 
they spend their time eating three (plural-noun) a day, and fathers play golf, and 
mothers sit around (verb-ending-in-“ing”) Last summer, my little brother fell in a/an 
(noun) and got poison (plant) all over his (part-of-the-body) My family is going to 
go to (place) and I will practice (verb-ending-in-“ing”) Parents need vacations more 
than kids because parents are always very (adjective) and because they have to work 
(number) hours every day all year making enough (plural-noun) to pay for the vacation.";

string[] storyWords = originalStory.Split(' ');

// Step 4
string newStory = "";
for (int i = 0; i < storyWords.Length; i++)
{
    // Searching for replacable words
    string currentWord = storyWords[i];
    if (currentWord.Contains("(")) 
    {
         // Removing '(' ')' and '-' from words
        char[] temp = new char[currentWord.Length]; // Needed a new array to index my currentWord
        for (int j = 0; j < currentWord.Length; j++)
        {   
            if (currentWord[j] == '(' || currentWord[j] == ')' || currentWord[j] == '-')
            {
                temp[j] = ' ';
            }
            else
            {
                temp[j] = currentWord[j];
            }
        }

        // Stitches temp back to currentWord without punctuation
        currentWord = "";
        for (int k = 0; k < temp.Length; k++)
        {
            currentWord += temp[k];
        }

        // Prompts the user for a given word and filters depending on if it ends with a period
        if (currentWord.Contains('.'))
        {
            Console.Write($"Give me a/an {currentWord[1..(currentWord.Length - 2)]}: ");
            currentWord = Console.ReadLine();
            newStory += currentWord + ". ";
        }
        else
        {
            Console.Write($"Give me a/an {currentWord[1..(currentWord.Length - 1)]}: ");
            currentWord = Console.ReadLine();
            newStory += currentWord + " ";
        }
    }
    // Adds non-replaceable words to the newStory
    else
    {
        newStory += currentWord + " ";
    }
}

// Step 5
Console.WriteLine(newStory);