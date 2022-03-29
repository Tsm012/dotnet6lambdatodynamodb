using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Internal;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsDotnetCsharp;
public class Handler
{
    public async Task<Response> Hello(Request request)
    {
        var config = new AmazonDynamoDBConfig()
        {
            RegionEndpoint = RegionEndpoint.USWest2
        };
        var amazonDynamoDbClient = new AmazonDynamoDBClient(config);
        
        //var context = new DynamoDBContext(amazonDynamoDbClient);
        
        var putItemRequest = new PutItemRequest {
            TableName = "shantz",
            Item = new Dictionary < string, AttributeValue > {
                {
                    "ArtistId",
                    new AttributeValue {
                        S = "account.Company"
                    }
                }
            }
        };
        
        await amazonDynamoDbClient.PutItemAsync(putItemRequest);
        
        return new Response("Go Serverless v1.0! Your function executed successfully!", request);
    }
}


public class Response
{   
  public string Message {get; set;}
  public Request Request {get; set;}

  public Response(string message, Request request)
  {
    Message = message;
    Request = request;
  }
}

public class Request
{
  public string Key1 {get; set;}
  public string Key2 {get; set;}
  public string Key3 {get; set;}
}
