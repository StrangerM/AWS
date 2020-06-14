using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSCrud.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime.Internal.Transform;
using System.Globalization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace AWSCrud.Servises
{
    public class PostsomeItems : IPostsomeItems
    {
        IAmazonDynamoDB dbclient = new AmazonDynamoDBClient();
        
        Dictionary<string, AttributeValue> keys = new Dictionary<string, AttributeValue>();
        public async Task AddSome(string json) 
        {
            PostModel n = new PostModel { ID = "", Name = "", Price = "" };
             json = JsonConvert.SerializeObject(n);

            //keys.Add(model.id, new AttributeValue {N= "" });
            //keys.Add(model.name, new AttributeValue { N = "" });
            //keys.Add(model.price, new AttributeValue { N = "" });
            // model.ID = 2;
            PostModel bsp = JsonConvert.DeserializeObject<PostModel>(json); 
            
            var queryreq = new PutItemRequest
            {
                TableName = "List",
                Item = new Dictionary<string, AttributeValue>
                {
                    
                    { "Id", new AttributeValue { N = bsp.ID }},
                    //{ "Id", new AttributeValue { N = keys["Id"].ToString()}},
                     // { "Nameofgoods", new AttributeValue { N = keys["Nameofgoods"].ToString()}},
                     // { "Price", new AttributeValue { N = keys["Price"].ToString()}},
                   // { "Id", new AttributeValue { N = model.ID.ToString() } } ,
                    //{"Nameofgoods", new AttributeValue{S= keys.Keys.ElementAt<string>(1)} },
                    //{"Price", new AttributeValue{N= keys.Keys.ElementAt<string>(2)}}
      
                },
               
            };
             await dbclient.PutItemAsync(queryreq);
        }


    }
}
