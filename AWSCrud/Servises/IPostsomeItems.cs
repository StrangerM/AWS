using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using AWSCrud.Models;

namespace AWSCrud.Servises
{
     public interface IPostsomeItems
    {
        Task AddSome(string model);
    }
}
