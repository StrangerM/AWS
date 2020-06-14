using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using AWSCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCrud.Servises
{
    public class serListofgoods:IserListofgoods
    {
        IAmazonDynamoDB dbclient = new AmazonDynamoDBClient();
        
        public async Task<DynamoModel> GetItem(int? id) 
        {
            var request = RequesBuilder(id);
            var result = await ScanAsync(request);
            return new DynamoModel
            {
                
                dataoflist = result.Items.Select(Map)

            };

        }
        private Item Map(Dictionary<string, AttributeValue> result)
        {
            return new Item
            {
              ID = Convert.ToInt32(result["Id"].N),
              Name = result["Nameofgoods"].S,
              Price = Convert.ToInt32(result["Price"].N)

            };
        }
        private async Task<ScanResponse> ScanAsync(ScanRequest scanRequest)
        {
            var response = await dbclient.ScanAsync(scanRequest);
            return response;
        }
        private ScanRequest RequesBuilder(int? goods)
        {
            if (goods.HasValue == false)
            {
                return new ScanRequest { TableName = "List", };

            }
            return new ScanRequest
            {
                TableName = "List",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    { ":v_Goods", new AttributeValue { S = goods.ToString() } },


                   
                },

                FilterExpression = "Id = :v_Goods ",
                ProjectionExpression = "Id,Nameofgoods,Price"
            };

        }
    }
}
