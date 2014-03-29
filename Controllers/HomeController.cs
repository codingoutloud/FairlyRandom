using FairlyRandom.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairlyRandom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Console.WriteLine(ConfigurationManager.AppSettings.Get("StorageConnectionString"));
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("attendees");
            table.CreateIfNotExists();

            var query =
               new TableQuery<RankedAttendee>().Where(TableQuery.GenerateFilterCondition("PartitionKey",
                  QueryComparisons.Equal, RankedAttendee.BootcampPartitionKey));

            var attendees = table.ExecuteQuery(query).OrderByDescending(l => l.Score).ToList();

            var model = new RankedAttendeeViewModel(attendees);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}