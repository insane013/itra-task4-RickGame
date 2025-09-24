namespace Task4.RandomGenerator
{
    public class GenerationRevealDTO
    {
        public int MortyNumber { get; set; }
        public int RickNumber { get; set; }

        public byte[]? SecretKey { get; set; }
        public int ResultNumber { get; set; }
    }
}