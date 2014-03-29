using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FairlyRandom.Models
{
    public class RankedAttendee : TableEntity
    {
        public const string BootcampPartitionKey = "Bootcamp";

        public string Name { get; /* private */ set; }
        public string Location { get; /* private */ set; }
        public string YouMightNotKnowThat { get; /* private */ set; }
        public int Score { get; /* private */ set; }
        public int Rank { get; /* private */ set; }

        public RankedAttendee()
        {

        }
        public RankedAttendee(string name, string location, string youMightNotKnowThat, int score = int.MinValue, int rank = int.MinValue)
        {
            this.PartitionKey = BootcampPartitionKey;
            this.RowKey = name;

            Name = name;
            Location = location;
            YouMightNotKnowThat = youMightNotKnowThat;
            Score = score;
        }

        public override string ToString()
        {
            return String.Format("[Rank: {0} (score: {1})] {2} is located at {3} [] [YouMightNotKnowThat: \"{4}\"]", Rank, Score, Name, Location, YouMightNotKnowThat);
        }
    }
}