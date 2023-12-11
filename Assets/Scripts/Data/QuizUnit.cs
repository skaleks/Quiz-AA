using Newtonsoft.Json;

namespace Data
{
    [JsonObject(MemberSerialization.OptOut)]
    public class QuizUnit
    {
        public string Question;
        public string Background;
        public Answer[] Answers;
    }
}