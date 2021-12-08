namespace Job.CrossCutting.DTO.Color
{
    public class ReadColorDTO
    {
        public int Id { get; set; }
        public virtual string ColorText { get; private set; }
    }
}