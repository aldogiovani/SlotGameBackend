# Slot Game Backend
This personal project simulates the backend for a slot game. 

It was done as part of a study about the mechanics and statistics behind a slot machine and is a fully functional backend for a play for fun game.

The assumptions are the game is stateless and the player will always have credit for the spin. So this backend just receives the spin command, performs the random draw and returns the outcome of the spin as output:

The classes were organized in a way to better reflect the components of a slot machine:
- Cards
- Reels
- Lines
- Line streaks
- Line prizes
- Prizes

# Getting started
1. Clone the repo
2. Build and run
3. Do an API call to `game/sample-game/spin/10/10`

The response should look like this:
```
{
   "totalWinnings":10,
   "reels":[
      {
         "id":1,
         "positions":[
            {
               "id":0,
               "cardId":4
            },
            {
               "id":1,
               "cardId":0
            },
            {
               "id":2,
               "cardId":8
            }
         ]
      },
      {
         "id":2,
         "positions":[
            {
               "id":0,
               "cardId":5
            },
            {
               "id":1,
               "cardId":12
            },
            {
               "id":2,
               "cardId":4
            }
         ]
      },
      {
         "id":3,
         "positions":[
            {
               "id":0,
               "cardId":5
            },
            {
               "id":1,
               "cardId":7
            },
            {
               "id":2,
               "cardId":4
            }
         ]
      },
      {
         "id":4,
         "positions":[
            {
               "id":0,
               "cardId":9
            },
            {
               "id":1,
               "cardId":3
            },
            {
               "id":2,
               "cardId":11
            }
         ]
      },
      {
         "id":5,
         "positions":[
            {
               "id":0,
               "cardId":0
            },
            {
               "id":1,
               "cardId":11
            },
            {
               "id":2,
               "cardId":5
            }
         ]
      }
   ],
   "lineWinnings":[
      {
         "lineId":1,
         "cardId":12,
         "streak":2,
         "multiplier":10
      }
   ],
   "winningLines":[
      {
         "id":1,
         "outcome":[ 0, 12, 7, 3, 11 ],
         "yPositions":[ 1, 1, 1, 1, 1 ],
         "uiCoordinates":"0111213141"
      }
   ]
}
```
