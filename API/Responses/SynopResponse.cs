using System.Text.Json.Serialization;

namespace API.Responses
{
    public class SynopResponse
    {
        [JsonPropertyName("id_stacji")]
        public required string IdStacji { get; set; }

        [JsonPropertyName("stacja")]
        public required string Stacja { get; set; }

        [JsonPropertyName("data_pomiaru")]
        public required DateTimeOffset DataPomiaru { get; set; }

        [JsonPropertyName("godzina_pomiaru")]
        public required string GodzinaPomiaru { get; set; }

        [JsonPropertyName("temperatura")]
        public required string Temperatura { get; set; }

        [JsonPropertyName("predkosc_wiatru")]
        public required string PredkoscWiatru { get; set; }

        [JsonPropertyName("kierunek_wiatru")]
        public required string KierunekWiatru { get; set; }

        [JsonPropertyName("wilgotnosc_wzgledna")]
        public required string WilgotnoscWzgledna { get; set; }

        [JsonPropertyName("suma_opadu")]
        public required string SumaOpadu { get; set; }

        [JsonPropertyName("cisnienie")]
        public required string Cisnienie { get; set; }
    }
}
