using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    [JsonObject(MemberSerialization.OptOut)]
    public class QuizUnit
    {
        public string Question;
        public string Background;
        public Answer[] Answers;
        [JsonIgnore] public Sprite Image;
    }
}