using BahnAppMockup.API.Functions;
using BahnAppMockup.API.Interfaces;
using BahnAppMockup.API.Services;
using BahnAppMockup.Models.JsonModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BahnAppMockup.Logic
{
    internal class TrainScheduler
    {
        static int[] departureTimes = new int[] { 6, 26, 46 };
        static int[][] baseSchedule = new int[][] { new int[]{ 6, 9, 12, 15, 18, 21, 24 }, new int[] { 26, 29, 32, 35, 38, 41, 44 }, new int[] { 46, 49, 52, 55, 58, 1, 4 } };


        //Ill keep it simple here for now, this will have to be redone in the future to add more features

        public static async Task<Dictionary<string, DateTime>> GetTrainSchedule(DateTime requestTime)
        { 
            List<Station> correctTrainStations = await GetCorrectTrainStations(requestTime).ConfigureAwait(false);

            Dictionary<string, DateTime> stationArrivalTimePair = new Dictionary<string, DateTime>();

            foreach(Station station in correctTrainStations)
            {
                stationArrivalTimePair.Add(station.stationName, DateTime.Parse(station.aimedArrivalTime));
            }

            Debug.WriteLine("Köln Hbf: "+ stationArrivalTimePair["Köln Hbf"].ToString());

            return stationArrivalTimePair;
        }
        public static async Task<Dictionary<string, DateTime>> GetDelays(DateTime requestTime)
        {
            List<Station> correctTrainStations = await GetCorrectTrainStations(requestTime).ConfigureAwait(false);

            Dictionary<string, DateTime> stationArrivalTimePair = new Dictionary<string, DateTime>();

            foreach (Station station in correctTrainStations)
            {
                stationArrivalTimePair.Add(station.stationName, DateTime.Parse(station.arrivalTime));
            }

            return stationArrivalTimePair;
        }
        private static async Task<List<Station>> GetCorrectTrainStations(DateTime requestTime)
        {
            //Get Schedule
            List<TrainInformation> possibleTrains = await GetTrainIDs().ConfigureAwait(false);

            //Map all arrival times in Cologne HBF to their respective Train ID
            Dictionary<DateTime, string> arrivalTimes = new Dictionary<DateTime, string>();
            foreach (TrainInformation possibleTrain in possibleTrains)
            {
                foreach (Station station in possibleTrain.stations)
                {
                    if (!station.stationName.Equals("Köln Hbf")) continue;

                    DateTime arrivalTime = DateTime.Parse(station.aimedArrivalTime);

                    arrivalTimes.Add(DateTime.Parse(station.arrivalTime), possibleTrain.id);
                }
            }
            DateTime closestLargerTime = FindClosestLargerTime(arrivalTimes.Keys.ToList<DateTime>(), requestTime);

            string closestId = arrivalTimes[closestLargerTime];
            Debug.WriteLine("closest is: " + closestId);


            //get stations for the id

            List<Station> correctTrainStations = new List<Station>();
            foreach (TrainInformation possibleTrain in possibleTrains)
            {
                if (possibleTrain.id.Equals(closestId)) correctTrainStations.AddRange(possibleTrain.stations);
            }
            return correctTrainStations;
        }
        private static int FindClosestIndex(DateTime time)
        {

            if (time.Minute < departureTimes[0] || time.Minute > departureTimes[2]) return 0;
            else if (time.Minute < departureTimes[1]) return 1;
            else return 2;
        }

        public static async Task<List<TrainInformation>> GetTrainIDs()
        {
            List<string> trajectories = await ApiFunctions.GetTrajectoriesAsync().ConfigureAwait(false);
            trajectories .ForEach(item => Debug.WriteLine(item));
            List<TrainInformation> correctTrains = await ApiFunctions.GetCorrectTrains(trajectories).ConfigureAwait(false);
            correctTrains.ForEach(item => Debug.WriteLine("Correct Train "+item.destination));
            return correctTrains;
        }

        static DateTime FindClosestLargerTime(List<DateTime> times, DateTime target)
        {
            foreach(DateTime time in times)
            {
                Debug.WriteLine($"{time} vs {target}");
            }
            DateTime output = times
                .Where(time => time > target) // Filter only times larger than the target
                .OrderBy(time => time - target) // Order by the smallest positive difference
                .FirstOrDefault(); // Get the first (closest) time or null if none
            Debug.WriteLine("Closest is apparently "+output);
            return output;
        }
    }
}
