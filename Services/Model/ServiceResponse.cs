namespace Services.Model
{
    public class ServiceResponse<T>
    {
        public T Data {get; set;}
        public string Error {get; set;}

        public ServiceResponse(T data)
        {
            Data = data;
        }

        public ServiceResponse(Exception ex)
        {
            Error = ex.ToString();
        }
    }
}