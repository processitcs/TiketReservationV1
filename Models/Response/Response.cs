using Azure;

namespace RezervariBilete.Models.Response;

public class Response<T>
{
    public Response()
    {
        
    }

    public Response(T data)
    {
        Data = data;
    }

    public bool Succes { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }
}
public class Response
{
    public Response()
    {
       
    }
    public Response(string message,bool response)
    {
        Succes = response;
        Message = message;
    }

    public bool Succes { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    
}