# LevenshteinDistanceCSharp
Simple levenshtein distance in CSharp.
Bruteforce, not recommended for scalable applications.

In information theory, linguistics and computer science, the Levenshtein distance is a string metric for measuring the difference between two sequences. Informally, the Levenshtein distance between two words is the minimum number of single-character edits required to change one word into the other.

This is useful to detect simple typos and features like "did you mean ____?"

A useful escenario is where you have s short list of items that may be hard to type like: names, medications, cities etc. Enabling the user to have better confidence in what they typed in to the application. Autocompletes cant fill this need because autocomplete requires a partially correct word written. 
