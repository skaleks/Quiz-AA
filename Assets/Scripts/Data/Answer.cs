using Newtonsoft.Json;

namespace Data
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Answer
    {
        public string Text;
        public bool Correct;
    }
}