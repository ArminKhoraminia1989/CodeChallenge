

namespace CodeChallenge.Application.Responses
{
    public class BaseResponse
    {

        public BaseResponse()
        {
            Errors = new List<string>();
        }
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public int CodeStatus { get; set; }

    }
}
