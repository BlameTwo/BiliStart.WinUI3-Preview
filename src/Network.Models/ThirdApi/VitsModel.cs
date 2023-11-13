namespace Network.Models.ThirdApi;

public record VitsRequest(
    string Text,
    string Speaker,
    string Format = "wav",
    double Length = 1,
    double Noise = 0.5,
    double Noisew = 0.9,
    double SDPRatio = 0.2
);
