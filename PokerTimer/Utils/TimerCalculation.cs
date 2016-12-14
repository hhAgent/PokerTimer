using PokerTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerTimer.Utils
{
    public class TimerCalculation
    {
        public static PokerJson Run(Tournament tour, List<BlindsLevel> levels)
        {
            var res = new PokerJson()
            {
                TournamentName = tour.Name,
                CurrentPlayers = tour.CurrentPlayers,
                TotalPlayers = tour.TotalPlayers,
                Rebuy = tour.Rebuy,
                Addon = tour.Addon,
                AvgStack = tour.AvgStack,
                PrizePool = tour.PrizePool,
                ServerTime = DateTime.Now,
            };

            DateTime updateTime = tour.UpdateTime;
            if (tour.IsStopped)
            {
                res.CurrentStage = tour.LastStage;
                res.CurrentLevel = levels[tour.LastStage].Level;
                res.CurrentCountDown = tour.LastStageTime;
                res.CurrentAnte = levels[tour.LastStage].Ante;
                res.CurrentSmallBlind = levels[tour.LastStage].SmallBlind;
                res.CurrentBigBlind = levels[tour.LastStage].BigBlind;

                res.NextSmallBlind = levels[tour.LastStage].SmallBlind;
                res.NextBigBlind = levels[tour.LastStage].BigBlind;

                for (int i = tour.LastStage; i < levels.Count; ++i)
                {
                    if (levels[i].Level > 0)
                    {
                        res.NextSmallBlind = levels[i].SmallBlind;
                        res.NextBigBlind = levels[i].BigBlind;
                        break;
                    }
                }
            }
            else if (updateTime < tour.StartingTime)
            {
                res.CurrentStage = 0;
                res.CurrentLevel = 0;
                res.CurrentCountDown = (int)(tour.StartingTime - updateTime).TotalSeconds;

                res.CurrentAnte = 0;
                res.CurrentSmallBlind = 0;
                res.CurrentBigBlind = 0;

                res.NextSmallBlind = 0;
                res.NextBigBlind = 0;

                for (int i = 0; i < levels.Count; ++i)
                {
                    if (levels[i].Level == 1)
                    {
                        res.NextSmallBlind = levels[i].SmallBlind;
                        res.NextBigBlind = levels[i].BigBlind;
                    }
                }
            }
            else 
            {                
                int timeDiff = (int)(DateTime.Now - tour.UpdateTime).TotalSeconds;
                levels[tour.LastStage].Length = tour.LastStageTime;

                for (int i = tour.LastStage; i < levels.Count; ++i)
                {
                    if (timeDiff <= levels[i].Length || i+1 == levels.Count )
                    {
                        res.CurrentStage = levels[i].Stage;
                        res.CurrentLevel = levels[i].Level;
                        res.CurrentCountDown = levels[i].Length - timeDiff;
                        if (res.CurrentCountDown < 0)
                            res.CurrentCountDown = 0;

                        res.CurrentAnte = levels[i].Ante;
                        res.CurrentSmallBlind = levels[i].SmallBlind;
                        res.CurrentBigBlind = levels[i].BigBlind;

                        res.NextSmallBlind = levels[i].SmallBlind;
                        res.NextBigBlind = levels[i].BigBlind;

                        for (int j = i + 1; j < levels.Count; ++j)
                        {
                            if (levels[j].Level > 0)
                            {
                                res.NextSmallBlind = levels[j].SmallBlind;
                                res.NextBigBlind = levels[j].BigBlind;
                                break;
                            }
                        }

                        timeDiff = 0;
                        break;
                    }
                    else
                    {
                        timeDiff -= levels[i].Length;
                    }
                }                
            }

            return res;
        }
    }
}