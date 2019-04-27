## Assumptions

1. Only two players (i.e. singles match)
2. Does not need to take into account who 'serves' first (i.e. breaking serves etc)
3. Random player wins a rally, which therefore randomly wins a game, set, match

## Hardware and dev environment

1. Intel Core i7-8850H CPU
2. 16 GB DDR4 RAM
3. 1 TB SSD
4. Visual Studio 2019
5. .NET Framework 4.7.2
6. Unit tests written using MSTest (.NET 4.7.2)

## General comments and limitations

* The main limitation is that it only simulates a singles match. It would need to be refactored so that Player 1 and Player 2 are 'teams' which should be relatively simple to do.
* Each match is developed againt `ISet` and `IMatchParameters` interfaces which make it far easier to mock in the tests.
* It became a bit slow when simulating up to 100 000+ tennis matches which, I acknowledge, could be improved given more time.
* Player 'ID's' are also hard coded in places, which could be abstracted out into a proper data structure/storage feature - even its own class.
* Total time: I did it in roughly 45 minute bursts.. I'd say total time to complete was roughly 3h30mins.. where most of the time was spent on the tests.