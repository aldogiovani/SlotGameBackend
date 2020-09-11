using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlotSimulator
{
    public class SampleGame
    {
        private const int Card_End_1 = 25;
        private const int Card_End_2 = 65;
        private const int Card_End_3 = 105;
        private const int Card_End_4 = 205;
        private const int Card_End_5 = 305;
        private const int Card_End_6 = 395;
        private const int Card_End_7 = 485;
        private const int Card_End_8 = 565;
        private const int Card_End_9 = 645;
        private const int Card_End_10 = 715;
        private const int Card_End_11 = 785;
        private const int Card_End_12 = 845;
        private const int Card_End_13 = 900;
        private List<Prize> Prizes { get; set; }
        private int[,] Reels { get; set; }
        private List<GameReel> GameReels { get; set; }
        private List<Line> Lines { get; set; }
        private List<Line> StakedLines { get; set; }
        private List<LineStreak> LineStreaks { get; set; }
        private List<LinePrize> LinePrizes { get; set; }

        public SpinOutcome Spin(int stake, int betLines)
        {
            //Set prizes
            this.Prizes = new List<Prize> {
                new Prize { CardId = 0, Streak = 5, Multiplier = 5000 },
                new Prize { CardId = 1, Streak = 3, Multiplier = 3 },
                new Prize { CardId = 1, Streak = 4, Multiplier = 10 },
                new Prize { CardId = 1, Streak = 5, Multiplier = 100 },
                new Prize { CardId = 2, Streak = 3, Multiplier = 5 },
                new Prize { CardId = 2, Streak = 4, Multiplier = 20 },
                new Prize { CardId = 2, Streak = 5, Multiplier = 100 },
                new Prize { CardId = 3, Streak = 3, Multiplier = 5 },
                new Prize { CardId = 3, Streak = 4, Multiplier = 20 },
                new Prize { CardId = 3, Streak = 5, Multiplier = 100 },
                new Prize { CardId = 4, Streak = 3, Multiplier = 7 },
                new Prize { CardId = 4, Streak = 4, Multiplier = 25 },
                new Prize { CardId = 4, Streak = 5, Multiplier = 150 },
                new Prize { CardId = 5, Streak = 3, Multiplier = 7 },
                new Prize { CardId = 5, Streak = 4, Multiplier = 25 },
                new Prize { CardId = 5, Streak = 5, Multiplier = 150 },
                new Prize { CardId = 6, Streak = 3, Multiplier = 10 },
                new Prize { CardId = 6, Streak = 4, Multiplier = 30 },
                new Prize { CardId = 6, Streak = 5, Multiplier = 200 },
                new Prize { CardId = 7, Streak = 3, Multiplier = 10 },
                new Prize { CardId = 7, Streak = 4, Multiplier = 30 },
                new Prize { CardId = 7, Streak = 5, Multiplier = 200 },
                new Prize { CardId = 8, Streak = 3, Multiplier = 15 },
                new Prize { CardId = 8, Streak = 4, Multiplier = 75 },
                new Prize { CardId = 8, Streak = 5, Multiplier = 500 },
                new Prize { CardId = 9, Streak = 3, Multiplier = 15 },
                new Prize { CardId = 9, Streak = 4, Multiplier = 75 },
                new Prize { CardId = 9, Streak = 5, Multiplier = 500 },
                new Prize { CardId = 10, Streak = 3, Multiplier = 15 },
                new Prize { CardId = 10, Streak = 4, Multiplier = 75 },
                new Prize { CardId = 10, Streak = 5, Multiplier = 1000 },
                new Prize { CardId = 11, Streak = 2, Multiplier = 5 },
                new Prize { CardId = 11, Streak = 3, Multiplier = 100 },
                new Prize { CardId = 11, Streak = 4, Multiplier = 250 },
                new Prize { CardId = 11, Streak = 5, Multiplier = 2500 },
                new Prize { CardId = 12, Streak = 2, Multiplier = 10 },
                new Prize { CardId = 12, Streak = 3, Multiplier = 150 },
                new Prize { CardId = 12, Streak = 4, Multiplier = 500 },
                new Prize { CardId = 12, Streak = 5, Multiplier = 5000 }
                };

            //Draws
            Random rng = new Random();
            this.Reels = new int[3, 5];
            Reels[0, 0] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[0, 1] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[0, 2] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[0, 3] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[0, 4] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[1, 0] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[1, 1] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[1, 2] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[1, 3] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[1, 4] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[2, 0] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[2, 1] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[2, 2] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[2, 3] = CheckNumberDrawn(rng.Next(1, Card_End_13));
            Reels[2, 4] = CheckNumberDrawn(rng.Next(1, Card_End_13));

            //Map the draws to game reels, just for output simplicity and readability
            this.GameReels = new List<GameReel>();
            this.GameReels.Add(new GameReel
            {
                Id = 1,
                Positions = new List<GameReelPosition>
                {
                    new GameReelPosition{ Id = 0, CardId = Reels[2,0] },
                    new GameReelPosition{ Id = 1, CardId = Reels[1,0] },
                    new GameReelPosition{ Id = 2, CardId = Reels[0,0] },
                }
            });
            this.GameReels.Add(new GameReel
            {
                Id = 2,
                Positions = new List<GameReelPosition>
                {
                    new GameReelPosition{ Id = 0, CardId = Reels[2,1] },
                    new GameReelPosition{ Id = 1, CardId = Reels[1,1] },
                    new GameReelPosition{ Id = 2, CardId = Reels[0,1] },
                }
            });
            this.GameReels.Add(new GameReel
            {
                Id = 3,
                Positions = new List<GameReelPosition>
                {
                    new GameReelPosition{ Id = 0, CardId = Reels[2,2] },
                    new GameReelPosition{ Id = 1, CardId = Reels[1,2] },
                    new GameReelPosition{ Id = 2, CardId = Reels[0,2] },
                }
            });
            this.GameReels.Add(new GameReel
            {
                Id = 4,
                Positions = new List<GameReelPosition>
                {
                    new GameReelPosition{ Id = 0, CardId = Reels[2,3] },
                    new GameReelPosition{ Id = 1, CardId = Reels[1,3] },
                    new GameReelPosition{ Id = 2, CardId = Reels[0,3] },
                }
            });
            this.GameReels.Add(new GameReel
            {
                Id = 5,
                Positions = new List<GameReelPosition>
                {
                    new GameReelPosition{ Id = 0, CardId = Reels[2,4] },
                    new GameReelPosition{ Id = 1, CardId = Reels[1,4] },
                    new GameReelPosition{ Id = 2, CardId = Reels[0,4] },
                }
            });

            //Form the lines
            int[] line1 = { Reels[1, 0], Reels[1, 1], Reels[1, 2], Reels[1, 3], Reels[1, 4] };
            int[] line2 = { Reels[0, 0], Reels[0, 1], Reels[0, 2], Reels[0, 3], Reels[0, 4] };
            int[] line3 = { Reels[2, 0], Reels[2, 1], Reels[2, 2], Reels[2, 3], Reels[2, 4] };
            int[] line4 = { Reels[0, 0], Reels[1, 1], Reels[2, 2], Reels[1, 3], Reels[0, 4] };
            int[] line5 = { Reels[2, 0], Reels[1, 1], Reels[0, 2], Reels[1, 3], Reels[2, 4] };
            int[] line6 = { Reels[1, 0], Reels[0, 1], Reels[1, 2], Reels[0, 3], Reels[1, 4] };
            int[] line7 = { Reels[1, 0], Reels[2, 1], Reels[1, 2], Reels[2, 3], Reels[1, 4] };
            int[] line8 = { Reels[0, 0], Reels[0, 1], Reels[1, 2], Reels[2, 3], Reels[2, 4] };
            int[] line9 = { Reels[2, 0], Reels[2, 1], Reels[1, 2], Reels[0, 3], Reels[0, 4] };
            int[] line10 = { Reels[1, 0], Reels[2, 1], Reels[1, 2], Reels[0, 3], Reels[1, 4] };
            int[] line11 = { Reels[1, 0], Reels[0, 1], Reels[1, 2], Reels[2, 3], Reels[1, 4] };
            int[] line12 = { Reels[0, 0], Reels[1, 1], Reels[1, 2], Reels[1, 3], Reels[0, 4] };
            int[] line13 = { Reels[2, 0], Reels[1, 1], Reels[1, 2], Reels[1, 3], Reels[2, 4] };
            int[] line14 = { Reels[0, 0], Reels[1, 1], Reels[0, 2], Reels[1, 3], Reels[0, 4] };
            int[] line15 = { Reels[2, 0], Reels[1, 1], Reels[2, 2], Reels[1, 3], Reels[2, 4] };
            int[] line16 = { Reels[1, 0], Reels[1, 1], Reels[0, 2], Reels[1, 3], Reels[1, 4] };
            int[] line17 = { Reels[1, 0], Reels[1, 1], Reels[2, 2], Reels[1, 3], Reels[1, 4] };
            int[] line18 = { Reels[0, 0], Reels[0, 1], Reels[2, 2], Reels[0, 3], Reels[0, 4] };
            int[] line19 = { Reels[2, 0], Reels[2, 1], Reels[0, 2], Reels[2, 3], Reels[2, 4] };
            int[] line20 = { Reels[1, 0], Reels[2, 1], Reels[2, 2], Reels[2, 3], Reels[1, 4] };

            this.Lines = new List<Line>
            {
                new Line { Id = 1, Outcome = line1, YPositions = new int[]{1,1,1,1,1 }, UICoordinates = "0111213141" },
                new Line { Id = 2, Outcome = line2, YPositions = new int[]{0,0,0,0,0 }, UICoordinates = "0010203040" },
                new Line { Id = 3, Outcome = line3, YPositions = new int[]{2,2,2,2,2 }, UICoordinates = "0212223242" },
                new Line { Id = 4, Outcome = line4, YPositions = new int[]{0,1,2,1,0 }, UICoordinates = "0011223140" },
                new Line { Id = 5, Outcome = line5, YPositions = new int[]{2,1,0,1,2 }, UICoordinates = "0211203142" },
                new Line { Id = 6, Outcome = line6, YPositions = new int[]{1,0,1,0,1 }, UICoordinates = "0110213041" },
                new Line { Id = 7, Outcome = line7, YPositions = new int[]{1,2,1,2,1 }, UICoordinates = "0112213241" },
                new Line { Id = 8, Outcome = line8, YPositions = new int[]{0,0,1,2,2 }, UICoordinates = "0010213242" },
                new Line { Id = 9, Outcome = line9, YPositions = new int[]{2,2,1,0,0 }, UICoordinates = "0212213040" },
                new Line { Id = 10, Outcome = line10, YPositions = new int[]{1,2,1,0,1 }, UICoordinates = "0112213041" },
                new Line { Id = 11, Outcome = line11, YPositions = new int[]{1,0,1,2,1 }, UICoordinates = "0110213241" },
                new Line { Id = 12, Outcome = line12, YPositions = new int[]{0,1,1,1,0 }, UICoordinates = "0011213140" },
                new Line { Id = 13, Outcome = line13, YPositions = new int[]{2,1,1,1,2 }, UICoordinates = "0211213142" },
                new Line { Id = 14, Outcome = line14, YPositions = new int[]{0,1,0,1,0 }, UICoordinates = "0011203140" },
                new Line { Id = 15, Outcome = line15, YPositions = new int[]{2,1,2,1,2 }, UICoordinates = "0211223142" },
                new Line { Id = 16, Outcome = line16, YPositions = new int[]{1,1,0,1,1 }, UICoordinates = "0111203141" },
                new Line { Id = 17, Outcome = line17, YPositions = new int[]{1,1,2,1,1 }, UICoordinates = "0111223141" },
                new Line { Id = 18, Outcome = line18, YPositions = new int[]{0,0,2,0,0 }, UICoordinates = "0010223040" },
                new Line { Id = 19, Outcome = line19, YPositions = new int[]{2,2,0,2,2 }, UICoordinates = "0212203242" },
                new Line { Id = 20, Outcome = line20, YPositions = new int[]{1,2,2,2,1 }, UICoordinates = "0112223241" }
            };

            //Populate the winning streaks list according to current winnings
            this.LineStreaks = new List<LineStreak>();
            this.StakedLines = Lines.Where(x => x.Id <= betLines).ToList();
            foreach (var l in StakedLines)
            {
                var s = checkWinnings(l);
                if (s.Streak > 0)
                {
                    LineStreaks.Add(s);
                }
            }

            //Calculate the prizes for the lines
            this.LinePrizes = new List<LinePrize>();
            foreach (var s in LineStreaks)
            {
                var winning = Prizes.Where(x => x.CardId == s.CardId && x.Streak == s.Streak).ToList();
                if (winning.Count() > 0)
                {
                    var w = winning.First();
                    this.LinePrizes.Add(new LinePrize { CardId = s.CardId, LineId = s.LineId, Streak = s.Streak, Multiplier = w.Multiplier });
                }
            }

            //Calculate total winnings
            int totalWinnings = 0;
            int linebet = stake / betLines;
            foreach (var p in this.LinePrizes)
            {
                totalWinnings += linebet * p.Multiplier;
            }

            var winningsLines = this.Lines.Where(x => this.LinePrizes.Select(y => y.LineId).Contains(x.Id)).ToList();

            //Create and return the outcome of the spin
            return new SpinOutcome
            {
                LineWinnings = this.LinePrizes,
                Reels = this.GameReels,
                TotalWinnings = totalWinnings,
                WinningLines = winningsLines
            };
        }

        private int CheckNumberDrawn(int numberDrawn)
        {
            if (numberDrawn > 0 & numberDrawn <= Card_End_1)
                return (0);
            if (numberDrawn > Card_End_1 & numberDrawn <= Card_End_2)
                return (1);
            if (numberDrawn > Card_End_2 & numberDrawn <= Card_End_3)
                return (2);
            if (numberDrawn > Card_End_3 & numberDrawn <= Card_End_4)
                return (3);
            if (numberDrawn > Card_End_4 & numberDrawn <= Card_End_5)
                return (4);
            if (numberDrawn > Card_End_5 & numberDrawn <= Card_End_6)
                return (5);
            if (numberDrawn > Card_End_6 & numberDrawn <= Card_End_7)
                return (6);
            if (numberDrawn > Card_End_7 & numberDrawn <= Card_End_8)
                return (7);
            if (numberDrawn > Card_End_8 & numberDrawn <= Card_End_9)
                return (8);
            if (numberDrawn > Card_End_9 & numberDrawn <= Card_End_10)
                return (9);
            if (numberDrawn > Card_End_10 & numberDrawn <= Card_End_11)
                return (10);
            if (numberDrawn > Card_End_11 & numberDrawn <= Card_End_12)
                return (11);
            if (numberDrawn > Card_End_12 & numberDrawn <= Card_End_13)
                return (12);

            return 999;
        }

        private LineStreak checkWinnings(Line line)
        {
            //Check line to define the card id that will be used to determine the winnings
            int value = 0;
            for (int i = line.Outcome.Length - 1; i >= 0; i--)
            {
                if (line.Outcome[i] != 0)
                    value = line.Outcome[i];
            }

            //Determine the streak of the card
            int win = 0;
            if ((line.Outcome[0] == 0 | line.Outcome[0] == value) & (line.Outcome[1] == 0 | line.Outcome[1] == value))
            {
                win = 2;
                if (line.Outcome[2] == 0 | line.Outcome[2] == value)
                {
                    win = 3;
                    if ((line.Outcome[3] == 0 | line.Outcome[3] == value))
                    {
                        win = 4;
                        if ((line.Outcome[4] == 0 | line.Outcome[4] == value))
                        {
                            win = 5;
                        }
                    }
                }
            }

            return new LineStreak { LineId = line.Id, CardId = value, Streak = win };
        }
    }
}
