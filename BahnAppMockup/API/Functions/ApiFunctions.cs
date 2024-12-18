using BahnAppMockup.API.Interfaces;
using BahnAppMockup.API.Utilities;
using BahnAppMockup.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahnAppMockup.API.Functions
{
    public class ApiFunctions
    {
        public static async Task<List<string>> GetTrajectoriesAsync()
        {
            IApiService apiService = HttpClientFactory.CreateApiService();
            try
            {
                // Call the specific endpoint
                string endpoint = "trajectories/de-gtfs-de/";
                var trajectory = await apiService.GetAsync<Trajectory>(endpoint);
                List<string> output = new List<string>();

                foreach (Feature feature in trajectory.features)
                {
                    if (feature.properties.line.name.Equals("S11")) output.Add(feature.properties.train_id);
                }
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<string>() { ex.Message };
            }
        }

        public static async Task<List<TrainInformation>> GetCorrectTrains(List<string> AllTrains)
        {
            IApiService apiService = HttpClientFactory.CreateApiService();
            try
            {
                List<TrainInformation> output = new List<TrainInformation>();
                foreach(string s in AllTrains)
                {
                    string endpoint = $"calls/{s}/";
                    var calls = await apiService.GetAsync<List<TrainInformation>>(endpoint);

                    foreach(TrainInformation call in calls)
                    {
                        if (call.destination.Equals("Bergisch Gladbach (S)")) output.Add(call);

                    }
                }

                return output;
            }   
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
