using AWSCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSCrud.Servises
{
   public interface IserListofgoods
    {
       Task<DynamoModel> GetItem(int? id);
    }
}
